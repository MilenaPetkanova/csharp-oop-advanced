namespace Forum.App.Services
{
    using Forum.App.Contracts;
    using System;
    using Forum.DataModels;
    using Forum.Data;
    using System.Linq;

    public class UserService : IUserService
    {
        private ForumData forumData;
        private ISession session;

        public UserService(ForumData forumData, ISession session)
        {
            this.forumData = forumData;
            this.session = session;
        }

        public User GetUserById(int userId)
        {
            var user = this.forumData.Users.FirstOrDefault(u => u.Id.Equals(userId));
            return user;
        }

        public string GetUserName(int userId)
        {
            var user = this.forumData.Users.FirstOrDefault(u => u.Id.Equals(userId));
            return user.Username;
        }

        public bool TryLogInUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            User user = this.forumData.Users
                .FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));

            if (user == null)
            {
                return false;
            }

            this.session.Reset();
            this.session.LogIn(user);

            return true;
        }

        public bool TrySignUpUser(string username, string password)
        {
            bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if (!validUsername || !validPassword)
            {
                throw new ArgumentException("Username and password must be longer than 3 symbols!");
            }

            bool userAlreadyExists = forumData.Users.Any(u => u.Username.Equals(username));

            if (userAlreadyExists)
            {
                throw new ArgumentException("Username taken!");
            }

            int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
            User user = new User(userId, username, password);

            this.forumData.Users.Add(user);
            this.forumData.SaveChanges();

            this.TryLogInUser(username, password);

            return true;
        }
    }
}
