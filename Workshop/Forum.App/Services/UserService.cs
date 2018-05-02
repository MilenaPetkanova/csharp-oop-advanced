namespace Forum.App.Services
{
    using Forum.App.Contracts;
    using System;
    using Forum.DataModels;
    using Forum.Data;

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
            throw new NotImplementedException();
        }

        public string GetUserName(int userId)
        {
            throw new NotImplementedException();
        }

        public bool TryLogInUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool TrySignUpUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
