using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Web.Models.ManageModels
{
    public class RemoveLoginModel
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
    }
}
