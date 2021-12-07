using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.ComponentModel.DataAnnotations;


namespace QuoteGeneratorAPI.Models {

    public class QuoteGeneratorAdmin {

        // Database connection
        private MySqlConnection dbConnection; 
        private MySqlCommand dbCommand;
        private MySqlDataReader dbReader;

        private List<SelectListItem> _quotesList;
        private List<Quote> _quotes;
        private List<Quote> _randomQuotes;
        private List<Quote> _quotesToPick;
        private string _toDelete;
        // Initilization
        public QuoteGeneratorAdmin(){
            dbConnection = new MySqlConnection(Connection.CONNECTION_STRING);
            dbCommand = new MySqlCommand("", dbConnection); 
            _quotesList = new List<SelectListItem>();
            _quotes = new List<Quote>();
            _randomQuotes = new List<Quote>();
        }

        // ------------------------------------------------------- get/set methods
        public List<SelectListItem> QuotesList {
            get {
                return _quotesList;
            }
        }
        public List<Quote> Quotes {
            get {
                return _quotes;
            }
            set {
                _quotes = value;
            }
        }
        public List<Quote> RandomQuotes {get; set;}
        public List<Quote> QuotesToPick {get; set;}
        public string toDelete {get; set;}

        public int QuoteID {get; set;} = 0;

        [Key]
        public int id {get; set;}
        [Required]
        [MaxLength(100)]
        [Display(Name="Author")]
        public string author {get; set;}
        [Required]
        [Display(Name="Quote")]
        public string quote {get; set;}
        // regular expression for a link
        [RegularExpression(@"^https?://(www.)?[-a-zA-Z0-9@:%.+~#=]{1,256}.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%+.~#?&//=]*)$", ErrorMessage = "Invalid URL")]
        [Display(Name="Link")]
        public string permalink {get; set;}
        [Required]
        public string image {get; set;}

        // ------------------------------------------------------- Public methods
        // setup the web app
        public void setupMe() {
            getQuotesList();
        }
        // setup the jsop 
        public void setupMeJson() {
            populateQuotes();
        }
        public int quoteNumbers() {
            return _quotes.Count;
        }

        // delete the image file
        public void deleteImage(IWebHostEnvironment env, string filename){
            File.Delete(env.WebRootPath + "/" + filename);
        }
        // hit web api and get random quotes
        public object getRandomQuotes(int quoteNum){
            // Initialize Quotes to pick from
            _quotesToPick = _quotes;

            // if qoute number is higher than the number of quotes, set it to the number of quotes
            if(quoteNum > _quotes.Count){
                quoteNum = _quotes.Count;
            }
            // if quote number is 0 return empty json object
            if(quoteNum == 0){
                // return _randomquotes as empty json object
                return _randomQuotes;
            }

            // pick random quotes
            Random rnd = new Random();
            for (int i = 0; i < quoteNum; i++) {
                int index = rnd.Next(_quotesToPick.Count);
                _randomQuotes.Add(_quotesToPick[index]);
                _quotesToPick.RemoveAt(index);
            }



            Console.WriteLine("Quotes Count: " + _quotes.Count);
            Console.WriteLine("RandomQuotes Count: " + _randomQuotes.Count);
            return _randomQuotes;
        }

        // ------------------------------------------------------- Private methods
        // get the quotes to populate the dropdown list
        private void getQuotesList(){
            try {
                dbConnection.Open();
                dbCommand.CommandText = "SELECT * FROM tblQuotes";
                dbReader = dbCommand.ExecuteReader();

                while(dbReader.Read()){
                    SelectListItem item = new SelectListItem();
                    string quoteLength = dbReader["quote"].ToString();
                    if(quoteLength.Length > 100){
                        quoteLength = quoteLength.Substring(0, 100) + "...";
                    }
                    item.Text = quoteLength;
                    item.Value = Convert.ToString(dbReader["id"]);
                    _quotesList.Add(item);
                }
                dbReader.Close();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                dbConnection.Close();
            }
        }
        // populate the quotes    
        private void populateQuotes(){
            try {
                dbConnection.Open();
                dbCommand.CommandText = "SELECT * FROM tblQuotes";
                dbReader = dbCommand.ExecuteReader();
                while(dbReader.Read()){
                    Quote quote = new Quote();
                    quote.id = Convert.ToInt32(dbReader["id"]);
                    quote.quote = dbReader["quote"].ToString();
                    quote.author = dbReader["author"].ToString();
                    quote.permalink = dbReader["permalink"].ToString();
                    quote.image = dbReader["image"].ToString();
                    _quotes.Add(quote);
                }
                dbReader.Close();
            }
            catch (Exception ex) {
                Console.WriteLine("Populating Quotes Error ----- " + ex.Message);
            }
            finally {
                dbConnection.Close();
            }
        }

    }
}
