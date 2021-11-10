using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using QuoteGeneratorAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace QuoteGeneratorAPI.Controllers {

    public class QuoteAdminController : Controller {    
        private IWebHostEnvironment environment;
        public QuoteAdminController(IWebHostEnvironment env) {
            environment = env;
        }
        public IActionResult Index() {
            QuoteGeneratorAdmin quoteGeneratorAdmin = new QuoteGeneratorAdmin();
            quoteGeneratorAdmin.setupMe();
            return View(quoteGeneratorAdmin);
        }


        [HttpPost]
        public IActionResult AddQuote(QuoteGeneratorAdmin quoteGeneratorAdmin, IFormFile selectedFile, string author, string quote, string permalink) {
            quoteGeneratorAdmin.setupMe();
            Quote quoteCreate = new Quote();
            ImageUploader imageUploader = new ImageUploader(environment, "uploads");
            string date = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            Console.WriteLine(DateTimeOffset.Now.ToUnixTimeSeconds());
            int result = imageUploader.uploadImage(selectedFile, date);
            Console.WriteLine("Upload result: " + result);
            if (result == 5) {
                TempData["feedback"] = "Quote Succesfully added";
                quoteCreate.author = author;
                quoteCreate.quote = quote;
                quoteCreate.permalink = permalink;
                quoteCreate.image = "img_"+ date +"."+selectedFile.FileName.Split('.')[1];
                quoteCreate.create();
                return RedirectToAction("Index");
            } 
            else if (result == 0){
                TempData["feedback"] = "Image upload failed -- No File Selected";
            }
            else if (result == 1){
                TempData["feedback"] = "Image upload failed -- Incorrect File Type";
            }
            else if (result == 2){
                TempData["feedback"] = "Image upload failed -- File is too big";
            }
            else if (result == 3){
                TempData["feedback"] = "Image upload failed -- File name is too long";
            }
            else if (result == 4){
                TempData["feedback"] = "Image upload failed -- Error uploading image";
            }
            return View("Index", quoteGeneratorAdmin);
        }
        
        [HttpPost]
        public IActionResult DeleteQuote(QuoteGeneratorAdmin quoteGeneratorAdmin, string filename) {
            Quote quote = new Quote();
            quote.id = quoteGeneratorAdmin.QuoteID;
            string file = quote.readImageName(quoteGeneratorAdmin.QuoteID);
            bool success = quote.Delete();
            quoteGeneratorAdmin.deleteImage(environment, "uploads/"+file);
            return RedirectToAction("Index");
        }

        [Route("quotes/{quoteNum}")]
        public JsonResult RandomQuotes(QuoteGeneratorAdmin quoteGeneratorAdmin, int quoteNum){
            quoteGeneratorAdmin.setupMeJson();
            return Json(quoteGeneratorAdmin.getRandomQuotes(quoteNum));
        }

    }
}
