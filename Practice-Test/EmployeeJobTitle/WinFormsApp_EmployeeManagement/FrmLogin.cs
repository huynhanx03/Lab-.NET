using DataAccessLibrary.Repository;
using MyLibrabry.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp_EmployeeManagement
{
    public partial class FrmLogin : Form
    {
        public readonly IDbaccountRepository dbaccountRepository = new DbaccountRepository();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = TxtUsername.Text;
                string password = TxtPassword.Text;
                bool found = false;
                string error = "";
                if (username.Length == 0)
                {
                    found = true;
                    error += "Username is required.\n";
                }

                if (password.Length == 0)
                {
                    found = true;
                    error += "Password is required.\n";
                }

                if (found)
                {
                    MessageBox.Show(error, "Login-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    Dbaccount account = dbaccountRepository.CheckLogin(username, password);
                    if (account != null)
                    {
                        if (account.AccountRole.Value == 1)
                        {
                            FrmManagement frmManagement = new FrmManagement()
                            {
                                adminAccount = account,
                                frmLogin = this
                            };
                            frmManagement.Show();
                            this.Hide();
                        } else
                        {
                            MessageBox.Show("You are not allowed to access this function!", "Login-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } else
                    {
                        MessageBox.Show("You are not allowed to access this function!", "Login-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Login-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
