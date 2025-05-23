using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DoAnCKver1.BSLayer;

namespace DoAnCKver1
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ.");
                return;
            }

            bool ok = BSUser.Register(username, email, password);
            if (ok)
            {
                MessageBox.Show("Đăng ký thành công.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc email đã tồn tại.");
            }
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool show = chkPassword.Checked;
            txtPassword.UseSystemPasswordChar = !show;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
