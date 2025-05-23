using System;
using System.Data;
using System.Windows.Forms;
using DoAnCKver1.BSLayer;

namespace DoAnCKver1
{
    public partial class CustomerDetailsForm : Form
    {
        private int userId;

        public CustomerDetailsForm(int userId)
        {
            this.userId = userId;
            InitializeComponents();
            LoadCustomerDetails();
        }

        private void InitializeComponents()
        {
            this.Text = "Customer Account Details";
            this.Size = new System.Drawing.Size(400, 550); // Tăng chiều cao form để chứa thêm thông tin
            this.MinimumSize = new System.Drawing.Size(400, 550);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            TableLayoutPanel panel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 10, // Tăng RowCount từ 9 lên 10 để chứa thêm ComponentCount
                ColumnCount = 2,
                Padding = new Padding(10)
            };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));

            // Tạo các Label và TextBox
            Label lblUsername = new Label { Text = "Username:", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
            TextBox txtUsername = new TextBox { Dock = DockStyle.Fill, ReadOnly = true };
            Label lblEmail = new Label { Text = "Email:", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
            TextBox txtEmail = new TextBox { Dock = DockStyle.Fill, ReadOnly = true };
            Label lblPassword = new Label { Text = "Password:", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
            TextBox txtPassword = new TextBox { Dock = DockStyle.Fill, ReadOnly = true };
            Label lblRole = new Label { Text = "Role:", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
            TextBox txtRole = new TextBox { Dock = DockStyle.Fill, ReadOnly = true };
            Label lblStatus = new Label { Text = "Status:", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
            TextBox txtStatus = new TextBox { Dock = DockStyle.Fill, ReadOnly = true };
            Label lblLaptops = new Label { Text = "Số laptop đã mua:", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
            TextBox txtLaptops = new TextBox { Dock = DockStyle.Fill, ReadOnly = true };
            Label lblComponents = new Label { Text = "Số linh kiện đã mua:", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft }; // Thêm Label mới
            TextBox txtComponents = new TextBox { Dock = DockStyle.Fill, ReadOnly = true }; // Thêm TextBox mới
            Label lblWarranties = new Label { Text = "Số phiếu bảo hành:", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
            TextBox txtWarranties = new TextBox { Dock = DockStyle.Fill, ReadOnly = true };
            Label lblTotalSpent = new Label { Text = "Tổng tiền đã chi:", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
            TextBox txtTotalSpent = new TextBox { Dock = DockStyle.Fill, ReadOnly = true };

            // Thêm điều khiển vào panel
            panel.Controls.Add(lblUsername, 0, 0);
            panel.Controls.Add(txtUsername, 1, 0);
            panel.Controls.Add(lblEmail, 0, 1);
            panel.Controls.Add(txtEmail, 1, 1);
            panel.Controls.Add(lblPassword, 0, 2);
            panel.Controls.Add(txtPassword, 1, 2);
            panel.Controls.Add(lblRole, 0, 3);
            panel.Controls.Add(txtRole, 1, 3);
            panel.Controls.Add(lblStatus, 0, 4);
            panel.Controls.Add(txtStatus, 1, 4);
            panel.Controls.Add(lblLaptops, 0, 5);
            panel.Controls.Add(txtLaptops, 1, 5);
            panel.Controls.Add(lblComponents, 0, 6); // Thêm vào hàng 6
            panel.Controls.Add(txtComponents, 1, 6); // Thêm vào hàng 6
            panel.Controls.Add(lblWarranties, 0, 7); // Dời xuống hàng 7
            panel.Controls.Add(txtWarranties, 1, 7); // Dời xuống hàng 7
            panel.Controls.Add(lblTotalSpent, 0, 8); // Dời xuống hàng 8
            panel.Controls.Add(txtTotalSpent, 1, 8); // Dời xuống hàng 8

            // Tạo nút đóng
            Button btnClose = new Button
            {
                Text = "Close",
                Dock = DockStyle.Bottom,
                Height = 30,
                Margin = new Padding(10)
            };
            btnClose.Click += (s, e) => this.Close();

            panel.Controls.Add(btnClose, 1, 9); // Dời nút Close xuống hàng 9

            // Gán tên cho TextBox để truy cập trong LoadCustomerDetails
            txtUsername.Name = "txtUsername";
            txtEmail.Name = "txtEmail";
            txtPassword.Name = "txtPassword";
            txtRole.Name = "txtRole";
            txtStatus.Name = "txtStatus";
            txtLaptops.Name = "txtLaptops";
            txtComponents.Name = "txtComponents"; // Gán tên cho TextBox mới
            txtWarranties.Name = "txtWarranties";
            txtTotalSpent.Name = "txtTotalSpent";

            this.Controls.Add(panel);
        }

        private void LoadCustomerDetails()
        {
            try
            {
                DataTable dt = BSUser.GetCustomerDetails(userId);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                DataRow row = dt.Rows[0];
                ((TextBox)this.Controls[0].Controls["txtUsername"]).Text = row["Username"].ToString();
                ((TextBox)this.Controls[0].Controls["txtEmail"]).Text = row["Email"].ToString();
                ((TextBox)this.Controls[0].Controls["txtPassword"]).Text = row["Password"].ToString();
                ((TextBox)this.Controls[0].Controls["txtRole"]).Text = row["Role"].ToString();
                ((TextBox)this.Controls[0].Controls["txtStatus"]).Text = row["Status"].ToString();
                ((TextBox)this.Controls[0].Controls["txtLaptops"]).Text = row["LaptopCount"].ToString();
                ((TextBox)this.Controls[0].Controls["txtWarranties"]).Text = row["WarrantyCount"].ToString();
                ((TextBox)this.Controls[0].Controls["txtTotalSpent"]).Text = Convert.ToDecimal(row["TotalSpent"]).ToString("N2") + " VND";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thông tin tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CustomerDetailsForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "CustomerDetailsForm";
            this.Load += new System.EventHandler(this.CustomerDetailsForm_Load);
            this.ResumeLayout(false);

        }

        private void CustomerDetailsForm_Load(object sender, EventArgs e)
        {

        }
    }
}