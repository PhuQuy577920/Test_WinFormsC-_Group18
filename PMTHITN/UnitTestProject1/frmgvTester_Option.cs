using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMTHITN;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Moq;

namespace UnitTestProject_frmgv
{

    [TestClass]
    public class frmgvTestsClickOpTion
    {
        [TestMethod]
        public void piccauhoi_Click_Test()
        {
            // Arrange
            var connection = new SqlConnection("Data Source=PHUQUY577920\\SQLEXPRESS;Initial Catalog=THITRACNGHIEM;Integrated Security=True");
            var form = new frmgv(); // Tạo một đối tượng form
            form.conn = connection; // Gán đối tượng SqlConnection đã khởi tạo vào form

            // Act
            form.piccauhoi_Click(null, null); // Gọi phương thức piccauhoi_Click

            // Assert
            // Kiểm tra các thuộc tính của DataGridView
            Assert.AreEqual("Danh sách câu hỏi", form.grbcauhoi.Text); // Kiểm tra Text của GroupBox
            Assert.AreEqual("select MaCH as 'Mã câu hỏi', MaM as 'Mã môn', Noidung as ' Nội dung câu hỏi', Dapan as 'Đáp án' from CAUHOI", form.sql); // Kiểm tra câu truy vấn SQL
            Assert.IsNotNull(form.dt); // Kiểm tra xem DataTable có được load dữ liệu không

            // Kiểm tra trạng thái của các nút và các thành phần khác
            Assert.IsFalse(form.btnsua.Enabled); // Kiểm tra trạng thái của nút btnsua
            Assert.IsFalse(form.btnxoa.Enabled); // Kiểm tra trạng thái của nút btnxoa
            Assert.IsFalse(form.btnluu.Enabled); // Kiểm tra trạng thái của nút btnluu
            Assert.IsFalse(form.btnhuy.Enabled); // Kiểm tra trạng thái của nút btnhuy
            Assert.IsFalse(form.txtmach.Enabled); // Kiểm tra trạng thái của TextBox txtmach
            Assert.IsFalse(form.cmbmon.Enabled); // Kiểm tra trạng thái của ComboBox cmbmon
            Assert.IsFalse(form.txtnoidung.Enabled); // Kiểm tra trạng thái của TextBox txtnoidung
            Assert.IsFalse(form.cmbdapan.Enabled); // Kiểm tra trạng thái của ComboBox cmbdapan
        }
        [TestMethod]
        public void picmonthi_Click_Test()
        {
            // Arrange
            var connection = new SqlConnection("Data Source=PHUQUY577920\\SQLEXPRESS;Initial Catalog=THITRACNGHIEM;Integrated Security=True");
            var form = new frmgv(); // Tạo một đối tượng form
            form.conn = connection; // Gán đối tượng SqlConnection đã khởi tạo vào form

            // Act
            form.picmonthi_Click(null, null); // Gọi phương thức piccauhoi_Click

            // Assert
            // Kiểm tra các thuộc tính của DataGridView
            Assert.AreEqual("Danh sách môn thi", form.grbcauhoi.Text); // Kiểm tra Text của GroupBox
            Assert.AreEqual("select MaM as 'Mã Môn', Tenmon as 'Tên môn', Socau as 'Số câu', TGlambai as 'Thời gian làm bài', Thoigianthi as 'Ngày thi' from MONTHI", form.sql); // Kiểm tra câu truy vấn SQL
            Assert.IsNotNull(form.dt); // Kiểm tra xem DataTable có được load dữ liệu không

            // Kiểm tra trạng thái của các nút và các thành phần khác
            Assert.IsFalse(form.btnsua.Enabled); // Kiểm tra trạng thái của nút btnsua
            Assert.IsFalse(form.btnxoa.Enabled); // Kiểm tra trạng thái của nút btnxoa
            Assert.IsFalse(form.btnluu.Enabled); // Kiểm tra trạng thái của nút btnluu
            Assert.IsFalse(form.btnhuy.Enabled); // Kiểm tra trạng thái của nút btnhuy
            Assert.IsFalse(form.txtmamon.Enabled); // Kiểm tra trạng thái của TextBox txtmamon
            Assert.IsFalse(form.txtsocau.Enabled); // Kiểm tra trạng thái của TextBox txtsocau
            Assert.IsFalse(form.txtthoigian.Enabled); // Kiểm tra trạng thái của TextBox txtthoigian
            Assert.IsFalse(form.txttenmon.Enabled); // Kiểm tra trạng thái của TextBox txttenmon
            Assert.IsFalse(form.dtptgthi.Enabled); // Kiểm tra trạng thái của DateTimePicker dtptgthi
        }

        [TestMethod]
        public void picsv_Click_Test()
        {
            // Arrange
            var connection = new SqlConnection("Data Source=PHUQUY577920\\SQLEXPRESS;Initial Catalog=THITRACNGHIEM;Integrated Security=True");
            var form = new frmgv(); // Tạo một đối tượng form
            form.conn = connection; // Gán đối tượng SqlConnection đã khởi tạo vào form

            // Act
            form.picsv_Click(null,null); // Gọi phương thức LoadDuLieu với câu truy vấn đã cho

            // Assert
            // Kiểm tra việc load dữ liệu
            Assert.AreEqual("select MaSV as 'Mã SV', Hodem as 'Họ đệm', Ten as 'Tên', Ngaysinh as 'Ngày sinh', Matkhau as 'Mật khẩu' from SV", form.sql);
            Assert.IsNotNull(form.dt);
            // Kiểm tra trạng thái của các nút và các thành phần khác
            Assert.IsFalse(form.lblmonthi.Visible);
            Assert.IsFalse(form.lblnoidungch.Visible);
            Assert.IsFalse(form.lbldapan.Visible);
            Assert.IsFalse(form.txtmach.Visible);
            Assert.IsFalse(form.cmbdapan.Visible);
            Assert.IsFalse(form.cmbmon.Visible);
            Assert.IsFalse(form.cmbloc.Visible);
            Assert.IsFalse(form.lblloc.Visible);
            Assert.IsFalse(form.txtnoidung.Visible);
            Assert.IsFalse(form.txtmach.Visible);
            Assert.IsFalse(form.lblmach.Visible);

        }

    }
    
}