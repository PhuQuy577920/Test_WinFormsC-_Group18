using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMTHITN
{
    public partial class frmlogin : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        string sql,constr;
        Boolean gvflag = false;

        public frmlogin()
        {
            InitializeComponent();
        }

        private void linkquenmk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Bạn vui lòng thông báo với giám thị coi thi để xin cấp lại Mật khẩu)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            // kiểm tra xem loại tk 
            if (gvflag==true)
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
            // Nếu là SV
            else
            {
                sql = "select count(*) from SV where MaSV ='" + txtuser.Text + "' and Matkhau = '" + txtmk.Text + "' ";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                int val = (int)cmd.ExecuteScalar();
                if (val == 1)
                {   // lấy thông tin MSV truyền vào public
                    try
                    {
                        thongtinsv.MSV = txtuser.Text.ToString();
                    }
                    catch { }

                    // mở form thông tin
                    frminfo child = new frminfo();
                    child.Show();
                    this.Hide();



                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void btngv_Click(object sender, EventArgs e)
        {
            gvflag = true;
           
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btngv_MouseClick(object sender, MouseEventArgs e)
        {
            btngv.BackColor = Color.DodgerBlue;
            btngv.TextColor = Color.White;
        }

        private void btnsv_MouseClick(object sender, MouseEventArgs e)
        {
            btnsv.BackColor = Color.DodgerBlue;
            btnsv.TextColor = Color.White;
        }

        private void btnsv_MouseHover(object sender, EventArgs e)
        {
            btnsv.BackColor = Color.DodgerBlue;
            btnsv.TextColor = Color.White;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmlogin_Load(object sender, EventArgs e)
        {
           
            constr = "Data Source=PHUQUY577920\\SQLEXPRESS;Initial Catalog=THITRACNGHIEM;Integrated Security=True";
            conn.ConnectionString = constr;
            conn.Open();
        }
    }
}
