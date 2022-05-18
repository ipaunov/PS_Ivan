using System;

namespace UserLogin
{
    public class LoginValidation
    {
        public static string _userName
        { get; private set; }
        public static string _password
        { get; private set; }

        private string _errorMessage;

        public delegate void ActionOnError(string _errorMessage);
        private ActionOnError _onError;
        public static UserRoles currentUserRole
        { get; private set; }

        public LoginValidation(string user, string pass, ActionOnError error)
        {
            _userName = user;
            _password = pass;
            _onError = error;
        }
        public bool ValidateUserInput(ref User u)
        {
            User newu = new User();
            if (_userName.Equals(String.Empty))
            {
                _errorMessage = "Missing username";
                _onError(_errorMessage);
                return false;
            }
            if (_password.Equals(String.Empty))
            {
                _errorMessage = "Missing password";
                _onError(_errorMessage);
                return false;
            }
            if (_userName.Length < 5 || _password.Length < 5)
            {
                _errorMessage = "Username or password too short";
                _onError(_errorMessage);
                return false;
            }
            if (UserData.IsUserPassCorrect(_userName, _password) != null)
            {
                newu = UserData.IsUserPassCorrect(_userName, _password);
                u = newu;
                currentUserRole = (UserRoles)u.userRole;
                Logger.LogActivity("Succesful login");
                return true;
            }

            _errorMessage = "Invalid username or password";
            _onError(_errorMessage);
            currentUserRole = 0;
            return false;
        }
    }
}
