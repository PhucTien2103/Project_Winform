using System;
using System.Windows.Forms;
using DoAnCKver1.BSLayer;
using DoAnCKver1.Model;

namespace DoAnCKver1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;

            // Đặt kích thước tối thiểu cho form để đảm bảo đủ không gian hiển thị
            this.MinimumSize = new System.Drawing.Size(350, 200);

            // Thêm RadioButton vào giao diện bằng code
            InitializeRadioButtons();
        }

        private void InitializeRadioButtons()
        {
            // Tạo RadioButton cho Admin
            RadioButton rdoAdmin = new RadioButton
            {
                Text = "Admin",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(80, 20),
                Name = "rdoAdmin"
            };

            // Tạo RadioButton cho Employee
            RadioButton rdoEmployee = new RadioButton
            {
                Text = "Employee",
                Location = new System.Drawing.Point(100, 20),
                Size = new System.Drawing.Size(80, 20),
                Name = "rdoEmployee"
            };

            // Tạo RadioButton cho Customer
            RadioButton rdoCustomer = new RadioButton
            {
                Text = "Customer",
                Location = new System.Drawing.Point(180, 20),
                Size = new System.Drawing.Size(80, 20),
                Name = "rdoCustomer",
                Checked = true // Mặc định chọn Customer
            };

            // Thêm RadioButton vào form
            this.Controls.Add(rdoAdmin);
            this.Controls.Add(rdoEmployee);
            this.Controls.Add(rdoCustomer);

            // Đảm bảo RadioButton hiển thị trên các điều khiển khác
            rdoAdmin.BringToFront();
            rdoEmployee.BringToFront();
            rdoCustomer.BringToFront();

            // Làm mới form để vẽ lại các điều khiển
            this.Refresh();
        }

        private string GetSelectedRole()
        {
            RadioButton rdoAdmin = this.Controls["rdoAdmin"] as RadioButton;
            RadioButton rdoEmployee = this.Controls["rdoEmployee"] as RadioButton;
            RadioButton rdoCustomer = this.Controls["rdoCustomer"] as RadioButton;

            if (rdoAdmin != null && rdoAdmin.Checked)
                return "admin";
            if (rdoEmployee != null && rdoEmployee.Checked)
                return "employee";
            if (rdoCustomer != null && rdoCustomer.Checked)
                return "customer";
            return null;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string selectedRole = GetSelectedRole();

            // Kiểm tra xem người dùng đã chọn vai trò chưa
            if (selectedRole == null)
            {
                MessageBox.Show("Vui lòng chọn một vai trò (Admin, Employee, hoặc Customer).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Kiểm tra đăng nhập
                User user = BSUser.Login(username, password);
                if (user != null)
                {
                    // Kiểm tra vai trò được chọn có khớp với vai trò trong cơ sở dữ liệu
                    if (user.Role.ToLower() == selectedRole)
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        switch (user.Role.ToLower())
                        {
                            case "admin":
                                AdminForm adminForm = new AdminForm();
                                adminForm.ShowDialog();
                                this.Close();
                                break;

                            case "employee":
                                EmployeeForm employeeForm = new EmployeeForm(user);
                                employeeForm.ShowDialog();
                                this.Close();
                                break;

                            case "customer":
                                CustomerForm customerForm = new CustomerForm(user);
                                customerForm.ShowDialog();
                                this.Close();
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Tài khoản này không phải là {selectedRole}. Vui lòng chọn đúng vai trò.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại! Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void linkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotForm forgotForm = new ForgotForm();
            forgotForm.ShowDialog();
        }

        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkPassword.Checked;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }
    }
}