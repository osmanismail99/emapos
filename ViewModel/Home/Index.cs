using EmaPosProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmaPosProject.ViewModel.Anasayfa
{
    public class Index
    {
        public List<indexCarousel> IndexCarouselList { get; set; }

        public indexWhoAreWe IndexWhoAreWe { get; set; }

        public indexContactUs IndexContactUs { get; set; }
        public List<solutionPartners> SolutionPartnersList { get; set; }

        public List<news> News { get; set; }
        public List<newsImage> NewsImage { get; set; }

        public List<sector> SectorList { get; set; }

        public List<indexProducts> indexProductList { get; set; }

        public List<category> CategoryList { get; set; }
        public List<reference> ReferenceList { get; set; } 
    }
}