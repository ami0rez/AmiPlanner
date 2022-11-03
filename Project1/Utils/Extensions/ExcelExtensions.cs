using ClosedXML.Excel;
using Involys.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Amirez.AmiPlanner.Utils.Extensions
{
    public static class ExcelExtensions
    {

        /// <summary>
        /// Reads Excel file to datat table from file
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static Dictionary<Type, IEnumerable<object>> ReadExcelToDataTables(this IFormFile file)
        {
            var path = file.Save();
            return ReadExcelToDataTable(path);
        }

        /// <summary>
        /// Reads Excel file to datat table from path
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static Dictionary<Type, IEnumerable<object>> ReadExcelToDataTable(this string filepath)
        {
            Dictionary<Type, IEnumerable<object>> data = new Dictionary<Type, IEnumerable<object>>();
            //Checking file content length and Ext
            //Started reading the Excel file.  
                MethodInfo method = typeof(ExcelExtensions).GetMethod(nameof(ExcelExtensions.ConvertDataTable));
            using (XLWorkbook workbook = new XLWorkbook(filepath))
            {
                foreach (IXLWorksheet worksheet in workbook.Worksheets)
                {
                    var dt = ReadWorksheetToDataTable(worksheet);
                    var type = GetDataModelsType(worksheet.Name);
                    MethodInfo generic = method.MakeGenericMethod(type);
                    var list = generic.Invoke(null, new object[] { dt });
                    data.Add(type, (IEnumerable<object>)list);
                }
            }
            return data;
        }

        /// <summary>
        /// Reads worksheet to datat table
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static DataTable ReadWorksheetToDataTable(IXLWorksheet worksheet)
        {
            DataTable dt = new DataTable();
            //Checking file content length and Ext
            //Started reading the Excel file.  

            bool FirstRow = true;
            //Range for reading the cells based on the last cell used.  
            string readRange = "1:1";
            foreach (IXLRow row in worksheet.RowsUsed())
            {
                //If Reading the First Row (used) then add them as column name  
                if (FirstRow)
                {
                    //Checking the Last cellused for column generation in datatable  
                    readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                    foreach (IXLCell cell in row.Cells(readRange))
                    {
                        dt.Columns.Add(cell.Value.ToString());
                    }
                    FirstRow = false;
                }
                else
                {
                    //Adding a Row in datatable  
                    dt.Rows.Add();
                    int cellIndex = 0;
                    //Updating the values of datatable  
                    foreach (IXLCell cell in row.Cells(readRange))
                    {
                        dt.Rows[dt.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                        cellIndex++;
                    }
                }
            }
            //If no data in Excel file  
            if (FirstRow)
            {
                throw new ResponseException("Empty Excel File!");
            }
            return dt;
        }

        /// <summary>
        /// Converts data table to list of objects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static IEnumerable<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        /// <summary>
        /// Converts row to object using reflection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <returns></returns>
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, FormatProperty(pro, dr[column.ColumnName]), null);
                    else
                        continue;
                }
            }
            return obj;
        }


        /// <summary>
        /// Format property value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <returns></returns>
        private static object? FormatProperty(PropertyInfo prop, object value)
        {
            if(prop.PropertyType.Name == "Guid")
            {
                Guid.TryParse(value?.ToString(), out var guidValue);
                return guidValue;
            }else if(prop.PropertyType.Name == "Boolean")
            {
                return value == "1";
            }else if(prop.PropertyType.Name == "Nullable`1" && prop.PropertyType.FullName.Contains("DateTime"))
            {
                var parsed = DateTime.TryParse(value?.ToString(), out var dateValue);
                return parsed ? dateValue : null;
            }
            else if (prop.PropertyType.Name == "DateTime")
            {
                DateTime.TryParse(value?.ToString(), out var dateValue);
                return dateValue;
            }
            return value;
        }


        /// <summary>
        /// Get type form string class name
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static Type GetDataModelsType(string type)
        {
            var asembly = Assembly.Load("Amirez.Infrastructure");
            return asembly.GetType("Amirez.Infrastructure.Data.Model.Budget." + type);
        }
    }
}
