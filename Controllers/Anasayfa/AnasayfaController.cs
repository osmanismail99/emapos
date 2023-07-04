using EmaPosProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmaPosProject.ViewModel.Anasayfa;
using EmaPosProject.ViewModel;
using PagedList;

namespace EmaPosProject.Controllers
{
    public class AnasayfaController : Controller
    {

        EmaDbEntities db = new EmaDbEntities();
        public PartialViewResult Navbar()
        {
            Navbar model = new Navbar();
            model.CategoryList = db.category.Where(category => category.name != "Yazılım").ToList();
            model.ProductList = db.product.Where(x => x.categoryId == 15).ToList();
            model.Contact = db.contact.First();
            return PartialView(model);
        }

        public PartialViewResult Footer()
        {
            Navbar model = new Navbar();
            model.CategoryList = db.category.Where(category => category.name != "Yazılım").Take(7).ToList();
            model.ProductList = db.product.Where(x => x.id == 15).ToList();
            model.Contact = db.contact.First();
            return PartialView(model);
        }
        public ActionResult Index()
        {
            Index model = new Index();
            model.IndexCarouselList = db.indexCarousel.OrderBy(x => x.orderNumber).ToList();
            model.IndexWhoAreWe = db.indexWhoAreWe.First();
            model.IndexContactUs = db.indexContactUs.First();
            model.SolutionPartnersList = db.solutionPartners.OrderBy(x => x.orderNumber).ToList();
            model.News = db.news.OrderByDescending(x => x.date).ToList();
            model.NewsImage = db.newsImage.ToList();
            model.SectorList = db.sector.ToList();
            model.indexProductList = db.indexProducts.Where(x => x.visibility == true).ToList();
            model.CategoryList = db.category.ToList();
            model.ReferenceList = db.reference.ToList();
            return View(model);
        }

        public ActionResult Hakkimizda()
        {
            var data = db.about.First();
            return View(data);
        }

        public ActionResult Misyonumuz()
        {
            var data = db.mission.First();
            return View(data);
        }

        public ActionResult Vizyonumuz()
        {
            var data = db.vision.First();
            return View(data);
        }

        public ActionResult Iletisim()
        {
            var data = db.contact.First();
            return View(data);
        }

        public ActionResult Referanslar()
        {

            var data = db.reference.OrderBy(reference => reference.orderNumber).ToList();
            return View(data);
        }

        public ActionResult Urun(int id, int page = 1)
        {
            //by.Deger1 = c.Blogs.OrderByDescending(x => x.ID).ToList().ToPagedList(sayfa, 5);
            ProductImages model = new ProductImages();
            model.Products = db.product.Where(x => x.categoryId == id).ToList().ToPagedList(page, 9);
            //model.ProductList = db.product.Where(x=>x.categoryId == id).ToList();
            model.ProductImageList = db.productImage.ToList();
            model.CategoryList = db.category.ToList();
            model.Category = db.category.Find(id);
            return View(model);
        }



        public ActionResult UrunDetay(int id)
        {
            ProductImages model = new ProductImages();
            model.CategoryList = db.category.ToList();
            model.Product = db.product.Where(x => x.id == id).First();
            model.ProductImageList = db.productImage.ToList();
            model.ProdctImagess = db.productImage.Where(x => x.productId == id).ToList();
            int category = (int)db.product.Where(x => x.id == id).First().categoryId;
            model.ProductList = db.product.Where(x => x.categoryId == category).ToList();
            return View(model);
        }

        public ActionResult Haberler(int page = 1)
        {
            NewsImages model = new NewsImages();
            model.Newses = db.news.ToList().OrderByDescending(x => x.date).ToPagedList(page, 6);
            model.NewsImageList = db.newsImage.ToList();
            model.CategoryList = db.category.ToList();
            return View(model);
        }

        public ActionResult HaberDetay(int id)
        {
            NewsImages model = new NewsImages();
            model.News = db.news.Where(x => x.id == id).First();
            model.NewsImageList = db.newsImage.Where(newsImage => newsImage.newsId == id).ToList();
            model.CategoryList = db.category.ToList();
            return View(model);
        }

        public ActionResult Donanim()
        {
            var data = db.category.OrderBy(x => x.orderNumber).Where(x => !x.name.Equals("Yazılım")).ToList();
            return View(data);
        }


        public ActionResult SektorDetay(int id)
        {
            SectorCategories model = new SectorCategories();
            model.Sector = db.sector.Where(x => x.id == id).First();
            model.SectorsCategoryList = db.sectorsCategory.Where(x => x.sectorId == id).ToList();
            return View(model);
        }



    }
}