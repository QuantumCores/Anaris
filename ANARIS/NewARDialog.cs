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
    public partial class NewARDialog: Form, ANS_View
    {
        ANS_Controller _controller;
        public ProjectProperties properties = new ProjectProperties();

        public NewARDialog()
        {
            InitializeComponent();
        }

        public void setController(ANS_Controller cont)
        {
            _controller = cont;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            properties = npbBasicInfo.GetTheProperties();            
            this.DialogResult = (properties == null) ? DialogResult.None: DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
