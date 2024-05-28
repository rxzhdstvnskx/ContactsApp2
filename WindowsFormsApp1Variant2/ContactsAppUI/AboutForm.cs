using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsApp1Variant2
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private static AboutForm AF;

        public static AboutForm AboutFormList
        {
            get
            {
                if (AF == null || AF.IsDisposed) AF = new AboutForm();
                return AF;
            }
        }
        public void ShowForm()
        {
            Show();
            Activate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AboutForm_Load(object sender, EventArgs e)
        {

        }
    }
}
