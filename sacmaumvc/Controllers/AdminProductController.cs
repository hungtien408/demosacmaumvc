using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sacmaumvc.Models;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

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
        [ValidateInput(false)]
        public ActionResult Edit(Product product, FormCollection f)
        {
            // Cách 2: để cập nhật
            //Sach sach1 = db.Saches.SingleOrDefault(x => x.MaSach == sach.MaSach);
            //sach1.MoTa = sach.MoTa;
            //sach1.MoTa = f.Get("abc").ToString();
            //sach1.MoTa = f["abc"].ToString();
            //db.SaveChanges();

            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                // Thực hiện cập nhật trong model
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            // Đưa dữ liệu vào dropdownlist
            ViewBag.CategoryID = new SelectList(db.ProductCategories.ToList().OrderBy(x => x.ProductCategoryName), "ProductCategoryID", "ProductCategoryName", product.CategoryID);
            var ErrorCodeParam = new ObjectParameter("ErrorCode", typeof(string));
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
            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public ActionResult Edit(Product product, FormCollection f, HttpPostedFileBase fileupload)
        //{
        //    string ConvertedProductName = ConvertTitle(f["ProductName"].ToString());
        //    string ImageName = "";
        //    if (fileupload == null)
        //    {
        //        ImageName = f["ImageName"].ToString();
        //    }
        //    else
        //    {
        //        var filename = Path.GetFileName(fileupload.FileName);
        //        // Lưu đường dẫn của file
        //        var strFullPath = Path.Combine(Server.MapPath("~/res/product/"), filename);
        //        fileupload.SaveAs(strFullPath);

        //        ResizeByCondition(strFullPath, 277, 230);
        //        CreateThumbNailByCondition("~/res/product/", "~/res/product/thumbs/", ImageName, 120, 120);
        //        ImageName = (string.IsNullOrEmpty(ConvertedProductName) ? "" : ConvertedProductName + "-") + f["ProductID"].ToString() + ImageName.Substring(ImageName.LastIndexOf('.'));
        //    }

        //    Product product1 = db.Products.SingleOrDefault(x => x.ProductID == product.ProductID);
        //    //sach1.MoTa = sach.MoTa;
        //    //sach1.MoTa = f.Get("abc").ToString();
        //    //sach1.MoTa = f["abc"].ToString();
        //    //db.SaveChanges();
        //    product1.MetaTittle = f["MetaTittle"].ToString();
        //    product1.MetaDescription = f["MetaDescription"].ToString();
        //    product1.ProductName = f["ProductName"].ToString();
        //    product1.ImageName = ImageName;
        //    product1.Description = f["Description"].ToString();
        //    product1.Content = f["Content"].ToString();
        //    product1.Tag = f["Tag"].ToString();
        //    product1.MetaTittleEn = f["MetaTittleEn"].ToString();
        //    product1.MetaDescriptionEn = f["MetaDescriptionEn"].ToString();
        //    product1.ProductNameEn = f["ProductNameEn"].ToString();
        //    product1.DescriptionEn = f["DescriptionEn"].ToString();
        //    product1.ContentEn = f["ContentEn"].ToString();
        //    product1.TagEn = f["TagEn"].ToString();
        //    product1.Price = Convert.ToDecimal(f["Price"].ToString());
        //    product1.OtherPrice = f["OtherPrice"].ToString();
        //    product1.SavePrice = Convert.ToDecimal(f["SavePrice"].ToString());
        //    product1.Discount = 0;
        //    product1.CategoryID = Convert.ToInt32(f["CategoryID"].ToString());
        //    product1.ManufacturerID = Convert.ToInt32(f["ManufacturerID"].ToString());
        //    product1.OriginID = Convert.ToInt32(f["OriginID"].ToString());
        //    product1.InStock = Convert.ToBoolean(f["InStock"].ToString());
        //    product1.IsHot = Convert.ToBoolean(f["IsHot"].ToString());
        //    product1.IsNew = Convert.ToBoolean(f["IsNew"].ToString());
        //    product1.IsBestSeller = Convert.ToBoolean(f["IsBestSeller"].ToString());
        //    product1.IsShowOnHomePage = Convert.ToBoolean(f["IsShowOnHomePage"].ToString());
        //    product1.IsAvailable = Convert.ToBoolean(f["IsAvailable"].ToString());
        //    db.SaveChanges();
        //    var ErrorCodeParam = new ObjectParameter("ErrorCode", typeof(string));
        //    ObjectResult<Product> queryProduct = db.ProductSelectAll(
        //        null,
        //        null,
        //        null,
        //        null,
        //        null,
        //        null,
        //        null,
        //        null,
        //        null,
        //        null,
        //        null,
        //        null,
        //        null,
        //        null,
        //        null,
        //        null,
        //        null,
        //        null,
        //        null,
        //        null,
        //        null,
        //        null,
        //        ErrorCodeParam);
        //    List<Product> listProduct = queryProduct.ToList();
        //    ViewBag.ListProduct = listProduct;
        //    return RedirectToAction("Index");
        //}
        //public ActionResult Edit(int iProductID, FormCollection f, HttpPostedFileBase fileupload)
        //{
        //    if(iProductID == 0){
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    string MetaTittle = f["MetaTittle"].ToString();
        //    string MetaDescription = f["MetaDescription"].ToString();
        //    string ProductName = f["ProductName"].ToString();
        //    string ConvertedProductName = ConvertTitle(ProductName);
        //    string ImageName = "";
        //    if (fileupload == null)
        //    {
        //        ImageName = f["ImageName"].ToString();
        //    }
        //    else
        //    {
        //        var filename = Path.GetFileName(fileupload.FileName);
        //        // Lưu đường dẫn của file
        //        var strFullPath = Path.Combine(Server.MapPath("~/res/product/"), filename);
        //        fileupload.SaveAs(strFullPath);

        //        ResizeCropImage.ResizeByCondition(strFullPath, 277, 230);
        //        ResizeCropImage.CreateThumbNailByCondition("~/res/product/", "~/res/product/thumbs/", ImageName, 120, 120);
        //        ImageName = (string.IsNullOrEmpty(ConvertedProductName) ? "" : ConvertedProductName + "-") + iProductID.ToString() + ImageName.Substring(ImageName.LastIndexOf('.'));
        //    }

        //    string Description = f["Description"].ToString();
        //    string Content = f["Content"].ToString();
        //    string Tag = f["Tag"].ToString();
        //    string MetaTittleEn = f["MetaTittleEn"].ToString();
        //    string MetaDescriptionEn = f["MetaDescriptionEn"].ToString();
        //    string ProductNameEn = f["ProductNameEn"].ToString();
        //    string DescriptionEn = f["DescriptionEn"].ToString();
        //    string ContentEn = f["ContentEn"].ToString();
        //    string TagEn = f["TagEn"].ToString();
        //    decimal Price = 0;
        //    string OtherPrice = "";
        //    decimal SavePrice = 0;
        //    short Discount = 0;
        //    int CategoryID = Convert.ToInt32(f["CategoryID"].ToString());
        //    int ManufacturerID = Convert.ToInt32(f["ManufacturerID"].ToString()); ;
        //    int OriginID = Convert.ToInt32(f["OriginID"].ToString()); ;
        //    bool InStock = false;
        //    bool IsHot = false;
        //    bool IsNew = false;
        //    bool IsBestSeller = false;
        //    bool IsSafeOff = false;
        //    bool IsShowOnHomePage = false;
        //    int Prioriy = 0;
        //    bool IsAvailable = false;
        //    var ErrorCodeParam = new ObjectParameter("ErrorCode", typeof(string));

        //    db.usp_Product_Update(
        //        iProductID, 
        //        MetaTittle, 
        //        MetaDescription, 
        //        ImageName, 
        //        ProductName, 
        //        ConvertedProductName, 
        //        Description, 
        //        Content, 
        //        Tag, 
        //        MetaTittleEn, 
        //        MetaDescriptionEn, 
        //        ProductNameEn,
        //        DescriptionEn,
        //        ContentEn,
        //        TagEn, 
        //        Price,
        //        OtherPrice,
        //        SavePrice,
        //        Discount,
        //        CategoryID,
        //        ManufacturerID,
        //        OriginID,
        //        InStock,
        //        IsHot,
        //        IsNew,
        //        IsBestSeller,
        //        IsSafeOff,
        //        IsShowOnHomePage,
        //        Prioriy,
        //        IsAvailable,
        //        ErrorCodeParam);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
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
    }
}