using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;

namespace userAuthenticationApp.Models {

	public class WebLogin {
		// private variables
		private MySqlConnection dbConnection;
		private string connectionString;
		private MySqlCommand dbCommand;
		private MySqlDataReader dbReader;
		private string tableName;
		private HttpContext context;

		private string _username;
		private string _password;
		private bool _access;

		public WebLogin(string myConnectionString, string dbTableName, HttpContext appContext) {
			
			connectionString = myConnectionString;
			tableName = dbTableName;
			context = appContext;
			_username = "";
			_password = "";
			_access = false;

			// clear the session
			context.Session.Clear();
		}

		// ------------------------------------------------------- Get/Set
		public string username {
			set {
				_username = value;
			}
		}

		public string password {
			set {
				_password = value;
			}
		}

		public bool access {
			get {
				return _access;
			}
		}

		// ------------------------------------------------------- public methods
		public bool unlock() {
			_access = false;

			// trim to 10 char
			_username = truncate(_username, 10);
			_password = truncate(_password, 10);

			// is login valid
			try {
				dbConnection = new MySqlConnection(connectionString);
				dbConnection.Open();
				dbCommand = new MySqlCommand("SELECT password, salt FROM " + tableName + " WHERE username=?username", dbConnection);

				dbCommand.Parameters.AddWithValue("?username", _username);
				dbReader = dbCommand.ExecuteReader();

				// does username exist
				if(!dbReader.HasRows) return _access;

				// move to first record
				dbReader.Read();
				// hash and salt password
				string hashedPassword = getHashed(_password, dbReader["salt"].ToString());
				if (hashedPassword == dbReader["password"].ToString()) {
					_access = true;
					// store session
					context.Session.SetString("auth", "true");
					context.Session.SetString("user", _username);
				}


			} finally {
				dbConnection.Close();
			}

			return _access;
		}

		// ------------------------------------------------------- private methods
		private string truncate(string value, int length) {
			return value.Length <= length ? value : value.Substring(0, length);
		}
		
		private string getSalt() {
			// generate a 128-bit salt using a secure PRNG (pseudo-random number generator)
			byte[] salt = new byte[128 / 8];
			using (var rng = RandomNumberGenerator.Create()) {
				rng.GetBytes(salt);
			}
			//Console.WriteLine(">>> Salt: " + Convert.ToBase64String(salt));

			return Convert.ToBase64String(salt);
		}

		private string getHashed(string myPassword, string mySalt) {
			// convert string to Byte[] for hashing
			byte[] salt = Convert.FromBase64String(mySalt);
	
			// hashing done using PBKDF2 algorithm
			// derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
			string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
				password: myPassword,
				salt: salt,
				prf: KeyDerivationPrf.HMACSHA1,
				iterationCount: 10000,
				numBytesRequested: 256 / 8));
			//Console.WriteLine(">>> Hashed: " + hashed);

			return hashed;
		}

	}
}