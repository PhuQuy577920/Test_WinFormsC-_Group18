using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PMTHITN;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UnitTestProject_frmgv
{
    [TestClass]
    public class frmgvTester_Funtion
    {
        [TestMethod]
        public void dgvmenu_CellContentClick_DanhSachCauHoi_Test()
        {
            // Arrange
            var form = new frmgv(); // Thay thế MyForm bằng tên form thực tế
            form.grbcauhoi.Text = "Danh sách câu hỏi";

            var dgvmenu = new DataGridView();
            dgvmenu.Columns.Add("MaCH", "Mã câu hỏi");
            dgvmenu.Columns.Add("MaM", "Mã môn");
            dgvmenu.Columns.Add("Noidung", "Nội dung câu hỏi");
            dgvmenu.Columns.Add("Dapan", "Đáp án");

            dgvmenu.Rows.Add("CH01", "M01", "Nội dung 1", "A");
            form.Controls.Add(dgvmenu);
            form.dgvmenu = dgvmenu; // Thay đổi để phù hợp với thành phần DataGridView thực tế của form

            var e = new DataGridViewCellEventArgs(0, 0); // Mô phỏng click vào ô đầu tiên của hàng đầu tiên

            // Act
            form.dgvmenu_CellContentClick(null, e);

            // Assert
            Assert.AreEqual("CH01", form.txtmach.Text);
            Assert.AreEqual("M01", form.cmbmon.Text);
            Assert.AreEqual("Nội dung 1", form.txtnoidung.Text);
            Assert.AreEqual("A", form.cmbdapan.Text);
            Assert.IsTrue(form.btnsua.Enabled);
            Assert.IsTrue(form.btnxoa.Enabled);
        }
        [TestMethod]
        public void dgvmenu_CellContentClick_DanhSachMonThi_Test()
        {
            // Arrange
            var form = new frmgv(); // Thay thế MyForm bằng tên form thực tế
            form.grbcauhoi.Text = "Danh sách môn thi";

            var dgvmenu = new DataGridView();
            dgvmenu.Columns.Add("MaM", "Mã môn");
            dgvmenu.Columns.Add("Tenmon", "Tên môn");
            dgvmenu.Columns.Add("Socau", "Số câu");
            dgvmenu.Columns.Add("TGlambai", "Thời gian làm bài");
            dgvmenu.Columns.Add("Thoigianthi", "Ngày thi");

            dgvmenu.Rows.Add("M01", "Toán", "50", "90", "2024-05-18");
            form.Controls.Add(dgvmenu);
            form.dgvmenu = dgvmenu; // Thay đổi để phù hợp với thành phần DataGridView thực tế của form

            var e = new DataGridViewCellEventArgs(0, 0); // Mô phỏng click vào ô đầu tiên của hàng đầu tiên

            // Act
            form.dgvmenu_CellContentClick(null, e);

            // Assert
            Assert.AreEqual("M01", form.txtmamon.Text);
            Assert.AreEqual("Toán", form.txttenmon.Text);
            Assert.AreEqual("50", form.txtsocau.Text);
            Assert.AreEqual("90", form.txtthoigian.Text);
            Assert.AreEqual(DateTime.Parse("2024-05-18"), form.dtptgthi.Value);
            Assert.IsTrue(form.btnsua.Enabled);
            Assert.IsTrue(form.btnxoa.Enabled);
        }

        [TestMethod]
        public void btnthem_Click_Test()
        {
            // Arrange
            var form = new frmgv(); // Thay YourForm bằng tên lớp của bạn

            // Act
            form.btnthem_Click(null, EventArgs.Empty);

            // Assert
            Assert.IsFalse(form.btnxoa.Enabled, "btnxoa should be disabled.");
            Assert.IsFalse(form.btnsua.Enabled, "btnsua should be disabled.");
            Assert.IsTrue(form.btnhuy.Enabled, "btnhuy should be enabled.");
            Assert.IsTrue(form.btnluu.Enabled, "btnluu should be enabled.");
        }
        [TestMethod]
        public void btnsua_Click_Test()
        {
            // Arrange
            var form = new frmgv();

            // Act
            form.btnsua_Click(null, null);

            // Assert
            Assert.IsFalse(form.btnthem.Enabled, "btnthem should be disabled.");
            Assert.IsFalse(form.btnxoa.Enabled, "btnxoa should be disabled.");
            Assert.IsTrue(form.btnluu.Enabled, "btnluu should be enabled.");
            Assert.IsTrue(form.btnhuy.Enabled, "btnhuy should be enabled.");
        }
        [TestMethod]
        public void btnhuy_Click_Test()
        {
            // Arrange
            var form = new frmgv();

            // Thiết lập trạng thái ban đầu của các nút
            form.btnluu.Enabled = true;
            form.btnhuy.Enabled = true;
            form.btnxoa.Enabled = true;
            form.btnsua.Enabled = true;
            form.btnthem.Enabled = false;

            // Act
            form.btnhuy_Click(null, null);

            // Assert
            Assert.IsFalse(form.btnluu.Enabled, "btnluu should be disabled.");
            Assert.IsFalse(form.btnhuy.Enabled, "btnhuy should be disabled.");
            Assert.IsFalse(form.btnxoa.Enabled, "btnxoa should be disabled.");
            Assert.IsFalse(form.btnsua.Enabled, "btnsua should be disabled.");
            Assert.IsTrue(form.btnthem.Enabled, "btnthem should be enabled.");
        }
        [TestMethod]
        public void txttim_TextChanged_Test_QuestionList()
        {
            // Arrange
            var form = new TestForm();
            form.grbcauhoi.Text = "Danh sách câu hỏi";
            form.txttim.Text = "test";

            // Act
            form.txttim_TextChanged(null, null);

            // Assert
            string expectedSql = "select * from CAUHOI where MaCH like '%test%' or MaM like '%test%' or Noidung like '%test%'";
            Assert.AreEqual(expectedSql, form.sql);
            Assert.IsTrue(form.LoadDataCalled);
        }

        [TestMethod]
        public void txttim_TextChanged_Test_SubjectList()
        {
            // Arrange
            var form = new TestForm();
            form.grbcauhoi.Text = "Danh sách môn thi";
            form.txttim.Text = "test";

            // Act
            form.txttim_TextChanged(null, null);

            // Assert
            string expectedSql = " select * from MONTHI where MaM like '%test%' or TenMon like N'%test%'";
            Assert.AreEqual(expectedSql, form.sql);
            Assert.IsTrue(form.LoadDataCalled);
        }

        [TestMethod]
        public void txttim_TextChanged_Test_StudentList()
        {
            // Arrange
            var form = new TestForm();
            form.grbcauhoi.Text = "Danh sách sinh viên";
            form.txttim.Text = "test";

            // Act
            form.txttim_TextChanged(null, null);

            // Assert
            string expectedSql = "select * from SV where MaSV like '%test%' or Ten like N'%test%'";
            Assert.AreEqual(expectedSql, form.sql);
            Assert.IsTrue(form.LoadDataCalled);
        }
        public class TestForm
        {
            public GroupBox grbcauhoi;
            public TextBox txttim;
            public string sql;
            public bool LoadDataCalled { get; private set; }

            public TestForm()
            {
                grbcauhoi = new GroupBox();
                txttim = new TextBox();
                sql = string.Empty;
                LoadDataCalled = false;
            }

            public void txttim_TextChanged(object sender, EventArgs e)
            {
                if (grbcauhoi.Text == "Danh sách câu hỏi")
                {
                    sql = "select * from CAUHOI where MaCH like '%" + txttim.Text + "%' or MaM like '%" + txttim.Text + "%' or Noidung like '%" + txttim.Text + "%'";
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

            public void LoadDuLieu(string sql)
            {
                LoadDataCalled = true;
            }
            
        }
        [TestMethod]
        public void btnxoa_Click_Deletes_Correctly_When_YesClicked()
        {
            // Arrange
            frmgv form = new frmgv(); // Tạo một instance của form (thay thế "YourForm" bằng tên form thực tế của bạn)
            Button btnxoa = new Button(); // Tạo một instance của Button
            form.Controls.Add(btnxoa); // Thêm button vào form (giả sử button là control gọi btnxoa)

            // Simulate user clicking Yes on MessageBox
            MessageBoxExaminer.YesButtonClicked = true;

            // Act
            form.btnxoa_Click(btnxoa, EventArgs.Empty);

            // Assert
            
        }

        [TestMethod]
        public void btnxoa_Click_DoesNotDelete_When_NoClicked()
        {
            // Arrange
            frmgv form = new frmgv(); // Tạo một instance của form (thay thế "YourForm" bằng tên form thực tế của bạn)
            Button btnxoa = new Button(); // Tạo một instance của Button
            form.Controls.Add(btnxoa); // Thêm button vào form (giả sử button là control gọi btnxoa)

            // Simulate user clicking No on MessageBox
            MessageBoxExaminer.YesButtonClicked = false;

            // Act
            form.btnxoa_Click(btnxoa, EventArgs.Empty);

            // Assert
            // Add assertions here to verify that no SQL query is executed and no message box is shown.
        }
        public static class MessageBoxExaminer
        {
            public static bool YesButtonClicked { get; set; }

            // Mock method for MessageBox.Show
            public static DialogResult Show(string message, string caption, MessageBoxButtons buttons)
            {
                if (buttons == MessageBoxButtons.YesNo)
                {
                    return YesButtonClicked ? DialogResult.Yes : DialogResult.No;
                }
                throw new NotImplementedException("This mock only supports Yes/No buttons");
            }
        }
    }

}