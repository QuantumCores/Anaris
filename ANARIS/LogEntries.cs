using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANARIS
{
    public partial class LogEntries : Form, ANS_View
    {
        private ANS_Controller _controller;

        public LogEntries()
        {
            InitializeComponent();
            passTxt.UseSystemPasswordChar = true;
        }

        public void setController(ANS_Controller cont)
        {
            _controller = cont;
        }

        public void addEntries()
        {
            logBox.Clear();
            //if(_controller._log.LogEntry.Count != 0)
            foreach (string log in _controller._log.LogEntry)
            {
                logBox.Text += System.Environment.NewLine + log;
            }
        }

        private void reloadBtn_Click(object sender, EventArgs e)
        {
            if (passTxt.Text == "testy1234") { addEntries(); }
            
        }
    }
}
