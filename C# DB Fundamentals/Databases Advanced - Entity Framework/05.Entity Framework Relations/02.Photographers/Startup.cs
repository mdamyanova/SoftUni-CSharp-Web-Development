using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.Photographers.Models;

namespace _02.Photographers
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new PhotographersContext();
            Console.WriteLine(context);
            Tag tag = new Tag() { Label = "Krushi" };
            context.Tags.Add(tag);
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                tag.Label = TagTransformer.Transform(tag.Label);
                context.SaveChanges();
            }
        }
    }
}