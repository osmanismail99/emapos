using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmaPosProject.Models.Entity;

namespace EmaPosProject.ViewModel
{
    public class NewsImages
    {
        public int Id { get; set; }
        public List<news> NewsList { get; set; }
        public List<newsImage> NewsImageList { get; set; }

        public List<category> CategoryList { get; set; }

        public IEnumerable<news> Newses { get; set; }

        public news News { get; set; }
        public newsImage NewsImage { get; set; }
    }
}