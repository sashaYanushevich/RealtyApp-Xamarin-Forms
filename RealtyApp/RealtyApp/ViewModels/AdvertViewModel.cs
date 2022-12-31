using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MvvmHelpers;

namespace RealtyApp.ViewModels
{
    public class AdvertViewModel : ObservableObject
    {
        public long id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int AllSquare { get; set; }
        public string Desc { get; set; }
        public string ImageUrl { get; set; }
        public bool isFeatured { get; set; }

    }
}
