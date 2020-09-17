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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void Start_Load(object sender, EventArgs e)
        {

        }

        private void chooseSearch_Click(object sender, EventArgs e)
        {
            //Create a new instance of SearchMgr (Search form) and make it visible (show)
            SearchForm temp = new SearchForm();
            temp.Show();
        }

        private void chooseAdd_Click(object sender, EventArgs e)
        {
            Form1 temp = new Form1();
            temp.Show();
        }
    }
}
