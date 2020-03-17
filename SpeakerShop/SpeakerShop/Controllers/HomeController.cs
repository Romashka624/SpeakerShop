using SpeakerShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SpeakerShop.Controllers
{
    public class HomeController : Controller
    {
                
        public ActionResult Index()
        {
           return View();
        }

        public ActionResult ShowProduct(string category, string SortProduct, int Page = 1)
        {
            int pageSize = 6;
            SpeakerContext db = new SpeakerContext();
            PageList list = new PageList();
            ViewBag.SelectedSortProduct = SortProduct;
            if(category != null)
            {
                switch (SortProduct)
                {
                    case "pricelow":
                        list.Speakers = db.Speakers
                            .Where(cat => cat.SpeakerCategory == category)
                            .OrderBy(Speaker => Speaker.Price)
                            .Skip((Page - 1) * pageSize)
                            .Take(pageSize);
                        break;
                    case "pricehight":
                        list.Speakers = db.Speakers
                            .Where(cat => cat.SpeakerCategory == category)
                            .OrderByDescending(Speaker => Speaker.Price)
                            .Skip((Page - 1) * pageSize)
                            .Take(pageSize);
                        break;
                    case "battery_capacitylow":
                        list.Speakers = db.Speakers
                            .Where(cat => cat.SpeakerCategory == category)
                            .OrderBy(Speaker => Speaker.BatteryCapaсity)
                            .Skip((Page - 1) * pageSize)
                            .Take(pageSize);
                        break;
                    case "battery_capacityhight":
                        list.Speakers = db.Speakers
                            .Where(cat => cat.SpeakerCategory == category)
                            .OrderByDescending(Speaker => Speaker.BatteryCapaсity)
                            .Skip((Page - 1) * pageSize)
                            .Take(pageSize);
                        break;
                    case "powerlow":
                        list.Speakers = db.Speakers
                            .Where(cat => cat.SpeakerCategory == category)
                            .OrderBy(Speaker => Speaker.Power)
                            .Skip((Page - 1) * pageSize)
                            .Take(pageSize);
                        break;
                    case "powerhight":
                        list.Speakers = db.Speakers
                            .Where(cat => cat.SpeakerCategory == category)
                            .OrderByDescending(Speaker => Speaker.Power)
                            .Skip((Page - 1) * pageSize)
                            .Take(pageSize);
                        break;
                    case "weightlow":
                        list.Speakers = db.Speakers
                            .Where(cat => cat.SpeakerCategory == category)
                            .OrderBy(Speaker => Speaker.Weight)
                            .Skip((Page - 1) * pageSize)
                            .Take(pageSize);
                        break;
                    case "weighthight":
                        list.Speakers = db.Speakers
                            .Where(cat => cat.SpeakerCategory == category)
                            .OrderByDescending(Speaker => Speaker.Weight)
                            .Skip((Page - 1) * pageSize)
                            .Take(pageSize);
                        break;
                    default:
                        list.Speakers = db.Speakers
                            .Where(cat => cat.SpeakerCategory == category)
                            .OrderBy(Speaker => Speaker.Id)
                            .Skip((Page - 1) * pageSize)
                            .Take(pageSize);
                        break;
                }
                
                list.pageInfo = new PageInfo
                {
                    CurrentPage = Page,
                    ItemsPerPage = pageSize,
                    TotalItems = db.Speakers.Where(speaker_category => speaker_category.SpeakerCategory == category).Count()
                };
                list.Currentcategory = category;
                list.SortCat = SortProduct;
            }
            else
            {
                switch (SortProduct)
                {
                    case "pricelow":
                        list.Speakers = db.Speakers
                            .OrderBy(Speaker => Speaker.Price)
                            .Skip((Page - 1) * pageSize)
                            .Take(pageSize);
                        break;
                    case "pricehight":
                        list.Speakers = db.Speakers
                            .OrderByDescending(Speaker => Speaker.Price)
                            .Skip((Page - 1) * pageSize)
                            .Take(pageSize);
                        break;
                    case "battery_capacitylow":
                        list.Speakers = db.Speakers
                            .OrderBy(Speaker => Speaker.BatteryCapaсity)
                            .Skip((Page - 1) * pageSize)
                            .Take(pageSize);
                        break;
                    case "battery_capacityhight":
                        list.Speakers = db.Speakers
                            .OrderByDescending(Speaker => Speaker.BatteryCapaсity)
                            .Skip((Page - 1) * pageSize)
                            .Take(pageSize);
                        break;
                    case "powerlow":
                        list.Speakers = db.Speakers
                            .OrderBy(Speaker => Speaker.Power)
                            .Skip((Page - 1) * pageSize)
                            .Take(pageSize);
                        break;
                    case "powerhight":
                        list.Speakers = db.Speakers
                            .OrderByDescending(Speaker => Speaker.Power)
                            .Skip((Page - 1) * pageSize)
                            .Take(pageSize);
                        break;
                    case "weightlow":
                        list.Speakers = db.Speakers
                            .OrderBy(Speaker => Speaker.Weight)
                            .Skip((Page - 1) * pageSize)
                            .Take(pageSize);
                        break;
                    case "weighthight":
                        list.Speakers = db.Speakers
                            .OrderByDescending(Speaker => Speaker.Weight)
                            .Skip((Page - 1) * pageSize)
                            .Take(pageSize);
                        break;
                    default:
                        list.Speakers = db.Speakers
                            .OrderBy(Speaker => Speaker.Id)
                            .Skip((Page - 1) * pageSize)
                            .Take(pageSize);
                        break;
                }
                list.pageInfo = new PageInfo
                {
                    CurrentPage = Page,
                    ItemsPerPage = pageSize,
                    TotalItems = db.Speakers.Count()
                };
                list.Currentcategory = category;
                list.SortCat = SortProduct;

            }

            return View(list);
        }

        public  ActionResult ShowSpeakerdetails(int id)
        {
            SpeakerContext db = new SpeakerContext();
            var model = db.Speakers.Where(Speaker => Speaker.Id == id);
            return View(model);
        }

        public PartialViewResult ShowCategories(string SortProduct, string category = null)
        {
            ViewBag.SelectedCategory = category;
            ViewBag.SortPr = SortProduct;
            SpeakerContext db = new SpeakerContext();
            var categories = db.Speakers
                            .Select(speaker => speaker.SpeakerCategory)
                            .Distinct()
                            .OrderBy(x => x);
            return PartialView(categories);
        }

        public ActionResult ProductEditing(string SearchString)
        {
            SpeakerContext db = new SpeakerContext();
            var speakers = db.Speakers;
            if (!String.IsNullOrEmpty(SearchString))
            {
                if(db.Speakers.Where(x => x.BrandName == SearchString).FirstOrDefault() != null)
                {
                    return View(db.Speakers.Where(x => x.BrandName == SearchString));
                }
                else
                {
                    return View(db.Speakers);
                }
            }
            else
            {
                return View(db.Speakers);
            }
        }

        public ViewResult Edit(int speakerid)
        {
            SpeakerContext db = new SpeakerContext();
            var speaker = db.Speakers
                .Where(sp => sp.Id == speakerid)
                .FirstOrDefault();
                
            return View(speaker);
        }

        [HttpPost]
        public ActionResult Edit(Speaker speaker, HttpPostedFileBase uploadFile)
        {
            SpeakerContext db = new SpeakerContext();
            string path = AppDomain.CurrentDomain.BaseDirectory + "images/";
            string filename = null;
            if (uploadFile != null)
            {
                filename = Path.GetFileName(uploadFile.FileName);
            }
            if (uploadFile != null && filename != speaker.Img)
            {
                System.IO.File.Delete(Path.Combine(path, speaker.Img));  
                uploadFile.SaveAs(Path.Combine(path, filename));
                speaker.Img = filename;
            }
            db.Entry(speaker).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ProductEditing");
        }

        [HttpGet]
        public ViewResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(Speaker speaker, HttpPostedFileBase uploadFile)
        {
            SpeakerContext db = new SpeakerContext();
            string path = AppDomain.CurrentDomain.BaseDirectory + "images/";
            string filename = Path.GetFileName(uploadFile.FileName);
            if (uploadFile != null)
            {
                uploadFile.SaveAs(Path.Combine(path, filename));
                speaker.Img = filename;
            }
            else
            {
                return View();
            }
            db.Speakers.Add(speaker);
            db.SaveChanges();
            return RedirectToAction("ProductEditing");
        }

        public ActionResult Delete(int speakerid)
        {
            SpeakerContext db = new SpeakerContext();
            string path = AppDomain.CurrentDomain.BaseDirectory + "images/";
            Speaker sp = db.Speakers.Find(speakerid);
            if(sp != null)
            {
                System.IO.File.Delete(Path.Combine(path, sp.Img));
                db.Speakers.Remove(sp);
                db.SaveChanges();
            }
            return RedirectToAction("ProductEditing");
        }

        public ViewResult ProductCart()
        {
            SpeakerContext db = new SpeakerContext();
            Cart cart = db.Carts.FirstOrDefault();
            if (cart != null)
            {
                ViewBag.SumPrice = db.Carts.Select(x => x.CartPrice).Sum();
                return View(db.Carts);
            }
            else
            {
                ViewBag.SumPrice = 0;
                return View(db.Carts);
            }
        }

        public ActionResult AddToCart(int id)
        {
            SpeakerContext db = new SpeakerContext();
            var speaker = db.Speakers
                .Where(sp => sp.Id == id)
                .FirstOrDefault();
            var addproduct = new Cart { 
                CartBrand = speaker.BrandName,
                CartModel = speaker.Model,
                CartImg = speaker.Img,
                CartColor = speaker.Color,
                CartPrice = speaker.Price
            };
            db.Carts.Add(addproduct);
            db.SaveChanges();
            return RedirectToAction("ShowProduct");
        }

        public ActionResult DeleteFromCart(int id)
        {
            SpeakerContext db = new SpeakerContext();
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("ProductCart");
        }

        public ActionResult PayNowCart()
        {
            SpeakerContext db = new SpeakerContext();
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Carts]");
            return RedirectToAction("ProductCart");
        }

    }
}