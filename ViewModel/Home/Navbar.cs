using EmaPosProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmaPosProject.ViewModel.Anasayfa
{
    public class Navbar
    {
        public IEnumerable<category> CategoryList { get; set; }
        public IEnumerable<product> ProductList { get; set; }

        public contact Contact { get; set; }
    }
}