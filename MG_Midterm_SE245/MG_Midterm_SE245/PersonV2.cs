using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MG_Midterm_SE245
{
    class PersonV2 : Person
    {

        private int person_ID;

        public Int32 Person_ID
        {
            get
            {
                return person_ID;
            }

            set
            {
                if (value > 0)
                {
                    person_ID = value;
                }
                else
                {

                    feedback += "\nERROR: Sorry you entered an invalid Person ID.";
                }
            }
        }


        //Connect to SQL Database
        public string AddARecord()
        {
            //Init string var
            string strResult = "";

            //Make a connection object
            SqlConnection Conn = new SqlConnection();

            //Initialize it's properties
            Conn.ConnectionString = @GetConnected();     //Set the Who/What/Where of DB


            //Insert all values into the SQL Database
            string strSQL = "INSERT INTO Persons (FirstName, MiddleName, LastName, Street1, Street2, City, State, Zipcode, Phone, Email, Cellphone, Instagram) VALUES (@FirstName, @MiddleName, @LastName, @Street1, @Street2, @City, @State, @Zipcode, @Phone, @Email, @Cellphone, @Instagram)";
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;
            comm.Connection = Conn;

            //Fill in the paramters
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

        public DataSet SearchPersons(String FName, String MName, String LName, String Street1, String Street2, String City, String State, String Zipcode, String Phone, String Email, String Cellphone, String Instagram)
        {
            //Create a dataset to return filled
            DataSet ds = new DataSet();


            //Create a command for our SQL statement
            SqlCommand comm = new SqlCommand();


            //Write a Select Statement to perform Search
            String strSQL = "SELECT Person_ID, FirstName, MiddleName, LastName, Street1, Street2, City, State, Zipcode, Phone, Email, Cellphone, Instagram FROM Persons WHERE 0=0";

            //If the First/Last Name is filled in include it as search criteria
            if (FName.Length > 0)
            {
                strSQL += " AND FirstName LIKE @FirstName";
                comm.Parameters.AddWithValue("@FirstName", "%" + FName + "%");
            }
            if (MName.Length > 0)
            {
                strSQL += " AND MiddleName LIKE @MiddleName";
                comm.Parameters.AddWithValue("@MiddleName", "%" + MName + "%");
            }
            if (LName.Length > 0)
            {
                strSQL += " AND LastName LIKE @LastName";
                comm.Parameters.AddWithValue("@LastName", "%" + LName + "%");
            }
            if (Street1.Length > 0)
            {
                strSQL += " AND Street1 LIKE @Street1";
                comm.Parameters.AddWithValue("@Street1", "%" + Street1 + "%");
            }
            if (Street2.Length > 0)
            {
                strSQL += " AND Street2 LIKE @Street2";
                comm.Parameters.AddWithValue("@Street2", "%" + Street2 + "%");
            }
            if (City.Length > 0)
            {
                strSQL += " AND City LIKE @City";
                comm.Parameters.AddWithValue("@City", "%" + City + "%");
            }
            if (State.Length > 0)
            {
                strSQL += " AND State LIKE @State";
                comm.Parameters.AddWithValue("@State", "%" + State + "%");
            }
            if (Zipcode.Length > 0)
            {
                strSQL += " AND Zipcode LIKE @Zipcode";
                comm.Parameters.AddWithValue("@Zipcode", "%" + Zipcode + "%");
            }
            if (Phone.Length > 0)
            {
                strSQL += " AND Phone LIKE @Phone";
                comm.Parameters.AddWithValue("@Phone", "%" + Phone + "%");
            }
            if (Email.Length > 0)
            {
                strSQL += " AND Email LIKE @Email";
                comm.Parameters.AddWithValue("@Email", "%" + Email + "%");
            }
            if (Cellphone.Length > 0)
            {
                strSQL += " AND Cellphone LIKE @Cellphone";
                comm.Parameters.AddWithValue("@Cellphone", "%" + Cellphone + "%");
            }
            if (Instagram.Length > 0)
            {
                strSQL += " AND Instagram LIKE @Instagram";
                comm.Parameters.AddWithValue("@Instagram", "%" + Instagram + "%");
            }


            //Create DB tools and Configure
            //*********************************************************************************************
            SqlConnection conn = new SqlConnection();
            //Create the who, what where of the DB
            string strConn = @GetConnected();
            conn.ConnectionString = strConn;

            //Fill in basic info to command object
            comm.Connection = conn;     //tell the commander what connection to use
            comm.CommandText = strSQL;  //tell the command what to say

            //Create Data Adapter
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;    //commander needs a translator(dataAdapter) to speak with datasets

            //*********************************************************************************************

            //Get Data
            conn.Open();                //Open the connection (pick up the phone)
            da.Fill(ds, "Persons_Temp");     //Fill the dataset with results from database and call it "Persons_Temp"
            conn.Close();               //Close the connection (hangs up phone)

            //Return the data
            return ds;
        }

        //NEW  - Method that returns a Data Reader filled with all the data
        // of one EBook.  This one EBook is specified by the ID passed
        // to this function
        public SqlDataReader FindOnePerson(int intPerson_ID)
        {
            //Create and Initialize the DB Tools we need
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //My Connection String
            string strConn = GetConnected();

            //My SQL command string to pull up one EBook's data
            string sqlString =
           "SELECT * FROM Persons WHERE Person_ID = @Person_ID;";

            //Tell the connection object the who, what, where, how
            conn.ConnectionString = strConn;

            //Give the command object info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@Person_ID", intPerson_ID);

            //Open the DataBase Connection and Yell our SQL Command
            conn.Open();

            //Return some form of feedback
            return comm.ExecuteReader();   //Return the dataset to be used by others (the calling form)

        }

        public string UpdateARecord()
        {
            Int32 intRecords = 0;
            string strResult = "";

            //Create SQL command string
            string strSQL = "UPDATE Persons SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, Street1 = @Street1, Street2=@Street2, City=@City, State=@State, Zipcode=@Zipcode, Phone=@Phone, Email=@Email, Cellphone=@Cellphone, Instagram=@Instagram  WHERE Person_ID = @Person_ID;";

            // Create a connection to DB
            SqlConnection conn = new SqlConnection();
            //Create the who, what where of the DB
            string strConn = GetConnected();
            conn.ConnectionString = strConn;

            // Bark out our command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;  //Commander knows what to say
            comm.Connection = conn;     //Where's the phone?  Here it is

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
            comm.Parameters.AddWithValue("@Person_ID", Person_ID);

            try
            {
                //Open the connection
                conn.Open();

                //Run the Update and store the number of records effected
                intRecords = comm.ExecuteNonQuery();
                strResult = intRecords.ToString() + " Records Updated.";
            }
            catch (Exception err)
            {
                strResult = "ERROR: " + err.Message;                //Set feedback to state there was an error & error info
            }
            finally
            {
                //close the connection
                conn.Close();
            }

            return strResult;

        }

        public string DeleteOnePerson(int intPerson_ID)
        {
            Int32 intRecords = 0;
            string strResult = "";

            //Create and Initialize the DB Tools we need
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //My Connection String
            string strConn = GetConnected();

            //My SQL command string to pull up one EBook's data
            string sqlString =
           "DELETE FROM Persons WHERE Person_ID = @Person_ID;";

            //Tell the connection object the who, what, where, how
            conn.ConnectionString = strConn;

            //Give the command object info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@Person_ID", intPerson_ID);

            try
            {
                //Open the connection
                conn.Open();

                //Run the Delete and store the number of records effected
                intRecords = comm.ExecuteNonQuery();
                strResult = intRecords.ToString() + " Records Deleted.";
            }
            catch (Exception err)
            {
                strResult = "ERROR: " + err.Message;                //Set feedback to state there was an error & error info
            }
            finally
            {
                //close the connection
                conn.Close();
            }

            return strResult;


        }

        private string GetConnected()
        {
            return "Server=sql.neit.edu\\studentsqlserver,4500;Database=SE245_MGray;User Id=SE245_MGray;Password=008008029;";
        }
    }
}
