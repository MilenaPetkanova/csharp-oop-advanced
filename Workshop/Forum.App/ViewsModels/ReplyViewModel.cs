﻿namespace Forum.App.Models.ViewsModels
{
    using Forum.App.Contracts;

    public class ReplyViewModel : ContentViewModel, IReplyViewModel
    {
        public ReplyViewModel(string author, string content) 
            : base(content)
        {
            this.Author = author;
        }

        public string Author { get; }
    }
}
