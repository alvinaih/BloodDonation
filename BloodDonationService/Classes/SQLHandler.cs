using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationService.Classes
{
    public class SQLHandler
    {
        //getter setter properties
        //Acts as a Data carrier for our Application

        public int UserID { get; set; }
        public string FullName { get; set; }
        public int IDNumber { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Location { get; set; }
        public bool Newsletter { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string myVHelsingString = ConfigurationManager.ConnectionStrings["VanHelsingDB"].ConnectionString;


        public bool Insert(SQLHandler sh)
        {
            //create a default return type and setting its value to false
            bool isSuccess = true;

            //Connect to the Database 
            SqlConnection conn = new SqlConnection(myVHelsingString);
            try
            {
                //create a query to insert data
                string sqlQuery = "INSERT INTO UserReg(UserID, FullName, IDNumber, Email, Contact, Loctaion, Newsletter, Username, Password) VALUES(@UserID, @FullName, @IDNumber, @Email, @Contact, @Loctaion, @Newsletter, @Username, @Password)";

                //create a sqlCommand using sql and conn
                SqlCommand sqlCom = new SqlCommand(sqlQuery, conn);

                //create the parameters to add the data
                sqlCom.Parameters.AddWithValue("@UserID", sh.UserID);
                sqlCom.Parameters.AddWithValue("@FullName", sh.FullName);
                sqlCom.Parameters.AddWithValue("@IDNumber", sh.IDNumber);
                sqlCom.Parameters.AddWithValue("@Email", sh.Email);
                sqlCom.Parameters.AddWithValue("@Contact", sh.Contact);
                sqlCom.Parameters.AddWithValue("@Location", sh.Location);
                sqlCom.Parameters.AddWithValue("@Newsletter", sh.Newsletter);
                sqlCom.Parameters.AddWithValue("@Username", sh.Username);
                sqlCom.Parameters.AddWithValue("@Password", sh.Password);

                //connect open here
                conn.Open();

                //if the query runs successfully then the value of the rows will be greater than zero else its value will be 0

                int rows = sqlCom.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }


            return isSuccess;

        }


    }
}
