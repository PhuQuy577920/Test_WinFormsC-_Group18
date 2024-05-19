using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PMTHITN
{
    public partial class frmlogin : Form
    {
        public SqlConnection conn;
        SqlDataAdapter da = new SqlDataAdapter();
        public SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        string sql, constr;
        public Boolean gvflag = false;

        public frmlogin()
        {
            InitializeComponent();
            conn = new SqlConnection();
        }

        public frmlogin(SqlConnection connection)
        {
            InitializeComponent();
            conn = connection;
        }

        public virtual void ShowMessage(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox.Show(message, caption, buttons, icon);
        }

        public void linkquenmk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowMessage("Bạn vui lòng thông báo với giám thị coi thi để xin cấp lại Mật khẩu)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void btnlogin_Click(object sender, EventArgs e)
        {
            if (gvflag)
            {
                sql = "select count(*) from GV where ID_gv = '" + txtuser.Text + "' and Pass = '" + txtmk.Text + "'";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                int val = (int)cmd.ExecuteScalar();
                if (val == 1)
                {
                    frmgv child = new frmgv();
                    child.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu. Nếu bạn là Sinh viên vui lòng chọn ô Sinh viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                sql = "select count(*) from SV where MaSV ='" + txtuser.Text + "' and Matkhau = '" + txtmk.Text + "' ";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                int val = (int)cmd.ExecuteScalar();
                if (val == 1)
                {
                    try
                    {
                        thongtinsv.MSV = txtuser.Text.ToString();
                    }
                    catch { }

                    string connectionString = "Data Source=PHUQUY577920\\SQLEXPRESS;Initial Catalog=THITRACNGHIEM;Integrated Security=True";
                    IDatabaseService databaseService = new DatabaseService(connectionString);
                    frminfo child = new frminfo(databaseService);
                    child.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void btngv_Click(object sender, EventArgs e)
        {
            gvflag = true;
        }

        public void btngv_MouseClick(object sender, MouseEventArgs e)
        {
            btngv.BackColor = Color.LightSalmon;
            btngv.ForeColor = Color.Red;
        }

        public void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void btnsv_MouseClick(object sender, MouseEventArgs e)
        {
            btnsv.BackColor = Color.LightSalmon;
            btnsv.ForeColor = Color.Red;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        public void frmlogin_Load(object sender, EventArgs e)
        {
            constr = "Data Source=PHUQUY577920\\SQLEXPRESS;Initial Catalog=THITRACNGHIEM;Integrated Security=True";
            conn.ConnectionString = constr;
            conn.Open();
        }
    }
}
