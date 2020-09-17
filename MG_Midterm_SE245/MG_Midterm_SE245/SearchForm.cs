using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MG_Midterm_SE245
{
    public partial class SearchForm : Form
    {
        public SearchForm()
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
            PersonV2 temp = new PersonV2();
            //Perform the search we created in EBook class and store the returned dataset
            DataSet ds = temp.SearchPersons(txtFName.Text, txtMName.Text, txtLName.Text, txtStreet1.Text, txtStreet2.Text, txtCity.Text, txtState.Text, txtZipcode.Text, txtPhone.Text, txtEmail.Text, txtCellphone.Text, txtInstagram.Text);

            //Display data (dataset)
            dgvResults.DataSource = ds;                                  //point datagrid to dataset
            dgvResults.DataMember = ds.Tables["Persons_Temp"].ToString();     // What table in the dataset?
        }

        private void dgvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Gather the information (Gathers the row clicked, then chooses the first cell's data
            string strPerson_ID = dgvResults.Rows[e.RowIndex].Cells[0].Value.ToString();

            //Display data in Pop-up
            MessageBox.Show(strPerson_ID);

            //Convert the string over to an integer
            int intPerson_ID = Convert.ToInt32(strPerson_ID);

            //Create the editor form, passing it one EBook's ID and show it
            // NOTE THAT THE ID BEING PASSED WILL CALL THE OVERLOADED VERSION
            // OF THE CONSTRUCTOR...TELL IT, IN ESSENCE THAT WE ARE PULLING UP
            // RATHER THAN ADDING DATA 
            Form1 Editor = new Form1(intPerson_ID);
            Editor.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void SearchForm_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
