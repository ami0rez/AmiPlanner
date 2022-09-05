import { FieldObject } from 'involys-common/common';
import {
  ColumnTableFilter,
  CustomFilter,
  CustomPredefinedFilter,
  MenuItem,
} from 'involys-library';
import { UtilisateurData } from './utilisateur-data';

export class UtilisateurPage {
  data: UtilisateurData = new UtilisateurData();
  initialData: UtilisateurData = new UtilisateurData();
  bloque: FieldObject = new FieldObject();
  admin: FieldObject = new FieldObject();
  login: FieldObject = new FieldObject();
  pageMode: string;
  editMode: boolean;
  createFromPage: boolean;
  splitButtonActions: MenuItem[];
  showActions: boolean = false;
  //#region Filters
  conditions: string[] = [];
  selectedFilters: CustomFilter[] = [];
  predefinedFilter: CustomPredefinedFilter[] = [];
  columns: ColumnTableFilter[] = [];
  //#endregion
}
