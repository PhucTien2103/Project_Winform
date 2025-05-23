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
    public partial class ForgotForm : Form
    {
        private string currentToken;
        public ForgotForm()
        {
            InitializeComponent();
            txtNewPassword.UseSystemPasswordChar = true;
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập email.");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ.");
                return;
            }

            string token = BSUser.SendResetCode(email);
            if (token == null)
            {
                MessageBox.Show("Email không tồn tại.");
            }
            else
            {
                currentToken = token;
                MessageBox.Show("Mã xác thực đã được gửi đến mail của bạn");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string token = txtVerify.Text.Trim().ToUpper();
            string newPass = txtNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token) || string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            if (BSUser.ResetPassword(email, token, newPass))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Mã xác thực không hợp lệ hoặc đã hết hạn.");
            }
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool show = chkPassword.Checked;
            txtNewPassword.UseSystemPasswordChar = !show;
        }

        private void ForgotForm_Load(object sender, EventArgs e)
        {

        }
    }
}
