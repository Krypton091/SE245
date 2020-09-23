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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            AddRecord temp = new AddRecord();
            temp.Show();
        }

        private void btnSearchRecord_Click(object sender, EventArgs e)
        {
            SearchRecord temp = new SearchRecord();
            temp.Show();
        }
    }
}
