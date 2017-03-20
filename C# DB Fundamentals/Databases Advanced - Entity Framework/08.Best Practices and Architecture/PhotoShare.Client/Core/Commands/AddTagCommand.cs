namespace PhotoShare.Client.Core.Commands
{
    using Services;
    using System;
    using Utilities;

    public class AddTagCommand
    {
        private readonly TagService tagService;

        public AddTagCommand(TagService tagService)
        {
            this.tagService = tagService;
        }

        // AddTag <tag>
        public string Execute(string[] data)
        {
            if (!AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException("Log in in order to add tags!");
            }

            string tag = data[0].ValidateOrTransform();
            if (this.tagService.IsTagExisting(tag))
            {
                throw new ArgumentException($"Tag [{tag}] exists!");
            }

            this.tagService.AddTag(tag);
                
            return "Tag "+tag + " was added successfully to database!";
        }
    }
}
