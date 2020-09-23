using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MG_FinalExam_SE245
{
    public partial class SearchRecord : Form
    {
        public SearchRecord()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Get Data
            StudentV2 temp = new StudentV2();
            //Perform the search we created in EBook class and store the returned dataset
            DataSet ds = temp.SearchStudents(txtFName.Text, txtLName.Text, txtGPA.Text, txtCredits.Text, txtDOB.Text);

            //Display data (dataset)
            dgvResults.DataSource = ds;                                  //point datagrid to dataset
            dgvResults.DataMember = ds.Tables["Students_Temp"].ToString();     // What table in the dataset?
        }

        private void dgvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Ask the user for confirmation on viewing the record
            DialogResult dialogResult = MessageBox.Show("View the record for " + dgvResults.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + dgvResults.Rows[e.RowIndex].Cells[2].Value.ToString() + "?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Gather the information (Gathers the row clicked, then chooses the first cell's data
                string strStudent_ID = dgvResults.Rows[e.RowIndex].Cells[0].Value.ToString();


                //Convert the string over to an integer
                int intStudent_ID = Convert.ToInt32(strStudent_ID);

                //Create the editor form, passing it one EBook's ID and show it
                // NOTE THAT THE ID BEING PASSED WILL CALL THE OVERLOADED VERSION
                // OF THE CONSTRUCTOR...TELL IT, IN ESSENCE THAT WE ARE PULLING UP
                // RATHER THAN ADDING DATA 
                AddRecord Editor = new AddRecord(intStudent_ID);
                Editor.ShowDialog();
            }
            else if (dialogResult == DialogResult.No)
            {
                //Do nothing since the user canceled the action
            }

            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void SearchRecord_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dgvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
