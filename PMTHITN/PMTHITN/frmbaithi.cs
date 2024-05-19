using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PMTHITN
{
    public partial class frmbaithi : Form
    {
        public SqlConnection conn = new SqlConnection();
        public SqlDataAdapter da = new SqlDataAdapter();
        public SqlCommand cmd = new SqlCommand();
        public DataTable dt = new DataTable();
        public string sql, constr;
        public string mamonthi;

        public frmbaithi()
        {
            InitializeComponent();
        }
        public string LayDapAn(TableLayoutPanel table)
        {

            string chon = "f";
            RadioButton radio = null;
            try
            {
                foreach (RadioButton item in table.Controls)
                {
                    if (item.Checked == true)
                    {
                        radio = item;
                        break;
                    }
                }
                if (radio != null)
                {
                    chon = radio.Tag.ToString();
                }
                else
                {
                    chon = "f";
                }


            }
            catch
            { }
            return chon;

        }

        public void frmbaithi_Load(object sender, EventArgs e)
        {
            constr = "Data Source=PHUQUY577920\\SQLEXPRESS;Initial Catalog=THITRACNGHIEM;Integrated Security=True";
            conn.ConnectionString = constr;
            conn.Open();

        }

        public void btnback_Click(object sender, EventArgs e)
        {
            // tách lấy số câu hiện tại
            String chuoi = grbnoidung.Text;
            string[] so = chuoi.Split(' ');
            int k = so.Length;
            int i = Convert.ToInt32(so[k - 1]);
            if (i > 1)
            {
                // hiển thị số câu.
                grbnoidung.Text = "Câu số " + (i - 1).ToString();
                // Chuyển nội dung câu hỏi tiếp theo
                lblnoidungcauhoi.Text = dt.Rows[i - 2][2].ToString();
            }
            else
            { 
            }
        }

        
        public void btndone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        public void btnnext_Click(object sender, EventArgs e)
        {
            // tách lấy số câu hiện tại
            String chuoi = grbnoidung.Text;
            string[] so = chuoi.Split(' ');
            int k = so.Length;
            int i = Convert.ToInt32(so[k - 1]);
            if (i < dulieu.TONGSOCAU)
            {
                // hiển thị số câu.
                grbnoidung.Text = "Câu số " + (i + 1).ToString();
                // Chuyển nội dung câu hỏi tiếp theo
                lblnoidungcauhoi.Text = dt.Rows[i][2].ToString();
            }
            else
            { }

        }


        public void timer1_Tick(object sender, EventArgs e)
        {   // Lấy thông tin thời gian từ lbl
            int giay = Int32.Parse(lblgiay.Text);
            int phut = Int32.Parse(lblphut.Text);
            giay--;
            if (giay < 1)
            {
                giay = 59;
                phut--;
            }
            if (giay < 10)
            {
                lblgiay.Text = "0" + giay;
            }
            else
            {
                lblgiay.Text = giay + "";
            }
            if (phut < 10)
            {
                lblphut.Text = "0" + phut;
            }
            else
            {
                lblphut.Text = phut + "";
            }
            if (phut == 0)
            {
                if (giay == 1)
                {
                    timer1.Stop();
                    MessageBox.Show("Hết Giờ !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // chấm điểm.
                    // Dừng đồng hồ
                    //timer1.Stop();

                    // dừng bài làm
                    tableLayoutPanelcaform.Enabled = false;

                    string[] a = new string[100];
                    try
                    {
                        a[0] = LayDapAn(tbl1);
                        a[1] = LayDapAn(tbl2);
                        a[2] = LayDapAn(tbl3);
                        a[3] = LayDapAn(tbl4);
                        a[4] = LayDapAn(tbl5);
                        a[5] = LayDapAn(tbl6);
                        a[6] = LayDapAn(tbl7);
                        a[7] = LayDapAn(tbl8);
                        a[8] = LayDapAn(tbl9);
                        a[9] = LayDapAn(tbl10);
                        a[10] = LayDapAn(tbl11);
                        a[11] = LayDapAn(tbl12);
                        a[12] = LayDapAn(tbl13);
                        a[13] = LayDapAn(tbl14);
                        a[14] = LayDapAn(tbl15);
                        a[15] = LayDapAn(tbl16);
                        a[16] = LayDapAn(tbl17);
                        a[17] = LayDapAn(tbl18);
                        a[18] = LayDapAn(tbl19);
                        a[19] = LayDapAn(tbl20);
                        
                        a[20] = LayDapAn(tbl21);
                        a[21] = LayDapAn(tbl22);
                        a[22] = LayDapAn(tbl23);
                        a[23] = LayDapAn(tbl24);
                        a[24] = LayDapAn(tbl25);
                        a[25] = LayDapAn(tbl30);
                        a[26] = LayDapAn(tbl27);
                        a[27] = LayDapAn(tbl28);
                        a[28] = LayDapAn(tbl29);
                        a[29] = LayDapAn(tbl34);
                        a[30] = LayDapAn(tbl31);
                        a[31] = LayDapAn(tbl32);
                        a[32] = LayDapAn(tbl33);
                        a[33] = LayDapAn(tbl38);
                        a[34] = LayDapAn(tbl35);
                        a[35] = LayDapAn(tbl36);
                        a[36] = LayDapAn(tbl37);
                        a[37] = LayDapAn(tbl42);
                        a[38] = LayDapAn(tbl39);
                        a[39] = LayDapAn(tbl40);
                        
                    }
                    catch
                    { }

                    // đếm số câu đúng ( so sánh mảng với cột đáp án)
                    int dem = 0;
                    for (int i = 0; i < dulieu.TONGSOCAU; i++)
                    {
                        if (a[i] == dt.Rows[i][3].ToString())
                        {
                            dem = dem + 1;
                        }
                    }
                    // tính điểm
                    double diem = (Convert.ToDouble(dem) * 10 / 40);
                    // thông báo
                    MessageBox.Show("Bạn đã trả lời đúng: " + dem.ToString() + "/" + dulieu.TONGSOCAU + " câu: " + diem + " Điểm", "Kết Quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Lưu bài làm của sinh viên
                    try
                    {
                        for (int j = 0; j < dulieu.TONGSOCAU; j++)
                        {
                            string macauhoi = dt.Rows[j][0].ToString();
                            sql = "insert into BAILAM values('" + thongtinsv.MSV + "','" + macauhoi + "','" + a[j] + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
                            cmd = new SqlCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                        }

                    }
                    catch
                    { }
                    //Xem trong bảng KETQUA xem sinh viên thi lần mấy
                    int lanthu = 1;
                    sql = "select count(*) from KETQUA where MaSV = '" + thongtinsv.MSV + "'";

                    da = new SqlDataAdapter(sql, conn);
                    dt = new DataTable();
                    da.Fill(dt);
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    int val = (int)cmd.ExecuteScalar();
                    if (val >= 1)
                    {
                        sql = "select Lanthi from KETQUA where MaSV = '" + thongtinsv.MSV + "'";

                        da = new SqlDataAdapter(sql, conn);
                        dt = new DataTable();
                        da.Fill(dt);
                        cmd = new SqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                        int lan = (int)cmd.ExecuteScalar();
                        lanthu = lan + 1;
                    }
                    else
                    {
                        lanthu = 1;
                    }
                    // Lưu vào bảng kết quả
                    float DIEM = (float)diem;
                    sql = "insert into KETQUA values('" + thongtinsv.MSV + "','" + dulieu.MAMONTHI + "','" + DIEM + "','" + lanthu + "')";
                    da = new SqlDataAdapter(sql, conn);
                    dt = new DataTable();
                    da.Fill(dt);
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Done");

                }
            }
        }


        private void grbnoidung_TextChanged(object sender, EventArgs e)
        {
            // tách lấy số câu hiện tại
            String chuoi = grbnoidung.Text;
            string[] so = chuoi.Split(' ');
            int k = so.Length;
            int i = Convert.ToInt32(so[k - 1]);
            // hiển thị nội dung câu hiện tại
            try
            {
                lblnoidungcauhoi.Text = dt.Rows[i ][2].ToString();
            }
            catch
            { }
            // tô màu table câu hiện tại

            foreach (Control c in this.Controls)
            {   // TableLayoutPanel cả form, chứa tất cả các control và nội dung
                if (c is TableLayoutPanel)
                {
                    foreach (Control a in this.tableLayoutPanelcaform.Controls)
                    {   // các panel nằm trong tableLayoutPanel của toàn form
                        if (a is Panel)
                        {   // cột 1
                            foreach (Control b in this.tableLayoutPanelcot1.Controls)
                                if (b is TableLayoutPanel && b.Name == "tbl" + i.ToString())
                                {
                                    b.BackColor = Color.LightBlue;

                                }
                                else
                                {
                                    b.BackColor = SystemColors.Control;
                                }
                            // cột thứ 2 trong bảng trả lời
                            foreach (Control b in this.tableLayoutPanelcot2.Controls)
                                if (b is TableLayoutPanel && b.Name == "tbl" + i.ToString())
                                {
                                    b.BackColor = Color.LightBlue;
                                }
                                else
                                {
                                    b.BackColor = SystemColors.Control;
                                }

                        }
                    }
                }
            }
        }

        

        private void lbl1_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 1";
            lblnoidungcauhoi.Text = dt.Rows[0][2].ToString();
        }

        private void lbl2_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 2";
            lblnoidungcauhoi.Text = dt.Rows[1][2].ToString();
        }

        private void lbl3_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 3";
            lblnoidungcauhoi.Text = dt.Rows[2][2].ToString();
        }

        private void lbl4_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 4";
            lblnoidungcauhoi.Text = dt.Rows[3][2].ToString();
        }

        private void lbl5_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 5";
            lblnoidungcauhoi.Text = dt.Rows[4][2].ToString();
        }

        private void lbl6_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 6";
            lblnoidungcauhoi.Text = dt.Rows[5][2].ToString();
        }

        private void lbl7_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 7";
            lblnoidungcauhoi.Text = dt.Rows[6][2].ToString();
        }

        private void lbl8_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 8";
            lblnoidungcauhoi.Text = dt.Rows[7][2].ToString();
        }

        private void lbl9_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 9";
            lblnoidungcauhoi.Text = dt.Rows[8][2].ToString();
        }

        private void lbl10_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 10";
            lblnoidungcauhoi.Text = dt.Rows[9][2].ToString();
        }

        private void lbl11_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 11";
            lblnoidungcauhoi.Text = dt.Rows[10][2].ToString();
        }

        private void lbl12_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 12";
            lblnoidungcauhoi.Text = dt.Rows[11][2].ToString();
        }

        private void lbl13_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 13";
            lblnoidungcauhoi.Text = dt.Rows[12][2].ToString();
        }
        private void lbl14_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 14";
            lblnoidungcauhoi.Text = dt.Rows[13][2].ToString();
        }

        private void lbl15_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 15";
            lblnoidungcauhoi.Text = dt.Rows[14][2].ToString();
        }

        private void lbl16_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 16";
            lblnoidungcauhoi.Text = dt.Rows[15][2].ToString();
        }

        private void lbl17_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 17";
            lblnoidungcauhoi.Text = dt.Rows[16][2].ToString();
        }

        private void lbl18_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 18";
            lblnoidungcauhoi.Text = dt.Rows[17][2].ToString();
        }

        private void lbl19_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 19";
            lblnoidungcauhoi.Text = dt.Rows[18][2].ToString();
        }

        private void lbl20_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 20";
            lblnoidungcauhoi.Text = dt.Rows[19][2].ToString();
        }

        private void lbl21_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 21";
            lblnoidungcauhoi.Text = dt.Rows[20][2].ToString();
        }

        private void lbl22_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 22";
            lblnoidungcauhoi.Text = dt.Rows[21][2].ToString();
        }

        private void lbl23_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 23";
            lblnoidungcauhoi.Text = dt.Rows[22][2].ToString();
        }

        private void lbl24_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 24";
            lblnoidungcauhoi.Text = dt.Rows[23][2].ToString();
        }

        private void lbl25_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 25";
            lblnoidungcauhoi.Text = dt.Rows[24][2].ToString();
        }

        private void lbl26_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 26";
            lblnoidungcauhoi.Text = dt.Rows[25][2].ToString();
        }

        private void lbl27_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 27";
            lblnoidungcauhoi.Text = dt.Rows[26][2].ToString();
        }

        private void lbl28_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 28";
            lblnoidungcauhoi.Text = dt.Rows[27][2].ToString();

        }

        private void lbl29_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 29";
            lblnoidungcauhoi.Text = dt.Rows[28][2].ToString();
        }

        private void lbl30_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 30";
            lblnoidungcauhoi.Text = dt.Rows[29][2].ToString();
        }

        private void lbl31_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 31";
            lblnoidungcauhoi.Text = dt.Rows[30][2].ToString();
        }

        private void lbl32_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 32";
            lblnoidungcauhoi.Text = dt.Rows[31][2].ToString();
        }

        private void lbl33_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 33";
            lblnoidungcauhoi.Text = dt.Rows[32][2].ToString();

        }

        private void lbl34_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 34";
            lblnoidungcauhoi.Text = dt.Rows[33][2].ToString();
        }

        private void lbl35_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 35";
            lblnoidungcauhoi.Text = dt.Rows[34][2].ToString();
        }

        private void lbl36_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 36";
            lblnoidungcauhoi.Text = dt.Rows[35][2].ToString();
        }

        private void lbl37_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 37";
            lblnoidungcauhoi.Text = dt.Rows[36][2].ToString();
        }

        private void lbl38_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 38";
            lblnoidungcauhoi.Text = dt.Rows[37][2].ToString();
        }

        private void lbl39_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 39";
            lblnoidungcauhoi.Text = dt.Rows[38][2].ToString();
        }

        private void lbl40_Click(object sender, EventArgs e)
        {
            grbnoidung.Text = "Câu số 40";
            lblnoidungcauhoi.Text = dt.Rows[39][2].ToString();
        }

        

        private void lblphut_TextChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }
        private void tble1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grbnoidung_Enter(object sender, EventArgs e)
        {

        }
        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label84_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void rd3d_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void lbltime_Click(object sender, EventArgs e)
        {

        }

        public void btnback_Click_1(object sender, EventArgs e)
        {
            // tách lấy số câu hiện tại
            String chuoi = grbnoidung.Text;
            string[] so = chuoi.Split(' ');
            int k = so.Length;
            int i = Convert.ToInt32(so[k - 1]);
            if (i > 1)
            {
                // hiển thị số câu.
                grbnoidung.Text = "Câu số " + (i - 1).ToString();
                // Chuyển nội dung câu hỏi tiếp theo
                lblnoidungcauhoi.Text = dt.Rows[i - 2][2].ToString();
            }
            else
            { }
        }

        private void btndone_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn nộp bài không ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                // Dừng đồng hồ
                timer1.Stop();

                // dừng bài làm
                tableLayoutPanelcaform.Enabled = false;

                string[] a = new string[100];
                try
                {
                    a[0] = LayDapAn(tbl1);
                    a[1] = LayDapAn(tbl2);
                    a[2] = LayDapAn(tbl3);
                    a[3] = LayDapAn(tbl4);
                    a[4] = LayDapAn(tbl5);
                    a[5] = LayDapAn(tbl6);
                    a[6] = LayDapAn(tbl7);
                    a[7] = LayDapAn(tbl8);
                    a[8] = LayDapAn(tbl9);
                    a[9] = LayDapAn(tbl10);
                    a[10] = LayDapAn(tbl11);
                    a[11] = LayDapAn(tbl12);
                    a[12] = LayDapAn(tbl13);
                    a[13] = LayDapAn(tbl14);
                    a[14] = LayDapAn(tbl15);
                    a[15] = LayDapAn(tbl16);
                    a[16] = LayDapAn(tbl17);
                    a[17] = LayDapAn(tbl18);
                    a[18] = LayDapAn(tbl19);
                    a[19] = LayDapAn(tbl20);
                    
                    a[24] = LayDapAn(tbl21);
                    a[25] = LayDapAn(tbl22);
                    a[26] = LayDapAn(tbl23);
                    a[27] = LayDapAn(tbl24);
                    a[28] = LayDapAn(tbl25);
                    a[29] = LayDapAn(tbl30);
                    a[30] = LayDapAn(tbl27);
                    a[31] = LayDapAn(tbl28);
                    a[32] = LayDapAn(tbl29);
                    a[33] = LayDapAn(tbl34);
                    a[34] = LayDapAn(tbl31);
                    a[35] = LayDapAn(tbl32);
                    a[36] = LayDapAn(tbl33);
                    a[37] = LayDapAn(tbl38);
                    a[38] = LayDapAn(tbl35);
                    a[39] = LayDapAn(tbl36);
                    a[40] = LayDapAn(tbl37);
                    a[41] = LayDapAn(tbl42);
                    a[42] = LayDapAn(tbl39);
                    a[43] = LayDapAn(tbl40);
                   
                }
                catch
                { }

                // đếm số câu đúng ( so sánh mảng với cột đáp án)
                int dem = 0;
                for (int i = 0; i < dulieu.TONGSOCAU; i++)
                {
                    if (a[i] == dt.Rows[i][3].ToString())
                    {
                        dem = dem + 1;
                    }
                }
                // tính điểm
                double diem = (Convert.ToDouble(dem) * 10 / 40);
                // thông báo
                MessageBox.Show("Bạn đã trả lời đúng: " + dem.ToString() + "/" + dulieu.TONGSOCAU + " câu: " + diem + " Điểm", "Kết Quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Lưu bài làm của sinh viên
                try
                {
                    for (int j = 0; j < dulieu.TONGSOCAU; j++)
                    {
                        string macauhoi = dt.Rows[j][0].ToString();
                        sql = "insert into BAILAM values('" + thongtinsv.MSV + "','" + macauhoi + "','" + a[j] + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
                        cmd = new SqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                    }

                }
                catch
                { }
                //Xem trong bảng KETQUA xem sinh viên thi lần mấy
                int lanthu = 1;

                sql = "select count(*) from KETQUA ";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                int val = (int)cmd.ExecuteScalar();
                if (val >= 1)
                {
                    lanthu = val + 1;
                }
                else
                {
                    lanthu = 1;
                }



                // Lưu vào bảng kết quả
                String tach = diem.ToString();
                string[] td = tach.Split(',');
                int nguyen;
                int thapphan;
                if (td.Length == 1)
                {
                    nguyen = Convert.ToInt32(td[0]);
                    thapphan = 0;
                }
                else
                {
                    nguyen = Convert.ToInt32(td[0]);
                    thapphan = Convert.ToInt32(td[1]);
                }

                //MessageBox.Show("'" + thongtinsv.MSV + "','" + dulieu.MAMONTHI + "','" + DIEM + "', '" + lanthu + "' ");
                sql = "insert into KETQUA values('" + thongtinsv.MSV + "','" + dulieu.MAMONTHI + "','" + nguyen + "." + thapphan + "','" + lanthu + "')";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Application.Exit();

            }
            else
            { }
        }

        public void frmbaithi_Load_1(object sender, EventArgs e)
        {

            conn = new SqlConnection();
            constr = "Data Source=PHUQUY577920\\SQLEXPRESS;Initial Catalog=THITRACNGHIEM;Integrated Security=True";
            conn.ConnectionString = constr;
            conn.Open();
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            // lấy thông tin môn thi
            sql = "select * from MONTHI ";
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            // hiển thị thông tin môn thi
            if (dt.Rows.Count > 0)
            {
                // Nếu có dữ liệu, thực hiện các thao tác truy cập dữ liệu
                lblmonthi.Text = dt.Rows[0][1].ToString();
                lblsocau.Text = dt.Rows[0][2].ToString();
                lblthoigian.Text = dt.Rows[0][3].ToString();
            }
            else
            {
                // Xử lý trường hợp không có dữ liệu
                lblmonthi.Text = "N/A";
                lblsocau.Text = "N/A";
                lblthoigian.Text = "N/A";
            }
            // lấy mã môn thi
            if (dt.Rows.Count > 0)
            {
                string mamonthi = dt.Rows[0][0].ToString();
                dulieu.MAMONTHI = mamonthi.Trim();
            }
            else
            {
                // Xử lý trường hợp không có dữ liệu
                dulieu.MAMONTHI = "N/A";
            }
            // lấy thời gian môn thi để tính giờ
            lblphut.Text = dt.Rows[0][3].ToString();
            // Lấy số câu hỏi của đề thi
            string tongsocau = dt.Rows[0][2].ToString();
            int socau = Convert.ToInt32(tongsocau);
            // lưu số câu hỏi vào data public
            dulieu.TONGSOCAU = socau;
            // Lấy thông tin thí sinh
            //  1. Nhận thông tin Mã sinh viên từ form đăng nhập thông qua class public
            string masinhvien = thongtinsv.MSV;
            // 2. lấy thông tin trong sql
            sql = "select * from SV" + masinhvien ;
            da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            lblhoten.Text = dt.Rows[0][1].ToString() + " " + dt.Rows[0][2].ToString();
            lblmsv.Text = thongtinsv.MSV;
            // Tạo đề ngẫu nhiên tùy theo môn học
            sql = "select top " + socau + " * from CAUHOI ";
            da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            dt.Clear();
            da.Fill(dt);

            // load nội dung câu hỏi 1.
            int i = 0;
            grbnoidung.Text = "Câu số " + (i + 1).ToString();

            lblnoidungcauhoi.Text = dt.Rows[i][2].ToString();

            // bắt đầu đếm giờ
            timer1.Start();
        }

        private void lblnoidungcauhoi_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }


    }
}


    


        






    