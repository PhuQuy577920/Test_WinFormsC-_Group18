using System;
using System.Data;
using System.Windows.Forms;

namespace PMTHITN
{
    public partial class frminfo : Form
    {
        private readonly IDatabaseService databaseService;

        public frminfo(IDatabaseService databaseService)
        {
            InitializeComponent();
            this.databaseService = databaseService;
        }

        public void btnvaothi_Click(object sender, EventArgs e)
        {
            DataTable dt = databaseService.GetExamInfo();
            if (dt.Rows.Count > 0)
            {
                Form f = new frmbaithi();
                f.ShowDialog();
                this.Close(); // Di chuyển đến đây
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị trong form bài thi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void frminfo_Load(object sender, EventArgs e)
        {
            DataTable dt = databaseService.GetExamInfo();
            if (dt.Rows.Count > 0)
            {
                lblmonthi.Text = dt.Rows[0]["TenMon"].ToString();
                lblsocau.Text = dt.Rows[0]["SoCau"].ToString();
                lblthoigian.Text = dt.Rows[0]["ThoiGian"].ToString() + " phút";
            }
            else
            {
                lblmonthi.Text = "N/A";
                lblsocau.Text = "N/A";
                lblthoigian.Text = "N/A";
            }

            string masinhvien = thongtinsv.MSV;
            dt = databaseService.GetStudentInfo(masinhvien);

            if (dt.Rows.Count > 0)
            {
                
                lblmsv.Text = thongtinsv.MSV;
            }
            else
            {
                lblhoten.Text = "N/A";
                lblmsv.Text = "N/A";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Không có logic nào ở đây
        }
    }
}
