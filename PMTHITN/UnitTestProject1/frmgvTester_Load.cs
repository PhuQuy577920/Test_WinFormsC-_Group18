using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PMTHITN;

namespace UnitTestProject_frmgv
{
    [TestClass]
    public class frmgvTests
    {
        [TestMethod]
        public void frmgv_Load_OpensConnection()
        {
            // Arrange
            var form = new frmgv();

            // Act
            form.frmgv_Load(null, null);

            // Assert
            Assert.IsTrue(form.conn.State == ConnectionState.Open);
        }
        private SqlConnection conn;
        private SqlDataAdapter da;
        private DataTable dt;
        private object dgvmenu;

        [TestInitialize]
        public void Setup()
        {
            // Thiết lập các giá trị ban đầu cho các biến cần thiết
            conn = new SqlConnection("Data Source=PHUQUY577920\\SQLEXPRESS;Initial Catalog=THITRACNGHIEM;Integrated Security=True");
            da = new SqlDataAdapter();
            dt = new DataTable();
            dgvmenu = new object(); // Chỉ là giả lập, bạn có thể sử dụng bất kỳ giá trị thích hợp nào
        }
        
        [TestMethod]
        public void TestChitiet()
        {
            // Arrange
            var form = new frmgv(); // Thay thế frmgv bằng tên thực của lớp của bạn
            var enabled = true;

            // Act
            form.Chitiet(enabled);

            // Assert
            Assert.AreEqual(enabled, form.txtmamon.Enabled);
            Assert.AreEqual(enabled, form.txtsocau.Enabled);
            Assert.AreEqual(enabled, form.txtthoigian.Enabled);
            Assert.AreEqual(enabled, form.txttenmon.Enabled);
            Assert.AreEqual(enabled, form.dtptgthi.Enabled);
            Assert.AreEqual(enabled, form.txtmach.Enabled);
            Assert.AreEqual(enabled, form.txtnoidung.Enabled);
            Assert.AreEqual(enabled, form.cmbdapan.Enabled);
            Assert.AreEqual(enabled, form.cmbmon.Enabled);
        }

        [TestMethod]
        public void TestLamsach()
        {
            // Arrange
            var form = new frmgv(); // Thay thế frmgv bằng tên thực của lớp của bạn

            // Act
            form.Lamsach();

            // Assert
            Assert.AreEqual(string.Empty, form.txtmach.Text);
            Assert.AreEqual(string.Empty, form.txtmamon.Text);
            Assert.AreEqual(string.Empty, form.txtnoidung.Text);
            Assert.AreEqual(string.Empty, form.txtsocau.Text);
            Assert.AreEqual(string.Empty, form.txttenmon.Text);
            Assert.AreEqual(string.Empty, form.dtptgthi.Text);
            Assert.AreEqual(string.Empty, form.txtthoigian.Text);
            Assert.AreEqual(string.Empty, form.cmbdapan.Text);
            Assert.AreEqual(string.Empty, form.cmbmon.Text);
        }

    }
}
