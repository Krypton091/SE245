using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MG_FinalExam_SE245
{
    public partial class AddRecord : Form
    {
        public AddRecord()
        {
            InitializeComponent();

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            lblStudent.Visible = false;
        }

        public AddRecord(int intStudent_ID)
        {
            InitializeComponent();

            btnSubmit.Visible = false;

            //Gather info about this one person and store it in a datareader
            StudentV2 temp = new StudentV2();
            SqlDataReader dr = temp.FindOnePerson(intStudent_ID);

            //Use that info to fill out the form
            //Loop thru the records stored in the reader 1 record at a time
            // Note that since this is based on one person's ID, then we
            //  should only have one record
            while (dr.Read())
            {
                //Take the Name(s) from the datareader and copy them
                // into the appropriate text fields
                txtfName.Text = dr["FirstName"].ToString();
                txtlName.Text = dr["LastName"].ToString();
                txtgpa.Text = dr["GPA"].ToString();
                txtcredits.Text = dr["Credits"].ToString();
                dateTimePicker1.Text = dr["DOB"].ToString();


                //We added this one to store the ID in a new label
                lblStudent_ID.Text = dr["StudentID"].ToString();
            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            StudentV2 temp = new StudentV2();
            temp.FName = txtfName.Text;
            temp.LName = txtlName.Text;
            temp.DOB = dateTimePicker1.Value.Date;

            int intTempCredits;
            bool blnCredits = Int32.TryParse(txtcredits.Text, out intTempCredits);

            if (blnCredits == false)
            {
                lblFeedback.Text += "Invalid Credits.  Please try again. (Ex: 3.40) ";
            }
            else
            {
                temp.Credits = intTempCredits;
            }

            double dblTempGPA;
            bool blnResult = Double.TryParse(txtgpa.Text, out dblTempGPA);

            if (blnResult == false)
            {
                lblFeedback.Text += "Invalid GPA.  Please try again. (Ex: 3.40) ";
            }
            else
            {
                temp.GPA = dblTempGPA;
            }

            if (temp.Feedback.Contains("ERROR:"))
            {
                lblFeedback.Text = temp.Feedback;
            }
            else
            {
                lblFeedback.Text = "New person" + " \"" + temp.FName + " " + temp.LName + "\" has been succesfully added";
                lblFeedback.Text = temp.AddARecord();
            }
        }

        private void lblFeedback_Click(object sender, EventArgs e)
        {

        }

        private void AddRecord_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            StudentV2 temp = new StudentV2();

            //Getting the strings from the form and setting them in object
            temp.FName = txtfName.Text;
            temp.LName = txtlName.Text;
            temp.DOB = dateTimePicker1.Value.Date;

            int intTempCredits;
            bool blnCredits = Int32.TryParse(txtcredits.Text, out intTempCredits);

            if (blnCredits == false)
            {
                lblFeedback.Text += "Invalid Credits.  Please try again. (Ex: 3.40) ";
            }
            else
            {
                temp.Credits = intTempCredits;
            }

            

            double dblTempGPA;
            bool blnGPA = Double.TryParse(txtgpa.Text, out dblTempGPA);

            if (blnGPA == false)
            {
                lblFeedback.Text += "Invalid GPA.  Please try again. (Ex: 3.40) ";
            }
            else
            {
                temp.GPA = dblTempGPA;
            }

            temp.Student_ID = Convert.ToInt32(lblStudent_ID.Text);

            if (!temp.Feedback.Contains("ERROR:"))
            {
                lblFeedback.Text = temp.UpdateARecord();   //if no errors weh setting values, then perform the insertion into db
            }
            else
            {
                lblFeedback.Text = temp.Feedback;       //else...dispay the error msg
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Ask user for confirmation on deleting the record
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Delete Record?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Int32 intStudent_ID = Convert.ToInt32(lblStudent_ID.Text);  //Get the ID from the Label

                //Create a EBook so we can use the delete method
                StudentV2 temp = new StudentV2();

                //Use the EBook ID and pass it to the delete function
                // and get the number of records deleted
                lblFeedback.Text = temp.DeleteOnePerson(intStudent_ID);
            }
            else if (dialogResult == DialogResult.No)
            {
                //Do nothing
            }
            
        }
    }
}
