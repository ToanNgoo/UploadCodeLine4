using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CONTROL_ROBOT
{
    public partial class Form_Login : Form
    {
        public int count1;
        public bool login_status = false;
        private string User_Account;
        private string Usser_Pass;
        private string Admin_Account;
        private string Admin_Pass;
        private bool USER_CHOICE = false;
        private bool ADMIN_CHOICE = false;
        public bool parameter = false;

        public Form_Login()
        {
            InitializeComponent();
            txt_pass.UseSystemPasswordChar = true;
            txt_pass.Text = "1";
            txt_user.Text = "1";
            LoadAccount();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (login_status == false)
            {
                if (cbxModeLogin.Text == "USER")
                {
                    if ((txt_user.Text == User_Account) && (txt_pass.Text == Usser_Pass))
                    {
                        login_status = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu, hãy thử lại sau.", "Thông báo lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txt_user.Focus();
                    }
                }
                if (cbxModeLogin.Text == "ADMIN")
                {
                    if ((txt_user.Text == Admin_Account) && (txt_pass.Text == Admin_Pass))
                    {
                        MessageBox.Show("Admin đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        login_status = true;
                        parameter = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu, hãy thử lại sau.", "Thông báo lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txt_user.Focus();
                    }
                }




                //else if ((txt_user.Text == "1") && (txt_pass.Text == "1"))
                //{
                //    login_status = true;
                //    this.Close();
                //    parameter = true;


                //}

            }
            else
            {
                login_status = false;
                parameter = false;
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
            login_status = false;
        }

        private void btn_viewPass_MouseDown(object sender, MouseEventArgs e)
        {
            txt_pass.UseSystemPasswordChar = false;
        }

        private void btn_viewPass_MouseUp(object sender, MouseEventArgs e)
        {
            txt_pass.UseSystemPasswordChar = true;
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            login_status = false;
            LoadAccount();
            txt_user.Text = User_Account;
            txt_pass.Text = Usser_Pass;
        }

        private void CreateAccount(TextBox Account, TextBox Pass)
        {
            FileStream ProductionQty = new FileStream(Application.StartupPath + @"\InfoAccount.ini", FileMode.Create);

            using (StreamWriter ProductionQtyWrite = new StreamWriter(ProductionQty))
            {
                if (USER_CHOICE)
                {
                    ProductionQtyWrite.WriteLine("USER_ACCOUNT=" + Account.Text);
                    ProductionQtyWrite.WriteLine("USER_PASS=" + Pass.Text);
                }


                if (ADMIN_CHOICE)
                {
                    ProductionQtyWrite.WriteLine("ADMIN_USER=" + Account.Text);
                    ProductionQtyWrite.WriteLine("ADMIN_PASS=" + Pass.Text);
                    ProductionQtyWrite.Close();
                }

            }
        }
        private void LoadAccount()
        {
            try
            {
                string[] data = null;
                string str = "";
                FileStream FS = new FileStream(Application.StartupPath + @"\InfoAccount.ini", FileMode.Open);
                StreamReader CounterRead = new StreamReader(FS);
                while (CounterRead.EndOfStream == false)
                {
                    str = CounterRead.ReadLine();
                    data = str.Split('=');

                    switch (data[0])
                    {
                        case "USER_ACCOUNT":
                            User_Account = data[1];
                            break;
                        case "USER_PASS":
                            Usser_Pass = data[1];
                            break;
                        case "ADMIN_USER":
                            Admin_Account = data[1];
                            break;
                        case "ADMIN_PASS":
                            Admin_Pass = data[1];
                            break;

                        default:
                            break;
                    }
                }
                CounterRead.Close();
                FS.Close();

            }
            catch
            {

            }
        }

        private void Form_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            //CreateAccount(txt_user, txt_pass);
        }











    }
}
