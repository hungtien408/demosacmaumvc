using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sacmaumvc.Models;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace sacmaumvc.Controllers
{
    public class AdminController : Controller
    {
        sacmaumvcEntities db = new sacmaumvcEntities();
        // GET: Admin
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
        [HttpPost]
        public ActionResult QuickUpdate(int[] id, string[] arrCheckAvailabel)
        {
            try
            {
                if (arrCheckAvailabel != null)
                {
                    for (int i = 0; i < arrCheckAvailabel.Length; i++)
                    {
                        Product product = new Product() { ProductID = id[i], IsAvailable = Convert.ToBoolean(arrCheckAvailabel[i].ToString()) };
                        db.Products.Attach(product);
                        db.Entry(product).Property(x => x.IsAvailable).IsModified = true;
                        db.SaveChanges();
                    }
                }
                return Json(new
                {
                    returnCode = 1,
                    ResultMsg = "Cập nhật thành công!"
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    returnCode = 0,
                    ResultMsg = "Cập nhật thất bại! Có lỗi xảy ra"
                }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            var ErrorCodeParam = new ObjectParameter("ErrorCode", typeof(string));
            ViewBag.CategoryID = new SelectList(db.ProductCategories.ToList().OrderBy(x => x.ProductCategoryName), "ProductCategoryID", "ProductCategoryName");
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
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product product, FormCollection f, HttpPostedFileBase fileupload)
        {
            string ImageName = "";
            string ProductName = f["ProductName"].ToString();
            string ConvertedProductName = ConvertTitle(ProductName);
            if (fileupload != null)
            {
                // Lưu tên của file
                var filename = Path.GetFileName(fileupload.FileName);
                // insert data and insert image
                product.ImageName = filename;
                product.CreateDate = DateTime.Now;
                db.Products.Add(product);
                db.SaveChanges();

                int iProductID = product.ProductID;
                // Lưu đường dẫn của file
                ImageName = (string.IsNullOrEmpty(ConvertedProductName) ? "" : ConvertedProductName + "-") + iProductID.ToString() + filename.Substring(filename.LastIndexOf('.'));
                // change name image and update
                product.ProductID = iProductID;
                product.ImageName = ImageName;
                db.Products.Add(product);
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                // save image to folder
                var path = Path.Combine(Server.MapPath("~/res/product/"), ImageName);
                fileupload.SaveAs(path);
                string strFullPath = "~/res/product/" + ImageName;
                ResizeByCondition(strFullPath, 800, 800);
                CreateThumbNailByCondition("~/res/product/", "~/res/product/thumbs/", ImageName, 120, 120);
            }
            else
            {
                product.ImageName = ImageName;
                product.CreateDate = DateTime.Now;
                db.Products.Add(product);
                db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ErrorCodeParam = new ObjectParameter("ErrorCode", typeof(string));
            ObjectResult<Product> query = db.ProductSelectOne(id, ErrorCodeParam);
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
        [ValidateInput(false)]
        public ActionResult Edit(Product product, FormCollection f, HttpPostedFileBase fileupload)
        {
            string ImageName = "";
            string ProductID = f["ProductID"].ToString();
            string ProductName = f["ProductName"].ToString();
            string ConvertedProductName = ConvertTitle(ProductName);
            if (ModelState.IsValid)
            {
                if (fileupload == null)
                {
                    ImageName = f["ImageName"].ToString();
                }
                else
                {
                    // Lưu tên của file
                    var filename = Path.GetFileName(fileupload.FileName);
                    // Lưu đường dẫn của file
                    ImageName = (string.IsNullOrEmpty(ConvertedProductName) ? "" : ConvertedProductName + "-") + ProductID + filename.Substring(filename.LastIndexOf('.'));
                    var path = Path.Combine(Server.MapPath("~/res/product/"), ImageName);
                    fileupload.SaveAs(path);
                    string strFullPath = "~/res/product/" + ImageName;
                    ResizeByCondition(strFullPath, 800, 800);
                    CreateThumbNailByCondition("~/res/product/", "~/res/product/thumbs/", ImageName, 120, 120);
                }
                
                product.ImageName = ImageName;
                db.Products.Add(product);
                // Thực hiện cập nhật trong model
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteProduct(int[] id)
        {
            try 
            {
                if (id != null)
                {
                    for (int i = 0; i < id.Length; i++)
                    {
                        int productID = id[i];
                        var itemProduct = db.Products.Where(x => x.ProductID == productID).FirstOrDefault();
                        var itemProductImage = db.ProductImages.Where(x => x.ProductID == productID).FirstOrDefault();
                        if (itemProduct == null)
                        {
                            Response.StatusCode = 404;
                            return null;
                        }
                        if (itemProductImage != null)
                        {
                            db.ProductImages.Remove(itemProductImage);
                            db.SaveChanges();
                        }
                        db.Products.Remove(itemProduct);
                        db.SaveChanges();
                    }
                }
                return Json(new
                {
                    returnCode = 1,
                    ResultMsg = "Xóa thành công " + id.Length.ToString() + " dữ liệu!"
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    returnCode = 0,
                    ResultMsg = "Cập nhật thất bại! Có lỗi xảy ra"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var ErrorCodeParam = new ObjectParameter("ErrorCode", typeof(string));
            ObjectResult<Product> query = db.ProductSelectOne(id, ErrorCodeParam);
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
        [HttpPost, ActionName("Delete")]
        public ActionResult XacNhanXoa(int id)
        {
            Product product = db.Products.SingleOrDefault(x => x.ProductID == id);
            ProductImage productImage = db.ProductImages.Where(x => x.ProductID == id).SingleOrDefault();
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (productImage != null)
            {
                db.ProductImages.Remove(productImage);
                db.SaveChanges();
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #region Common
        public static string ConvertTitle(string text)
        {
            for (int i = 33; i < 48; i++)
                text = text.Replace(((char)i).ToString(), "");

            for (int i = 58; i < 65; i++)
                text = text.Replace(((char)i).ToString(), "");

            for (int i = 91; i < 97; i++)
                text = text.Replace(((char)i).ToString(), "");

            for (int i = 123; i < 127; i++)
                text = text.Replace(((char)i).ToString(), "");

            text = text.Replace(" ", "-");

            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");

            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);
            strFormD = regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');

            regex = new Regex("[^0-9a-zA-Z-]+");
            strFormD = regex.Replace(strFormD, String.Empty);

            while (strFormD.Contains("--"))
                strFormD = strFormD.Replace("--", "-");

            strFormD = strFormD.StartsWith("-") ? strFormD.Remove(0, 1) : (strFormD.EndsWith("-") ? strFormD.Remove(strFormD.Length - 1) : strFormD);

            return strFormD.ToLower();
        }

        public static void ResizeByCondition(string OriginalImagePath, int WidthToResize, int HeightToResize)
        {
            OriginalImagePath = OriginalImagePath.StartsWith("~/") ? OriginalImagePath : "~/" + OriginalImagePath;

            string FullPath = System.Web.HttpContext.Current.Server.MapPath(OriginalImagePath);
            Bitmap origBMP = new Bitmap(FullPath);
            ImageFormat format = origBMP.RawFormat;
            int width = origBMP.Width, height = origBMP.Height;

            float targetConstrains = (float)WidthToResize / HeightToResize;
            float oriConstrains = (float)origBMP.Width / origBMP.Height;

            if (origBMP.Width > WidthToResize || origBMP.Height > HeightToResize)
            {
                if (oriConstrains > targetConstrains)
                {
                    width = WidthToResize;
                    height = (int)(((float)origBMP.Height / origBMP.Width) * width);
                }
                else
                {
                    height = HeightToResize;
                    width = (int)(((float)origBMP.Width / origBMP.Height) * height);
                }
            }

            Bitmap newBMP = new Bitmap(width, height);
            Graphics objGra = Graphics.FromImage(newBMP);
            objGra.SmoothingMode = SmoothingMode.AntiAlias;
            objGra.InterpolationMode = InterpolationMode.HighQualityBicubic;
            objGra.PixelOffsetMode = PixelOffsetMode.HighQuality;
            objGra.CompositingQuality = CompositingQuality.HighQuality;
            objGra.DrawImage(origBMP, new Rectangle(0, 0, newBMP.Width, newBMP.Height));
            origBMP.Dispose();
            newBMP.Save(FullPath, format);
            newBMP.Dispose();
            objGra.Dispose();
        }

        public static void CreateThumbNailByCondition(string OriginalImagePath, string PathToSaveThumbNail, string filename, int WidthToResize, int HeightToResize)
        {
            OriginalImagePath = OriginalImagePath.StartsWith("~/") ? OriginalImagePath : "~/" + OriginalImagePath;
            PathToSaveThumbNail = PathToSaveThumbNail.StartsWith("~/") ? PathToSaveThumbNail : "~/" + PathToSaveThumbNail;

            string FullPath = System.Web.HttpContext.Current.Server.MapPath(OriginalImagePath + "/" + filename);
            string FullSaveDirectory = System.Web.HttpContext.Current.Server.MapPath(PathToSaveThumbNail);

            Bitmap origBMP = new Bitmap(FullPath);
            ImageFormat format = origBMP.RawFormat;
            int width = origBMP.Width, height = origBMP.Height;

            float targetConstrains = (float)WidthToResize / HeightToResize;
            float oriConstrains = (float)origBMP.Width / origBMP.Height;

            if (origBMP.Width > WidthToResize || origBMP.Height > HeightToResize)
            {
                if (oriConstrains > targetConstrains)
                {
                    width = WidthToResize;
                    height = (int)(((float)origBMP.Height / origBMP.Width) * width);
                }
                else
                {
                    height = HeightToResize;
                    width = (int)(((float)origBMP.Width / origBMP.Height) * height);
                }
            }

            Bitmap newBMP = new Bitmap(width, height);
            Graphics objGra = Graphics.FromImage(newBMP);
            objGra.SmoothingMode = SmoothingMode.AntiAlias;
            objGra.InterpolationMode = InterpolationMode.HighQualityBicubic;
            objGra.PixelOffsetMode = PixelOffsetMode.HighQuality;
            objGra.CompositingQuality = CompositingQuality.HighQuality;
            objGra.DrawImage(origBMP, new Rectangle(0, 0, newBMP.Width, newBMP.Height));
            origBMP.Dispose();
            newBMP.Save(FullSaveDirectory + "/" + filename, format);
            newBMP.Dispose();
            objGra.Dispose();
        }
        #endregion
    }
}