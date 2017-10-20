namespace SimpleMvc.App.BindingModels
{
    using System.Collections.Generic;

    public class UserProfileViewModel
    {
        public string Username { get; set; }

        public int UserId { get; set; }

        public IEnumerable<NoteViewModel> Notes { get; set; }
    }
}