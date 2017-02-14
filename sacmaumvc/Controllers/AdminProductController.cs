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
        public ActionResult Edit(int iProductID)
        {
            if (iProductID != null)
            {
                var ErrorCodeParam = new ObjectParameter("ErrorCode", typeof(string));
                ObjectResult<Product> query = db.ProductSelectOne(iProductID, ErrorCodeParam);
                List<Product> listProductEdit = query.ToList();
                return View(listProductEdit);
            }
            else
            {

                return View();
            }
        }
    }
}