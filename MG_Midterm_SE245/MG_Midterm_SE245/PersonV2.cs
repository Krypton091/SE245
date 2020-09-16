using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MG_Midterm_SE245
{
    class PersonV2: Person
    {
        //**************************************************************************************
        //  NEW - Ultimate goal is to add a record, BUT first we need to connect to the DB
        //    So that is how we will start this process.
        //**************************************************************************************
        public string AddARecord()
        {
            //Init string var
            string strResult = "";

            //Make a connection object
            SqlConnection Conn = new SqlConnection();

            //Initialize it's properties
            Conn.ConnectionString = @"Server=sql.neit.edu\studentsqlserver,4500;Database=SE245_MGray;User Id=SE245_MGray;Password=008008029;";     //Set the Who/What/Where of DB


            //*******************************************************************************************************
            // NEW
            //*******************************************************************************************************
            string strSQL = "INSERT INTO Persons (FirstName, MiddleName, LastName, Street1, Street2, City, State, Zipcode, Phone, Email, Cellphone, Instagram) VALUES (@FirstName, @MiddleName, @LastName, @Street1, @Street2, @City, @State, @Zipcode, @Phone, @Email, @Cellphone, @Instagram)";
            // Bark out our command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;  //Commander knows what to say
            comm.Connection = Conn;     //Where's the phone?  Here it is

            //Fill in the paramters (Has to be created in same sequence as they are used in SQL Statement)
            comm.Parameters.AddWithValue("@FirstName", FName);
            comm.Parameters.AddWithValue("@MiddleName", MName);
            comm.Parameters.AddWithValue("@LastName", LName);
            comm.Parameters.AddWithValue("@Street1", Street1);
            comm.Parameters.AddWithValue("@Street2", Street2);
            comm.Parameters.AddWithValue("@City", City);
            comm.Parameters.AddWithValue("@State", State);
            comm.Parameters.AddWithValue("@Zipcode", Zipcode);
            comm.Parameters.AddWithValue("@Phone", Phone);
            comm.Parameters.AddWithValue("@Email", Email);
            comm.Parameters.AddWithValue("@Cellphone", Cellphone);
            comm.Parameters.AddWithValue("@Instagram", InstagramURL);

            //*******************************************************************************************************





            //attempt to connect to the server
            try
            {
                Conn.Open();                                        //Open connection to DB - Think of dialing a friend on phone
                int intRecs = comm.ExecuteNonQuery();
                strResult = $"SUCCESS: Inserted {intRecs} records.";       //Report that we made the connection and added a record
                Conn.Close();                                       //Hanging up after phone call
            }
            catch (Exception err)                                   //If we got here, there was a problem connecting to DB
            {
                strResult = "ERROR: " + err.Message;                //Set feedback to state there was an error & error info
            }
            finally
            {

            }



            //Return resulting feedback string
            return strResult;
        }
    }
}
