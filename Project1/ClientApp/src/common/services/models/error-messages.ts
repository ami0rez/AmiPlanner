export class ErrorMessages {
  static readonly success = $localize`:@@global.success:Success`;
  static readonly info = $localize`:@@global.info:Information`;
  static readonly warning = $localize`:@@global.warning:Warning`;
  static readonly error = $localize`:@@global.error:Error`;
  static readonly error0 = $localize`:@@global.error500:Server not reachable!`;
  static readonly error401 = $localize`:@@global.error401:Session time out`;
  static readonly error403 = $localize`:@@global.error403:Unauthorized`;
  static readonly error500 = $localize`:@@global.error500:Internal Server Error!`;
  static readonly error504 = $localize`:@@global.error504:Gateway Timeout!`;
  static readonly UnknownUser = $localize`:@@global.error401:Session time out`;

  //#region Security
  static readonly PasswordMustContainNumber = $localize`:@@error-messages.passwordMustContainNumber:Password must contain a number`;
  static readonly PasswordMustContainSymbol = $localize`:@@error-messages.passwordMustContainSymbol:Password must contain a symbol`;
  static readonly PasswordMustContainUpperCase = $localize`:@@error-messages.passwordMustContainUpperCase:password must contain uppercase letters`;
  static readonly PasswordMustContainLowerCase = $localize`:@@error-messages.passwordMustContainLowerCase:password must contain lowercase letters`;
  static readonly PasswordLengthInvalid = $localize`:@@error-messages.passwordLengthInvalid:Password length must exceed {0} characters`;
  static readonly EmailNotFound = $localize`:@@error-messages.emailNotFound:Email address not found`;
  static readonly UserNameMustBeUnique = $localize`:@@error-messages.userNameMustBeUnique:User name must be unique`;
  static readonly EmailMustBeUnique = $localize`:@@error-messages.emailMustBeUnique:Email must be unique`;
  static readonly ItemAlreadyUsed = $localize`:@@error-messages.itemAlreadyUsed:Item already used`;
  static readonly UserNotFound = $localize`:@@error-messages.usernotfound:User not found`;
  static readonly UserLocked = $localize`:@@login.compteBloque:Ce compte est temporairement bloqué`;
  static readonly BadRefreshTokenRequest = $localize`:@@global.badRefreshTokenRequest:Votre session a expiré. Merci de vous reconnecter.`;
  static readonly InvalidUserOrPassword = $localize`:@@login.nomUtilisateurOuMotDepasseInvalides:Nom d'utilisateur ou mot de passe invalides !`;
  static readonly ErrorLoginUserBlocked = $localize`:@@login.compteBloque:Ce compte est temporairement bloqué`;
  static readonly InvalidUserNameCombination = $localize`:@@user.invalidUserNameCombination:Le nom d’utilisateur ne peut contenir que des caractères alphanumériques, des points et des traits de soulignement`;
  static readonly InvalidUserNameFirstChar = $localize`:@@user.invalidUserNameFirstChar:Le premier caractère du nom d’utilisateur doit être un caractère alphabétique`;
  static readonly UserRoleNotFound = $localize`:@@user.userRoleNotFound:User role is invalid`;
  static readonly UserRuoIsRequired = $localize`:@@user.userRuoIsRequired:User RUO is required`;
  static readonly UserRuoNotFound = $localize`:@@user.userRuoNotFound:User RUO is invalid`;

  // Changer mot de passe
  static readonly ChangePasswordInvalidLogin = $localize`:@@changer-mot-de-passe.changePasswordInvalidLogin:Invalid login`;
  static readonly OldPasswordIsWrong = $localize`:@@changer-mot-de-passe.oldPasswordIsWrong:The current password is wrong`;
  static readonly ErrorChangePassword = $localize`:@@changer-mot-de-passe.errorChangePassword:Error while changing password`;
  static readonly PasswordFormatIsWrrong = $localize`:@@changer-mot-de-passe.passwordFormatIsWrong:Password format is wrrong`;

  //#endregion
}
