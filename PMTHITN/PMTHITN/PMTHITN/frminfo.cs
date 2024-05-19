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
    public partial class frminfo : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        string sql, constr;
        public frminfo()
        {
            InitializeComponent();
        }

        private void btnvaothi_Click(object sender, EventArgs e)
        {
            // mở form bài thi
            this.Close();
            Form f = new frmbaithi();
            f.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frminfo_Load(object sender, EventArgs e)
        {
            constr = "Data Source=PHUQUY577920\\SQLEXPRESS;Initial Catalog=THITRACNGHIEM;Integrated Security=True";
            conn.ConnectionString = constr;
            conn.Open();
            // lấy thông tin thời gian hiện tại
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            // lấy thông tin môn thi
            sql = "select * from MONTHI where Thoigianthi = '" + year + "-" + month + "-" + day + "'";
            da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            lblmonthi.Text = dt.Rows[0][1].ToString();
            lblsocau.Text = dt.Rows[0][2].ToString();
            lblthoigian.Text = dt.Rows[0][3].ToString() + " phút";
            // Lấy thông tin thí sinh
            //  1. Nhận thông tin Mã sinh viên từ form đăng nhập thông qua class public
            string masinhvien = thongtinsv.MSV;
            // 2. lấy thông tin trong sql
            sql = "select * from SV where MaSV = '" + masinhvien + "'";
            da = new SqlDataAdapter(sql, conn);
            
            dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            lblhoten.Text = dt.Rows[0][1].ToString() + " " + dt.Rows[0][2].ToString();
            lblmsv.Text = thongtinsv.MSV;
        }

        
    }
}
