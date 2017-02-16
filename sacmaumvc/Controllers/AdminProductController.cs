using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sacmaumvc.Models;
using System.Data.Entity.Core.Objects;

namespace sacmaumvc.Controllers
{
    public class AdminProductController : Controller
    {
        sacmaumvcEntities db = new sacmaumvcEntities();
        // GET: AdminProduct
        public ActionResult Index()
        {
            var ErrorCodeParam = new ObjectParameter("ErrorCode", typeof(string));
            ObjectResult<Product> query = db.ProductSelectAll(
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                ErrorCodeParam);
            List<Product> listProduct = query.ToList();
            return View(listProduct);
        }
        [HttpGet]
        public ActionResult Edit(int iProductID)
        {
            var ErrorCodeParam = new ObjectParameter("ErrorCode", typeof(string));
            ObjectResult<Product> query = db.ProductSelectOne(iProductID, ErrorCodeParam);
            //List<Product> listProductEdit = query.ToList();
            Product product = query.SingleOrDefault();
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.CategoryID = new SelectList(db.ProductCategories.ToList().OrderBy(x => x.ProductCategoryName), "ProductCategoryID", "ProductCategoryName", product.CategoryID);
            ObjectResult<Product> queryProduct = db.ProductSelectAll(
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                ErrorCodeParam);
            List<Product> listProduct = queryProduct.ToList();
            ViewBag.ListProduct = listProduct;
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(int iProductID, FormCollection f)
        {
            if(iProductID == 0){
                Response.StatusCode = 404;
                return null;
            }
            string MetaTittle = f["MetaTittle"].ToString();
            string MetaDescription = "";
            string ImageName = "";
            string ProductName = "";
            string ConvertedProductName = "";
            string Description = "";
            string Content = "";
            string Tag = "";
            string MetaTittleEn = "";
            string MetaDescriptionEn = "";
            string ProductNameEn = "";
            string DescriptionEn = "";
            string ContentEn = "";
            string TagEn = "";
            string Price = "";
            string OtherPrice = "";
            string SavePrice = "";
            string Discount = "";
            string CategoryID = "";
            string ManufacturerID = "";
            string OriginID = "";
            string InStock = "";
            string IsHot = "";
            string IsNew = "";
            string IsBestSeller = "";
            string IsSafeOff = "";

            //db.usp_Product_Update(iProductID, MetaTittle, null, null, null, null, null, null, null, null, null, null, null, null, null);
            return RedirectToAction("Index");
        }
    }
}