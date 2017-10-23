using System;
using MVCFramework.Core.Interfaces.Generic;
using MVCFramework.ViewModels;

namespace MVCFramework.Views.Student
{
    public class Edit : IRenderable<StudentViewModel>
    {
        public void Render()
        {
            Console.WriteLine("Edit view to student");
            Console.WriteLine("Full name: {0}", Model.FullName);
        }

        public StudentViewModel Model { get; set; }
    }
}