using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace QuoteGeneratorAPI.Models {
    
    public class Quote {
        
        // Database connection
        private MySqlConnection dbConnection;
        private MySqlCommand dbCommand;
        private MySqlDataReader dbReader;

        public Quote() {
            populateDefault();
        }

        // ------------------------------------------------------- get/set methods
        public int id {get; set;}
        public string author {get; set;}
        public string quote {get; set;}
        public string permalink {get; set;}
        public string image {get; set;}


        // ------------------------------------------------------- Public methods

        public int create() {
            try {
                dbConnection = new MySqlConnection(Connection.CONNECTION_STRING);
                dbConnection.Open();
                string sqlString = "INSERT INTO tblQuotes" + "(author, quote, permalink, image) VALUES " + "(?author, ?quote, ?permalink, ?image)";
                dbCommand = new MySqlCommand(sqlString, dbConnection);
                dbCommand.Parameters.AddWithValue("?author", author);
                dbCommand.Parameters.AddWithValue("?quote", quote);
                dbCommand.Parameters.AddWithValue("?permalink", permalink);
                dbCommand.Parameters.AddWithValue("?image", image);
                dbCommand.ExecuteNonQuery();
                dbCommand.Parameters.Clear();

                sqlString = "SELECT @@identity";
                dbCommand.CommandText = sqlString;
                id = Convert.ToInt32(dbCommand.ExecuteScalar());
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }
            finally {
                dbConnection.Close();
            }
            return id;
        } 


        public bool Delete() {
            if(id == 0) {
                return false;
            }
            else {
                try {
                    dbConnection = new MySqlConnection(Connection.CONNECTION_STRING);
                    dbConnection.Open();
                    string sqlString = "DELETE FROM tblQuotes WHERE id = ?id";
                    dbCommand = new MySqlCommand(sqlString, dbConnection);
                    dbCommand.Parameters.AddWithValue("?id", id);
                    dbCommand.ExecuteNonQuery();
                    populateDefault();
                }
                catch(Exception e) {
                    Console.WriteLine(e.Message);
                    return false;
                }
                finally {
                    dbConnection.Close();
                }
                return true;
            }
        }

        public string readImageName(int id) {
            try {
                dbConnection = new MySqlConnection(Connection.CONNECTION_STRING);
                dbConnection.Open();
                string sqlString = "SELECT image FROM tblQuotes WHERE id = ?id";
                dbCommand = new MySqlCommand(sqlString, dbConnection);
                dbCommand.Parameters.AddWithValue("?id", id);
                image = dbCommand.ExecuteScalar().ToString();
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }
            finally {
                dbConnection.Close();
            }
            // Console.WriteLine(image[1]);
            return image;
        }


        // ------------------------------------------------------- Private methods
        private void populateDefault() {
            id = 0;
            author = "";
            quote = "";
            permalink = "";
            image = "";
        }
    }

}