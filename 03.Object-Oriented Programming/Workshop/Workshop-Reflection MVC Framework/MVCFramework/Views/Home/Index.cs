using System;
using MVCFramework.Core.Interfaces;
using MVCFramework.ViewModels;

namespace MVCFramework.Views.Home
{
    public class Index : IRenderable
    {
        public void Render()
        {
            Console.WriteLine("My first view");
        }

        public IndexViewModel Model { get; set; }
    }
}