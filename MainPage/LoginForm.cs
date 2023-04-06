using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPage
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (PassWordTextEdit.Text == "123" && textEdit1.Text == "Admin")
            {

                MasterList masterList = new MasterList();
                masterList.Show();

            }
            else
            {
                MessageBox.Show("حطاء في ادخال كلمة المرور");
            }
        }
    }
}