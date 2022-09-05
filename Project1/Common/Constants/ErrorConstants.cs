namespace Amirez.AmipBackend.Common.Constants
{
    public static class ErrorConstants
    {
        #region Folder
        public const string FolderNameExists = "A folder with the same name already exists";
        public const string FolderNotFound = "Folder not found";
        #endregion

        #region Goal
        public const string GoalFolderIdRequired = "A goal must have a folder";
        public const string GoalNameExists = "A goal with the same name already exists";
        public const string GoalNotFound = "Goal not found";
        #endregion

        #region Project
        public const string ProjectGoalIdRequired = "A project must have a goal";
        public const string ProjectNameExists = "A project with the same name already exists";
        public const string ProjectNotFound = "Project not found";
        #endregion

        #region Task
        public const string TaskProjectIdRequired = "A project must have a goal";
        public const string TaskNameExists = "A project with the same name already exists";
        public const string TaskNotFound = "Project not found";
        #endregion

        #region Exceptions
        public const string ItemNotFound = "ItemNotFound";
        public const string ItemAlreadyUsed = "ItemAlreadyUsed";
        public const string ItemMustBeUnique = "ItemMustBeUnique";
        public const string CannotDeleteDelegation = "CannotDeleteDelegation";
        #endregion

        #region Authentication
        public const string BadRefreshTokenRequest = "BadRefreshTokenRequest";
        public const string UserNotFound = "UserNotFound";
        public const string ErrorRefreshTokenRequest = "ErrorRefreshTokenRequest";
        public const string UnknownUser = "UnknownUser";
        public const string ErrorLoginUserBlocked = "ErrorLoginUserBlocked";

        //Change password
        public const string PasswordFormatIsWrrong = "PasswordFormatIsWrrong";
        public const string ErrorChangePassword = "ErrorChangePassword";
        public const string OldPasswordIsWrong = "OldPasswordIsWrong";
        public const string ChangePasswordInvalidLogin = "ChangePasswordInvalidLogin";
        #endregion

        #region Utilisateurs
        public const string UserNameMustBeUnique = "UserNameMustBeUnique";
        public const string EmailMustBeUnique = "EmailMustBeUnique";
        public const string ErrorCreateUser = "ErrorCreateUser";
        public const string ErrorUpdateUser = "ErrorUpdateUser";
        public const string InvalidUserNameCombination = "InvalidUserNameCombination";
        public const string InvalidUserNameFirstChar = "InvalidUserNameFirstChar";
        public const string InvalidUserOrPassword = "InvalidUserOrPassword";
        public const string UserLocked = "UserLocked";
        public const string UserRoleNotFound = "UserRoleNotFound";
        public const string UserRuoIsRequired = "UserRuoIsRequired";
        public const string UserRuoNotFound = "UserRuoNotFound";
        #endregion
    }
}
