export class UrlConstants {
  public static readonly home = '/'
  public static readonly securrityUrl = 'security'
  public static readonly loginUrl = `${UrlConstants.securrityUrl}/login`
  public static readonly logoutUrl = `${UrlConstants.securrityUrl}/logout`
  public static readonly updatePasswordUrl = `${UrlConstants.securrityUrl}/update-password`
}