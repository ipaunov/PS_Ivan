using System;
using System.Collections.Generic;
using System.Linq;


namespace UserLogin
{
    public static class UserData
    {
        private static List<User> _testUsers;

        public static List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }
        private static void ResetTestUserData()
        {
            if (_testUsers == null)
            {
                _testUsers = new List<User>(3);
                _testUsers.Add(new User());
                _testUsers[0].username = "Admin";
                _testUsers[0].password = "Admin";
                _testUsers[0].facultyNumber = "001001";
                _testUsers[0].userRole = 1;
                _testUsers[0].created = DateTime.Now;
                _testUsers[0].validTime = DateTime.MaxValue;

                _testUsers.Add(new User());
                _testUsers[1].username = "User1";
                _testUsers[1].password = "User1User";
                _testUsers[1].facultyNumber = "007007";
                _testUsers[1].userRole = 4;
                _testUsers[1].created = DateTime.Now;
                _testUsers[1].validTime = DateTime.MaxValue;

                _testUsers.Add(new User());
                _testUsers[2].username = "Vanko";
                _testUsers[2].password = "Vanko1Vanko";
                _testUsers[2].facultyNumber = "006006";
                _testUsers[2].userRole = 4;
                _testUsers[2].created = DateTime.Now;
                _testUsers[2].validTime = DateTime.MaxValue;
            }
        }

        public static User IsUserPassCorrect(string user, string pass)
        {
            UserContext context = new UserContext();
            User login = (from u in context.Users where u.username == user && u.password == pass select u).First();

            if (login != null)
            {
                return login;
            }
            return null;
        }

        public static void SetUserActiveTo(string user, DateTime date)
        {
            foreach (User u in _testUsers)
            {
                if (u.username == user)
                {
                    u.validTime = date;
                    Logger.LogActivity("Active date changed of user: " + user);
                }
            }
        }

        public static void AssignUserRole(string user, UserRoles role)
        {
            UserContext context = new UserContext();
            foreach (User u in _testUsers)
            {
                if (u.username == user)
                {
                    u.userRole = Convert.ToInt32(role);
                    Logger.LogActivity("Role changed of user: " + user);
                    break;
                }
            }
            context.SaveChanges();
        }
    }
}
