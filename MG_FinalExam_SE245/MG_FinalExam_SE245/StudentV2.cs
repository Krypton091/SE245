using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MG_FinalExam_SE245
{
    class StudentV2:Student
    {

        private int student_ID;

        public Int32 Student_ID
        {
            get
            {
                return student_ID;
            }

            set
            {
                if (value > 0)
                {
                    student_ID = value;
                }
                else
                {

                    feedback += "\nERROR: Sorry, you have entered an invalid Student ID.";
                }
            }
        }

        public string AddARecord()
        {
            //Init string var
            string strResult = "";

            //Make a connection object
            SqlConnection Conn = new SqlConnection();

            //Initialize it's properties
            Conn.ConnectionString = @GetConnected();     //Set the Who/What/Where of DB


            //Insert all values into the SQL Database
            string strSQL = "INSERT INTO Students (FirstName, LastName, GPA, Credits, DOB) VALUES (@FirstName, @LastName, @GPA, @Credits, @DOB)";
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;
            comm.Connection = Conn;

            //Fill in the paramters
            comm.Parameters.AddWithValue("@FirstName", FName);
            comm.Parameters.AddWithValue("@LastName", LName);
            comm.Parameters.AddWithValue("@GPA", GPA);
            comm.Parameters.AddWithValue("@Credits", Credits);
            comm.Parameters.AddWithValue("@DOB", DOB);

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

        public DataSet SearchStudents(String FName, String LName, String GPA, String Credits, String DOB)
        {
            //Create a dataset to return filled
            DataSet ds = new DataSet();


            //Create a command for our SQL statement
            SqlCommand comm = new SqlCommand();


            //Write a Select Statement to perform Search
            String strSQL = "SELECT StudentID, FirstName, LastName, GPA, Credits, DOB FROM Students WHERE 0=0";

            //If the First/Last Name is filled in include it as search criteria
            if (FName.Length > 0)
            {
                strSQL += " AND FirstName LIKE @FirstName";
                comm.Parameters.AddWithValue("@FirstName", FName + "%");
            }
            if (LName.Length > 0)
            {
                strSQL += " AND LastName LIKE @LastName";
                comm.Parameters.AddWithValue("@LastName", LName + "%");
            }
            if (GPA.Length > 0)
            {
                strSQL += " AND GPA LIKE @GPA";
                comm.Parameters.AddWithValue("@GPA", GPA + "%");
            }
            if (Credits.Length > 0)
            {
                strSQL += " AND Credits LIKE @Credits";
                comm.Parameters.AddWithValue("@Credits", Credits + "%");
            }
            if (DOB.Length > 0)
            {
                strSQL += " AND DOB >= @DOB AND DOB <= @DOB";
                comm.Parameters.AddWithValue("@DOB", DOB);
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
            da.Fill(ds, "Students_Temp");     //Fill the dataset with results from database and call it "Persons_Temp"
            conn.Close();               //Close the connection (hangs up phone)

            //Return the data
            return ds;
        }

        public SqlDataReader FindOnePerson(int intStudent_ID)
        {
            //Create and Initialize the DB Tools we need
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //My Connection String
            string strConn = GetConnected();

            //My SQL command string to pull up one EBook's data
            string sqlString =
           "SELECT * FROM Students WHERE StudentID = @StudentID;";

            //Tell the connection object the who, what, where, how
            conn.ConnectionString = strConn;

            //Give the command object info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@StudentID", intStudent_ID);

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
            string strSQL = "UPDATE Students SET FirstName = @FirstName, LastName = @LastName, GPA = @GPA, Credits = @Credits, DOB = @DOB WHERE StudentID = @StudentID;";

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
            comm.Parameters.AddWithValue("@LastName", LName);
            comm.Parameters.AddWithValue("@GPA", GPA);
            comm.Parameters.AddWithValue("@Credits", Credits);
            comm.Parameters.AddWithValue("@DOB", DOB);
            comm.Parameters.AddWithValue("@StudentID", Student_ID);

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

        public string DeleteOnePerson(int intStudent_ID)
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
           "DELETE FROM Students WHERE StudentID = @StudentID;";

            //Tell the connection object the who, what, where, how
            conn.ConnectionString = strConn;

            //Give the command object info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@StudentID", intStudent_ID);

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
