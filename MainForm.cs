using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessManagerApp
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpenProcesses_Click(object sender, EventArgs e)
        {
            Form1 processForm = new Form1();
            processForm.Show();
        }

        private void btnOpenLogs_Click(object sender, EventArgs e)
        {
            EventLogForm logForm = new EventLogForm();
            logForm.Show();
        }


    }
}
