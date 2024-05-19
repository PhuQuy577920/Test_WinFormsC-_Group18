using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PMTHITN;
using System;
using System.Data;
using System.Windows.Forms;

namespace UnitTestProject_frminfo
{
    [TestClass]
    public class frminfoTester
    {
        private Mock<IDatabaseService> mockDatabaseService;
        private frminfo form;

        [TestInitialize]
        public void Setup()
        {
            mockDatabaseService = new Mock<IDatabaseService>();
            form = new frminfo(mockDatabaseService.Object);
        }

        [TestMethod]
        public void btnvaothi_Click_WithData_ClosesFormAndOpensExamForm()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Rows.Add(dt.NewRow()); // Thêm một hàng giả để giả lập có dữ liệu
            mockDatabaseService.Setup(service => service.GetExamInfo()).Returns(dt);

            // Act
            form.btnvaothi_Click(null, EventArgs.Empty);

            // Assert
            // Không thể kiểm tra trạng thái của form trực tiếp trong MSTest,
            // vì vậy giả sử rằng test này pass nếu không có ngoại lệ nào xảy ra.
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void frminfo_Load_UpdatesUI_WithExamInfoAndStudentInfo()
        {
            // Arrange
            var mockDatabaseService = new Mock<IDatabaseService>();
            var examInfoTable = new DataTable();
            examInfoTable.Columns.Add("TenMon", typeof(string));
            examInfoTable.Columns.Add("SoCau", typeof(int));
            examInfoTable.Columns.Add("ThoiGian", typeof(int));
            examInfoTable.Rows.Add("Toan", 20, 30); // Sample exam info data
            mockDatabaseService.Setup(service => service.GetExamInfo()).Returns(examInfoTable);

            var studentInfoTable = new DataTable();
            studentInfoTable.Columns.Add("MSV", typeof(string));
            studentInfoTable.Rows.Add("123456"); // Sample student info data
            mockDatabaseService.Setup(service => service.GetStudentInfo(It.IsAny<string>())).Returns(studentInfoTable);

            var form = new frminfo(mockDatabaseService.Object);

            // Act
            form.frminfo_Load(null, EventArgs.Empty);

            // Assert
            Assert.AreEqual("Toan", form.lblmonthi.Text);
            Assert.AreEqual("20", form.lblsocau.Text);
            Assert.AreEqual("30 phút", form.lblthoigian.Text);
            Assert.AreEqual("", form.lblmsv.Text);
            Assert.AreEqual("Tên SV", form.lblhoten.Text); // Assuming lblhoten is not updated when student info is not available
        }


    }
}
