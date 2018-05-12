namespace Forum.App.Commands
{
    using Forum.App.Contracts;
    using System;

    public class PostCommand : ICommand
    {
        private ISession session;
        private IPostService postService;
        private ICommandFactory commandFactory;

        public PostCommand(ISession session, IPostService postService, ICommandFactory commandFactory)
        {
            this.session = session;
            this.postService = postService;
            this.commandFactory = commandFactory;
        }

        public IMenu Execute(params string[] args)
        {
            int userId = this.session.UserId;

            var postTitle = args[0];
            var postCategory = args[1];
            var postContent = args[2];

            int postId = this.postService.AddPost(userId, postTitle, postCategory, postContent);

            this.session.Back();
            ICommand viewPostCommand = this.commandFactory.CreateCommand("ViewPostMenu");
            return viewPostCommand.Execute(postId.ToString());
        }
    }
}
