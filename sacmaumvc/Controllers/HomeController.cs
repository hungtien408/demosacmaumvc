using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sacmaumvc.Models;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Data;

namespace sacmaumvc.Controllers
{
    public class HomeController : Controller
    {
        sacmaumvcEntities db = new sacmaumvcEntities();
        ModelAdsBanner model = new ModelAdsBanner();
        // GET: Home
        public ActionResult Index()
        {
            var xmlResultsParam = new ObjectParameter("ErrorCode", typeof(string));
            //ObjectResult<usp_AdsCategory_SelectAll_Result> query2 = db.usp_AdsCategory_SelectAll(true, false, xmlResultsParam);
            ObjectResult<AdsBanner> query = db.AdsBannerSelectAll(null, null, 5, null, null, null, null, true, null, true, xmlResultsParam);
            List<AdsBanner> lstBanner = query.ToList();

            var xmlResultsParam2 = new ObjectParameter("ErrorCode", typeof(string));
            ObjectResult<Product> query2 = db.ProductSelectAll(null, null, null, null, null, null, null, null, null, null, null, null, null, null, true, null, null, null, null, null, true, true, xmlResultsParam2);
            List<Product> lstSanPhamBanChay = query2.ToList();

            ViewBag.ListBanner = lstBanner;
            ViewBag.ListSanPhamBanChay = lstSanPhamBanChay;
            return View();
        }
        public ActionResult GioiThieu()
        {
            return View();
        }
        public PartialViewResult ListBanner()
        {
            var xmlResultsParam = new ObjectParameter("ErrorCode", typeof(string));
            //ObjectResult<usp_AdsCategory_SelectAll_Result> query2 = db.usp_AdsCategory_SelectAll(true, false, xmlResultsParam);
            ObjectResult<AdsBanner> query = db.AdsBannerSelectAll(null, null, 5, null, null, null, null, true, null, true, xmlResultsParam);
            List<AdsBanner> lstBanner = query.ToList();

            return PartialView(lstBanner);
        }
        public PartialViewResult SanPhamBanChayPartial()
        {
            var xmlResultsParam = new ObjectParameter("ErrorCode", typeof(string));
            ObjectResult<Product> query = db.ProductSelectAll(null, null, null, null, null, null, null, null, null, null, null, null, null, null, true, null, null, null, null, null, true, true, xmlResultsParam);
            List<Product> lstSanPhamBanChay = query.ToList();

            return PartialView(lstSanPhamBanChay);
        }
    }
}