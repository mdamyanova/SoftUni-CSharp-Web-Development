namespace SimpleMvc.App.BindingModels
{
    using System.Collections.Generic;

    public class AllUsernamesViewModel
    {
        public IDictionary<int, string> UsersWithIds { get; set; }
    }
}