using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project_I.Models {
    
    public class GuestBook {
        
        // database variables
        private MySqlConnection dbConnection;
        private string connectionString;
        private MySqlCommand dbCommand;
        private MySqlDataReader dbReader;

        // property variables
        private List<Guests> _guests;
        private string date;
        private Boolean _check; 

        public GuestBook() {
            // construct database variables
            connectionString = "Enter String Here";
            dbConnection = new MySqlConnection(connectionString);
            dbCommand = new MySqlCommand("", dbConnection);

            // initialization
            _guests = new List<Guests>();
            date = DateTime.Now.ToString("M/d/yyyy");
            
        }

        // gets and sets
        public List<Guests> entrys {
            get {
                // reverse the list order to get bottom to top
                return _guests;
            }
        }
        public Boolean check {
            get {
                return _check;
            } set {
                _check = value;
            }
        }
        
        // public methods
        public void setUpMe() {
            getEntryData();
        }

        // private methods
        private void getEntryData() {
            try {
                // construct connection to connect to DB
                dbConnection.Open();
                dbCommand.CommandText = "SELECT * FROM tblGuests ORDER BY guestID DESC";

                dbReader = dbCommand.ExecuteReader();

                // loop through all records in the data reader
                while(dbReader.Read()) {
                    // populate the guests list
                    Guests guest = new Guests();
                    guest.firstName = Convert.ToString(dbReader["firstName"]);
                    guest.lastName = Convert.ToString(dbReader["lastName"]);
                    guest.date = Convert.ToString(dbReader["date"]);
                    guest.entry = Convert.ToString(dbReader["entry"]);

                    // add Guests object to the list
                    _guests.Add(guest);
                }
                dbReader.Close();

            } catch (Exception e) {
                Console.WriteLine("\n\nERROR WITH DB\n\n");
                Console.WriteLine(e.Message);
            } finally {
                dbConnection.Close();
            }
        }

        public void addEntry(string firstName, string lastName, string entry) {
            // test if both first and last name are null
            if (firstName == null && lastName == null) {
                firstName = "Anonymous";
                lastName = "NA";
            } 
            // test if firstName = null then set to NA
            if (firstName == null && lastName != null) {
                firstName = "NA";
            } 
            // test if lastName = null then set to NA
            if (firstName != null && lastName == null) {
                lastName = "NA";
            } 
            // if entry does not = null then the values are added to the database
            if (entry != null) {

                try {
                    dbConnection.Open();

                    dbCommand.Parameters.Clear();
                    dbCommand.CommandText = "INSERT INTO tblGuests (firstName,lastName,date,entry) VALUES (?firstName,?lastName,?date,?entry)";
                    dbCommand.Parameters.AddWithValue("?firstName", firstName);
                    dbCommand.Parameters.AddWithValue("?lastName", lastName);
                    dbCommand.Parameters.AddWithValue("?date", date);
                    dbCommand.Parameters.AddWithValue("?entry", entry);
                    dbCommand.ExecuteNonQuery();
                } catch (Exception e) {
                Console.WriteLine("\n\nERROR When Adding Record\n\n");
                Console.WriteLine(e.Message);
                } finally {
                    dbConnection.Close();
                }
            }
        }
    }
}
