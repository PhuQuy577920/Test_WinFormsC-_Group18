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
    public partial class frmgv : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        SqlCommand lenh = new SqlCommand();
        string sql, constr;
        public frmgv()
        {
            InitializeComponent();
        }
        private void frmgv_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tHITRACNGHIEMDataSet.MONTHI' table. You can move, or remove it, as needed.
            //this.mONTHITableAdapter.Fill(this.tHITRACNGHIEMDataSet.MONTHI);
            constr = "Data Source=PHUQUY577920\\SQLEXPRESS;Initial Catalog=THITRACNGHIEM;Integrated Security=True";
            conn.ConnectionString = constr;
            conn.Open();

        }
        private void LoadDuLieu(string sql)
        {

            dt = new DataTable();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            dgvmenu.DataSource = dt;
        }

        private void Chitiet(Boolean a)
        {
            txtmamon.Enabled = a;
            txtsocau.Enabled = a;
            txtthoigian.Enabled = a;
            txttenmon.Enabled = a;
            dtptgthi.Enabled = a;
            txtmach.Enabled = a;
            txtnoidung.Enabled = a;
            cmbdapan.Enabled = a;
            cmbmon.Enabled = a;

        }



        private void Lamsach()
        {
            txtmach.Clear();
            txtmamon.Clear();
            txtnoidung.Clear();
            txtsocau.Clear();
            txttenmon.Clear();
            dtptgthi.Text = "";
            txtthoigian.Clear();
            cmbdapan.Text = "";
            cmbmon.Text = "";
        }


        // PHẦN CÂU HỎI CỦA QUẢN LÝ
        private void piccauhoi_Click(object sender, EventArgs e)
        {
            // môn thi
            lblmamon.Visible = false;
            lbltenmon.Visible = false;
            lblsocau.Visible = false;
            lblthoigian.Visible = false;
            txtmamon.Visible = false;
            txttenmon.Visible = false;
            txtthoigian.Visible = false;
            txtsocau.Visible = false;
            dtptgthi.Visible = false;
            lbltgthi.Visible = false;

            // câu hỏi
            lblmonthi.Visible = true;
            lblnoidungch.Visible = true;
            lbldapan.Visible = true;
            txtmach.Visible = true;
            cmbdapan.Visible = true;
            cmbmon.Visible = true;
            cmbloc.Visible = true;
            lblloc.Visible = true;
            txtnoidung.Visible = true;
            txtmach.Visible = true;
            lblmach.Visible = true;
            // làm sạch
            Lamsach();

            // datagridview
            grbcauhoi.Text = "Danh sách câu hỏi";
            sql = "select MaCH as 'Mã câu hỏi', MaM as 'Mã môn', Noidung as ' Nội dung câu hỏi', Dapan as 'Đáp án' from CAUHOI";
            LoadDuLieu(sql);
            //Ẩn hiện nút
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            txtmach.Enabled = false;
            cmbmon.Enabled = false;
            txtnoidung.Enabled = false;
            cmbdapan.Enabled = false;
        }


        //PHẦN MÔN THI CỦA QUẢN LÝ
        private void picmonthi_Click(object sender, EventArgs e)
        {
            // Môn thi
            lblmamon.Visible = true;
            lbltenmon.Visible = true;
            lblsocau.Visible = true;
            lblthoigian.Visible = true;
            txtmamon.Visible = true;
            txttenmon.Visible = true;
            txtthoigian.Visible = true;
            txtsocau.Visible = true;
            dtptgthi.Visible = true;
            lbltgthi.Visible = true;
            // câu hỏi
            lblmonthi.Visible = false;
            lblnoidungch.Visible = false;
            lbldapan.Visible = false;
            txtmach.Visible = false;
            cmbdapan.Visible = false;
            cmbmon.Visible = false;
            cmbloc.Visible = false;
            lblloc.Visible = false;
            txtnoidung.Visible = false;
            txtmach.Visible = false;
            lblmach.Visible = false;
            // Đổi tên lbl
            lblmamon.Text = "Mã môn:";
            lbltenmon.Text = "Tên môn:";
            lbltgthi.Text = "Thời gian thi:";
            lblsocau.Text = "Số câu:";
            lblthoigian.Text = "Thời gian:";
            // Làm sạch
            Lamsach();

            // datagridview
            grbcauhoi.Text = "Danh sách môn thi";
            sql = "select MaM as 'Mã Môn', Tenmon as 'Tên môn', Socau as 'Số câu', TGlambai as 'Thời gian làm bài', Thoigianthi as 'Ngày thi' from MONTHI";
            LoadDuLieu(sql);
            //ẩn hiện nút chức năng
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            txtmamon.Enabled = false;
            txtsocau.Enabled = false;
            txtthoigian.Enabled = false;
            txttenmon.Enabled = false;
            dtptgthi.Enabled = false;
        }

        //PHẦN SINH VIÊN CỦA QUẢN LÝ

        private void picsv_Click(object sender, EventArgs e)
        {
            // Đổi tên lbl
            lblmamon.Text = "Mã SV:";
            lbltenmon.Text = "Họ Đệm:";
            lbltgthi.Text = "Ngày sinh:";
            lblsocau.Text = "Tên:";
            lblthoigian.Text = "Mật khẩu:";
            grbcauhoi.Text = "Danh sách sinh viên";
            // Môn thi
            lblmamon.Visible = true;
            lbltenmon.Visible = true;
            lblsocau.Visible = true;
            lblthoigian.Visible = true;
            txtmamon.Visible = true;
            txttenmon.Visible = true;
            txtthoigian.Visible = true;
            txtsocau.Visible = true;
            dtptgthi.Visible = true;
            lbltgthi.Visible = true;
            // câu hỏi
            lblmonthi.Visible = false;
            lblnoidungch.Visible = false;
            lbldapan.Visible = false;
            txtmach.Visible = false;
            cmbdapan.Visible = false;
            cmbmon.Visible = false;
            cmbloc.Visible = false;
            lblloc.Visible = false;
            txtnoidung.Visible = false;
            txtmach.Visible = false;
            lblmach.Visible = false;
            txtthoigian.Text = "";
            // làm sạch
            Lamsach();
            // Load dữ liệu
            sql = "select MaSV as 'Mã SV', Hodem as 'Họ đệm', Ten as 'Tên', Ngaysinh as 'Ngày sinh', Matkhau as 'Mật khẩu' from SV";
            LoadDuLieu(sql);
        }


        //THAY ĐỔI NỘI DUNG Ở PHẦN NGÂN HÀNG CÂU HỎI
        private void dgvmenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //CÂU HỎI
            if (grbcauhoi.Text == "Danh sách câu hỏi")
            {
                txtmach.Text = dgvmenu[0, e.RowIndex].Value.ToString();
                cmbmon.Text = dgvmenu[1, e.RowIndex].Value.ToString();
                txtnoidung.Text = dgvmenu[2, e.RowIndex].Value.ToString();
                cmbdapan.Text = dgvmenu[3, e.RowIndex].Value.ToString();
            }
            //MÔN THI
            if (grbcauhoi.Text == "Danh sách môn thi")
            {
                txttenmon.Text = dgvmenu[1, e.RowIndex].Value.ToString();
                txtmamon.Text = dgvmenu[0, e.RowIndex].Value.ToString();
                txtsocau.Text = dgvmenu[2, e.RowIndex].Value.ToString();
                txtthoigian.Text = dgvmenu[3, e.RowIndex].Value.ToString();
                dtptgthi.Text = dgvmenu[4, e.RowIndex].Value.ToString();
            }
            //SINH VIÊN
            if (grbcauhoi.Text == "Danh sách sinh viên")
            {
                txttenmon.Text = dgvmenu[1, e.RowIndex].Value.ToString();
                txtmamon.Text = dgvmenu[0, e.RowIndex].Value.ToString();
                txtsocau.Text = dgvmenu[2, e.RowIndex].Value.ToString();
                txtthoigian.Text = dgvmenu[4, e.RowIndex].Value.ToString();
                dtptgthi.Text = dgvmenu[3, e.RowIndex].Value.ToString();
            }
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
        }

        // NÚT THÊM
        private void btnthem_Click(object sender, EventArgs e)
        {
            dgvmenu.CurrentCell = dgvmenu[0, dgvmenu.RowCount - 1];
            txtmach.Focus();
            txtmsv.Focus();
            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            btnhuy.Enabled = true;
            btnluu.Enabled = true;
            Chitiet(true);
            Lamsach();
        }

        // NÚT SỬA
        private void btnsua_Click(object sender, EventArgs e)
        {
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
            btnhuy.Enabled = true;
            Chitiet(true);
        }



        // NÚT HUỶ
        private void btnhuy_Click(object sender, EventArgs e)
        {
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            Chitiet(false);
            Lamsach();
            btnthem.Enabled = true;
        }       



        // NÚT LƯU: CÓ 2 TH LÀ SỬA HOẶC THÊM
        private void btnluu_Click(object sender, EventArgs e)
        {
            string ngaythi = dtptgthi.Value.ToString("yyyy-MM-dd");
            if (btnthem.Enabled == true)
            {
                if (grbcauhoi.Text == "Danh sách môn thi")
                {

                    sql = "insert into MONTHI values" + "('" + txtmamon.Text + "','" + txttenmon.Text + "','" + txtsocau.Text + "','" + txtthoigian.Text + "','" + ngaythi + "')";
                }
                if (grbcauhoi.Text == "Danh sách câu hỏi")
                {
                    sql = "insert into CAUHOI values" + "('" + txtmach.Text + "','" + cmbmon.Text + "','" + txtnoidung.Text + "','" + cmbdapan.Text + "')";
                }
                if (grbcauhoi.Text == "Danh sách sinh viên")
                {
                    sql = "insert into SV values" + "('" + txtmamon.Text + "',N'" + txttenmon.Text + "',N'" + txtsocau.Text + "','" + ngaythi + "','" + txtthoigian.Text + "')";
                }

                // thực thi lệnh
                
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm mới thành công!");
                
                
                if (grbcauhoi.Text == "Danh sách môn thi")
                {
                    sql = "select * from MONTHI";
                }
                if (grbcauhoi.Text == "Danh sách câu hỏi")
                {
                    sql = "select * from CAUHOI";
                }
                if (grbcauhoi.Text == "Danh sách sinh viên")
                {
                    sql = "select * from SV";
                }
                LoadDuLieu(sql);
            }
           if (btnsua.Enabled == true)
            {
                if (grbcauhoi.Text == "Danh sách môn thi")
                {

                    sql = "update MONTHI set Tenmon = N'" + txttenmon.Text + "',Socau ='" + txtsocau.Text + "',TGlambai ='" + txtthoigian.Text + "',Thoigianthi = '" + ngaythi + "' where MaM = '" + txtmamon.Text + "'";
                }
                if (grbcauhoi.Text == "Danh sách câu hỏi")
                {
                    sql = "update CAUHOI set MaM ='" + cmbmon.Text + "',Noidung =N'" + txtnoidung.Text + "',Dapan ='" + cmbdapan.Text + "' where MaCH ='" + txtmach.Text + "'";
                }
                if (grbcauhoi.Text == "Danh sách sinh viên")
                {
                    sql = "update SV set Hodem = N'" + txttenmon.Text + "',Ten =N'" + txtsocau.Text + "',Ngaysinh ='" + ngaythi + "',Matkhau = '" + txtthoigian.Text + "' where MaSV = '" + txtmamon.Text + "'";
                }
                // thực thi lệnh
               
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                if (grbcauhoi.Text == "Danh sách môn thi")
                {
                    sql = "select * from MONTHI";
                }
                if (grbcauhoi.Text == "Danh sách câu hỏi")
                {
                    sql = "select * from CAUHOI";
                }
                if (grbcauhoi.Text == "Danh sách sinh viên")
                {
                    sql = "select * from SV";
                }
                LoadDuLieu(sql);
                MessageBox.Show("Sửa thành công!");


            }
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            Chitiet(false);
            Lamsach();
            btnthem.Enabled = true;
        }      


        //NÚT XOÁ
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Xóa dữ liệu", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (grbcauhoi.Text == "Danh sách câu hỏi")
                {
                    sql = "Delete from CAUHOI where MaCH = '" + txtmach.Text + "'";
                }
                if (grbcauhoi.Text == "Danh sách môn thi")
                {
                    sql = "Delete from MONTHI where MaM = '" + txtmamon.Text + "'";
                }
                if (grbcauhoi.Text == "Danh sách sinh viên")
                {
                    sql = "delete from SV where MaSV = '" + txtmamon.Text + "'";
                }
                try
                {
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Lỗi Ràng buộc dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (grbcauhoi.Text == "Danh sách câu hỏi")
                {
                    sql = "select * from CAUHOI";
                }
                if (grbcauhoi.Text == "Danh sách môn thi")
                {
                    sql = "select * from MONTHI";
                }
                if (grbcauhoi.Text == "Danh sách sinh viên")
                {
                    sql = "select * from SV";
                }
                LoadDuLieu(sql);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tabbaocao_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cmbloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = "select CAUHOI.MaCH, CAUHOI.MaM, CAUHOI.Noidung, CAUHOI.Dapan " +
                "from CAUHOI,MONTHI where CAUHOI.MaM = MONTHI.MaM and Tenmon like N'%" + cmbloc.Text + "%'";
            LoadDuLieu(sql);
        }

        
        // CÁC NÚT Ở PHẦN TRỢ GIÚP
        private void linktimch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbltrogiup.Text = "*Tìm kiếm câu hỏi" + Environment.NewLine + "1.Nhập thông tin tìm kiếm (mã câu hỏi hoặc mã môn) vào ô tìm kiếm " + Environment.NewLine + "2.Thông tin sẽ hiện ra bảng danh sách câu hỏi ở bên dưới" + Environment.NewLine + "3.Chọn tên môn thi tương ứng để lọc các câu hỏi theo từng môn";
        }

        private void linkthemch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbltrogiup.Text = "*Thêm câu hỏi " + Environment.NewLine + "1.Nhấp chuột vào Thêm " + Environment.NewLine + "2.nhập thông tin vào các ô tương ứng " + Environment.NewLine + "3.sau khi nhập đầy đủ thông tin thì nhấp chuột vào Lưu";
        }

        private void linksuach_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbltrogiup.Text = "*Sửa câu hỏi " + Environment.NewLine + "1.nhấp vào câu hỏi cần sửa " + Environment.NewLine + "2.thông tin câu hỏi sẽ hiện vào ô tương ứng" + Environment.NewLine + "3.nhấp vào Sửa " + Environment.NewLine + "4.sửa thông tin cần thay đổi" + Environment.NewLine + "5.sau khi sửa xong nhấp vào Lưu";
        
    }

        private void linkxoach_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbltrogiup.Text = "*Xóa câu hỏi" + Environment.NewLine + "1.nhấp vào câu hỏi cần xóa " + Environment.NewLine + " 2.thông tin câu hỏi sẽ hiện vào ô tương ứng" + Environment.NewLine + " 3.nhấp vào Xóa ";
        
    }

        private void linktimmt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbltrogiup.Text = "*Tìm kiếm môn thi" + Environment.NewLine + "1.Nhập thông tin tìm kiếm (mã môn hoặc tên môn) vào ô tìm kiếm " + Environment.NewLine + " 2.Thông tin sẽ hiện ra bảng danh sách Môn thi ở bên dưới";

        }

        private void linkthemmt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbltrogiup.Text = "*Thêm môn thi" + Environment.NewLine + "1.Nhấp chuột vào Thêm " + Environment.NewLine + " 2.nhập thông tin vào các ô tương ứng" + Environment.NewLine + " 3.sau khi nhập đầy đủ thông tin thì nhấp chuột vào Lưu";
        
    }

        private void linksuamt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbltrogiup.Text = "*Sửa môn thi" + Environment.NewLine + "1.nhấp vào môn thi cần sửa" + Environment.NewLine + " 2.thông tin môn thi sẽ hiện vào ô tương ứng" + Environment.NewLine + " 3.nhấp vào Sửa " + Environment.NewLine + "4.sửa thông tin cần thay đổi" + Environment.NewLine + " 5.sau khi sửa xong nhấp vào Lưu";

        }

        private void linkxoamt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbltrogiup.Text = "*Xóa môn thi" + Environment.NewLine + "1.nhấp vào môn thi cần xóa" + Environment.NewLine + " 2.thông tin môn thi sẽ hiện vào ô tương ứng" + Environment.NewLine + "3.nhấp vào Xóa";
        
    }

        private void linktimsv_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbltrogiup.Text = "* Tìm kiếm sinh viên" + Environment.NewLine + "1.Nhập thông tin tìm kiếm (mã sinh viên hoặc tên sinh viên) vào ô tìm kiếm" + Environment.NewLine + " 2.Thông tin sẽ hiện ra bảng ";
        
    }

        private void linkthemsv_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbltrogiup.Text = "* Thêm sinh viên" + Environment.NewLine + "1.Nhấp chuột vào Thêm" + Environment.NewLine + " 2.nhập thông tin vào các ô tương ứng" + Environment.NewLine + " 3.sau khi nhập đầy đủ thông tin thì nhấp chuột vào Lưu";
        
    }

        private void linksuasv_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbltrogiup.Text = "* Sửa thông tin sinh viên" + Environment.NewLine + "1.nhấp vào sinh viên cần sửa" + Environment.NewLine + " 2.thông tin sinh viên sẽ hiện vào ô tương ứng" + Environment.NewLine + "3.nhấp vào Sửa" + Environment.NewLine + " 4.sửa thông tin cần thay đổi" + Environment.NewLine + "5.sau khi sửa xong nhấp vào Lưu";
        
    }

        private void linkxoasv_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbltrogiup.Text = "* Xóa thông tin sinh viên" + Environment.NewLine + "1.nhấp vào sinh viên cần xóa" + Environment.NewLine + " 2.thông tin sinh viên sẽ hiện vào ô tương ứng" + Environment.NewLine + "3.nhấp vào Xóa ";
        
    }

        private void label12_Click(object sender, EventArgs e)
        {
            lbltrogiup.Text = "*Xem bảng điểm " + Environment.NewLine + "1.Nhập tên lớp cần xem bảng điểm." + Environment.NewLine + "2.Chọn tên môn học." + Environment.NewLine + "3.Nhập vào MSV nếu cần xem điểm của 1 sinh viên." + Environment.NewLine + "4.Nhấn nút In nếu muốn in ra bảng điểm đã chọn.";
        
    }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbltrogiup.Text = "*Xem bảng điểm " + Environment.NewLine + "1.Nhập tên lớp cần xem bảng điểm." + Environment.NewLine + "2.Chọn tên môn học." + Environment.NewLine + "3.Nhập vào MSV nếu cần xem điểm của 1 sinh viên." + Environment.NewLine + "4.Nhấn nút In nếu muốn in ra bảng điểm đã chọn.";
        
    }

        private void label13_Click(object sender, EventArgs e)
        {
            lbltrogiup.Text = "*Xem bài thi " + Environment.NewLine + "1.Nhập MSV." + Environment.NewLine + "2.Chọn tên môn." + Environment.NewLine + "3.Chọn ngày thi." + Environment.NewLine + "4.Nhấn nút In nếu muốn in ra bài thi của sinh viên đó.";
        
    }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbltrogiup.Text = "*Xem bài thi " + Environment.NewLine + "1.Nhập MSV." + Environment.NewLine + "2.Chọn tên môn." + Environment.NewLine + "3.Chọn ngày thi." + Environment.NewLine + "4.Nhấn nút In nếu muốn in ra bài thi của sinh viên đó.";
        
    }


        //NÚT PHẦN BÁO CÁO: CỦA A ẤY CÓ THÊM BANGDIEM VÀ BAILAMCUASV MÀ MÌNH CHƯA CÓ :(((
        private void txtmsv_TextChanged(object sender, EventArgs e)
        {
            if(grbtim.Text == "Bảng điểm")
            {
                sql = "SELECT KETQUA.MaSV as 'Mã SV', SV.Hodem as 'Họ đệm', SV.Ten as 'Tên', MONTHI.Tenmon as 'Tên Môn',KETQUA.Diem AS 'Điểm', KETQUA.Lanthi as 'Lần thi', LOP.MaL AS 'Mã Lớp' FROM KETQUA,SV,MONTHI,LOP,  LOPSV where LOPSV.MaL = LOP.MaL and LOP.MaM = MONTHI.MaM and MONTHI.MaM = KETQUA.MaM and LOPSV.MaSV = SV.MaSV AND KETQUA.MaSV = SV.MaSV and KETQUA.MaSV like '%" + txtmsv.Text + "%'";
                    
            }
            else
            {
                sql = "select distinct BAILAM.MaSV as 'Mã SV',  SV.Hodem + ''+ SV.Ten as 'Họ Tên', MONTHI.Tenmon as 'Tên môn', BAILAM.MaCH as 'Mã CH', BAILAM.Traloi as 'Trả lời', BAILAM.Ngaythi as 'Ngày thi' from BAILAM, SV, MONTHI, CAUHOI where BAILAM.MaSV = SV.MaSV and CAUHOI.MaM = MONTHI.MaM and BAILAM.MaCH = CAUHOI.MaCH and BAILAM.MaSV like '%" + txtmsv.Text + "%'";
            }
            try
            {
                dt = new DataTable();
                dt.Clear();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
                dgvbc.DataSource = dt;
            }
            catch { }
        }

       
        private void picbangdiem_Click(object sender, EventArgs e)
        {
            grbtim.Text = "Bảng điểm";
            sql = "SELECT KETQUA.MaSV as 'Mã SV', SV.Hodem as 'Họ đệm', SV.Ten as 'Tên', MONTHI.Tenmon as 'Tên Môn', LOP.MaL AS 'Mã Lớp', KETQUA.Diem AS 'Điểm', KETQUA.Lanthi as 'Lần thi' FROM KETQUA,SV,MONTHI,LOP,  LOPSV where LOPSV.MaL = LOP.MaL and LOP.MaM = MONTHI.MaM and MONTHI.MaM = KETQUA.MaM and LOPSV.MaSV = SV.MaSV AND KETQUA.MaSV = SV.MaSV";
            dt = new DataTable();
            dt.Clear();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            dgvbc.DataSource = dt;
        }

        private void picbaithi_Click(object sender, EventArgs e)
        {
            grbtim.Text = "Bài làm";
            sql = "select distinct BAILAM.MaSV as 'Mã SV',  SV.Hodem + ''+" +
                " SV.Ten as 'Họ Tên', MONTHI.Tenmon as 'Tên môn', " +
                "BAILAM.MaCH as 'Mã CH', BAILAM.Traloi as 'Trả lời', " +
                "BAILAM.Ngaythi as 'Ngày thi' from BAILAM, SV, MONTHI, CAUHOI " +
                "where BAILAM.MaSV = SV.MaSV and CAUHOI.MaM = MONTHI.MaM and BAILAM.MaCH = CAUHOI.MaCH";
            dt = new DataTable();
            dt.Clear();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            dgvbc.DataSource = dt;
        }

        private void tabquanly_Click(object sender, EventArgs e)
        {

        }

        private void grbtimch_Enter(object sender, EventArgs e)
        {

        }

        private void cmbtenmon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvmenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //CÂU HỎI
            if (grbcauhoi.Text == "Danh sách câu hỏi")
            {
                txtmach.Text = dgvmenu[0, e.RowIndex].Value.ToString();
                cmbmon.Text = dgvmenu[1, e.RowIndex].Value.ToString();
                txtnoidung.Text = dgvmenu[2, e.RowIndex].Value.ToString();
                cmbdapan.Text = dgvmenu[3, e.RowIndex].Value.ToString();
            }
            //MÔN THI
            if (grbcauhoi.Text == "Danh sách môn thi")
            {
                txttenmon.Text = dgvmenu[1, e.RowIndex].Value.ToString();
                txtmamon.Text = dgvmenu[0, e.RowIndex].Value.ToString();
                txtsocau.Text = dgvmenu[2, e.RowIndex].Value.ToString();
                txtthoigian.Text = dgvmenu[3, e.RowIndex].Value.ToString();
                dtptgthi.Text = dgvmenu[4, e.RowIndex].Value.ToString();
            }
            //SINH VIÊN
            if (grbcauhoi.Text == "Danh sách sinh viên")
            {
                txttenmon.Text = dgvmenu[1, e.RowIndex].Value.ToString();
                txtmamon.Text = dgvmenu[0, e.RowIndex].Value.ToString();
                txtsocau.Text = dgvmenu[2, e.RowIndex].Value.ToString();
                txtthoigian.Text = dgvmenu[4, e.RowIndex].Value.ToString();
                dtptgthi.Text = dgvmenu[3, e.RowIndex].Value.ToString();
            }
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnexit2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void thoátChươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dgvmenu_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbtenmon_TextChanged(object sender, EventArgs e)
        {
            if (grbtim.Text == "Bảng điểm")
            {
                sql = "SELECT KETQUA.MaSV as 'Mã SV', SV.Hodem as 'Họ đệm', SV.Ten as 'Tên', MONTHI.Tenmon as 'Tên Môn', LOP.MaL AS 'Mã Lớp', KETQUA.Diem AS 'Điểm', KETQUA.Lanthi as 'Lần thi' FROM KETQUA,SV,MONTHI,LOP,  LOPSV where LOPSV.MaL = LOP.MaL and LOP.MaM = MONTHI.MaM and MONTHI.MaM = KETQUA.MaM and LOPSV.MaSV = SV.MaSV AND KETQUA.MaSV = SV.MaSV" +
                    "  and KETQUA.MaM like N'%" + cmbtenmon.Text + "%'"; 
            }
            else
            {
                sql = "select distinct BAILAM.MaSV as 'Mã SV',  SV.Hodem + '' + SV.Ten as 'Họ Tên', MONTHI.Tenmon as 'Tên môn', BAILAM.MaCH as 'Mã CH', BAILAM.Traloi as 'Trả lời', BAILAM.Ngaythi as 'Ngày thi' from BAILAM, SV, MONTHI, CAUHOI where BAILAM.MaSV = SV.MaSV and CAUHOI.MaM = MONTHI.MaM and BAILAM.MaCH = CAUHOI.MaCH and MONTHI.MaM like N'%" + cmbtenmon.Text + "%'";
            }
            try
            {
                dt = new DataTable();
                dt.Clear();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
                dgvbc.DataSource = dt;
            }
            catch { }
        }

        private void txtMalop_TextChanged(object sender, EventArgs e)
        {
            if (grbtim.Text == "Bảng điểm")
            {
                sql = "SELECT KETQUA.MaSV as 'Mã SV', SV.Hodem as 'Họ đệm', SV.Ten as 'Tên', MONTHI.Tenmon as 'Tên Môn', LOP.MaL AS 'Mã Lớp', KETQUA.Diem AS 'Điểm', KETQUA.Lanthi as 'Lần thi' FROM KETQUA,SV,MONTHI,LOP,  LOPSV where LOPSV.MaL = LOP.MaL and LOP.MaM = MONTHI.MaM and MONTHI.MaM = KETQUA.MaM and LOPSV.MaSV = SV.MaSV AND KETQUA.MaSV = SV.MaSV and LOP.MaL like '%" + txtMalop.Text + "%'";
            }
            else
            {
                txtMalop.Visible = false;
                label8.Visible = false;


            }
            try
            {
                dt = new DataTable();
                dt.Clear();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
                dgvbc.DataSource = dt;
            }
            catch { }
        }

        private void btnbclop_Click(object sender, EventArgs e)
        {   
            
            rptlop rpt = new rptlop();
            sql = "SELECT distinct LOP.MaL,TenL, SV.MaSV,Hodem,Ten, KETQUA.Diem,Lanthi from LOP, SV, KETQUA, LOPSV " +
                " WHERE SV.MaSV = KETQUA.MaSV AND SV.MaSV = LOPSV.MaSV" +
                " and LOPSV.MaL = LOP.MaL AND LOPSV.MaL = '" + txtMalop.Text + "'";
            da = new SqlDataAdapter(sql, conn);
            DataTable datarpt = new DataTable("dtDiemtheolop");
            datarpt.Clear();
            da.Fill(datarpt);
            rpt.SetDataSource(datarpt);
            //rpt.DataDefinition.FormulaFields["MaL"].Text = "'" + txtMalop.Text + "'";
            rptlopprv rp = new rptlopprv(rpt);
            rp.Show();
        }

        private void btnbcmon_Click(object sender, EventArgs e)
        {
            rptmon rpt = new rptmon();
            sql = "SELECT distinct MONTHI.MaM, MONTHI.Tenmon, SV.MaSV,Hodem,Ten, KETQUA.Diem,Lanthi " +
                "from MONTHI, SV, KETQUA,LOP,LOPSV WHERE SV.MaSV = KETQUA.MaSV " +
                "AND SV.MaSV = LOPSV.MaSV AND LOP.MaM = MONTHI.MaM AND LOPSV.MaL = LOP.MaL " +
                "AND MONTHI.MaM ='" + cmbtenmon.Text + "'";
            da = new SqlDataAdapter(sql, conn);
            DataTable datarpt = new DataTable("dtDiemtheomon");
            datarpt.Clear();
            da.Fill(datarpt);
            rpt.SetDataSource(datarpt);
            //rpt.DataDefinition.FormulaFields["MaL"].Text = "'" + txtMalop.Text + "'";
            rptmonprv rp = new rptmonprv(rpt);
            rp.Show();
        }

        private void txtmach_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbmon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbtenmon_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //NÚT TÌM KIẾM
        private void txttim_TextChanged(object sender, EventArgs e)
        {
            if (grbcauhoi.Text == "Danh sách câu hỏi")
            {
                sql = "select * from CAUHOI where MaCH like '%" + txttim.Text + "%' or MaM like '%" + txttim.Text + "%' or Noidung like '%" + txttim.Text + "%'" ;
            }
            if (grbcauhoi.Text == "Danh sách môn thi")
            {
                sql = " select * from MONTHI where MaM like '%" + txttim.Text + "%' or TenMon like N'%" + txttim.Text + "%'";
            }
            if (grbcauhoi.Text == "Danh sách sinh viên")
            {
                sql = "select * from SV where MaSV like '%" + txttim.Text + "%' or Ten like N'%" + txttim.Text + "%'";
            }
            try
            {
                LoadDuLieu(sql);
            }
            catch { }
        }







    }
    
}
