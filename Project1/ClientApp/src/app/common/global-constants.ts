import { CommonConstants } from 'involys-common/common';

export class Constants extends CommonConstants {
  public static yes = $localize`:@@global.yes: Yes`;
  public static no = $localize`:@@global.no: No`;
  public static defaultCountry = $localize`:@@global.country: Country`;
  //#region Security
  public static defaultAdminLogin = 'Administrateur';
  public static usernamePattern = /^[A-Za-z0-9_\.]+$/;
  //#endregion

  public static defaultValueDropDown = '-1';
  public static defaultStratDate = '0001-01-01T00:00:00';
  public static hexas = '0123456789ABCDEF';
  public static diese = '#';
  public static slash = '/';
  public static validFr = 'valideFr';
  public static dot = '.';
  public static comma = ',';

  public static licenseExtension = '.lic';
  public static percentDigits = '1.2-2';

  //#region Length inputs
  public static refLength = '50';
  public static designationLength = '250';
  public static objetLength = '500';
  //#endregion

  //#region error message
  public static badRequest = 'Not Found';
  public static notFound = 'Bad Request';
  //#endregion
}
