using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PMTHITN;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Linq;
namespace UnitTestProject_frmlogin
{
    [TestClass]
    public class frmloginsTester
    {
        public class MessageBoxWrapper
        {
            public virtual DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
            {
                return MessageBox.Show(text, caption, buttons, icon);
            }
        }
        [TestMethod]
        public void linkquenmk_LinkClicked_ShowsCorrectMessage()
        {
            // Arrange
            var mockForm = new Mock<frmlogin>();
            mockForm.CallBase = true; // Ensures that calls to the base class are not overridden

            // Act
            mockForm.Object.linkquenmk_LinkClicked(null, null);

            // Assert
            mockForm.Verify(form => form.ShowMessage(
                "Bạn vui lòng thông báo với giám thị coi thi để xin cấp lại Mật khẩu)",
                "Thông Báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information), Times.Once);
        }
        /* [TestMethod]
         public void btnlogin_Click_GvLogin_Success()
         {
             // Arrange
             var txtUser = new TextBox() { Text = "valid_username" };
             var txtPassword = new TextBox() { Text = "valid_password" };

             var mockConn = new Mock<SqlConnection>();
             var mockCmd = new Mock<SqlCommand>();

             var mockForm = new Mock<frmlogin>(mockConn.Object)
             {
                 CallBase = true
             };
             mockForm.SetupProperty(f => f.txtuser, txtUser);
             mockForm.SetupProperty(f => f.txtmk, txtPassword);
             mockForm.Setup(f => f.Hide());

             mockConn.Setup(c => c.CreateCommand()).Returns(mockCmd.Object);

             var gvFlag = true;

             mockForm.Object.gvflag = gvFlag;

             mockCmd.SetupSequence(c => c.ExecuteScalar())
                 .Returns(1); // return 1 for successful login

             // Use a variable to track if MessageBox.Show is called
             bool messageBoxCalled = false;

             // Create a mock for MessageBoxWrapper
             var mockMessageBoxWrapper = new Mock<MessageBoxWrapper>();
             mockMessageBoxWrapper.Setup(wrapper => wrapper.Show(
                 It.IsAny<string>(),
                 It.IsAny<string>(),
                 It.IsAny<MessageBoxButtons>(),
                 It.IsAny<MessageBoxIcon>()))
                 .Callback(() => messageBoxCalled = true);

             // Act
             // Inject the mock MessageBoxWrapper into the form
             var frmLogin = mockForm.Object;
             frmLogin.messageBoxWrapper = mockMessageBoxWrapper.Object;
             frmLogin.btnlogin_Click(null, EventArgs.Empty);

             // Assert
             // Check if MessageBoxWrapper.Show was called
             Assert.IsTrue(messageBoxCalled);
             mockForm.Verify(f => f.Hide(), Times.Once);
         }
         */
        
        [TestMethod]

        public void btnlogin_Click_GV()
        {
            // Arrange
            var conn = new SqlConnection("Data Source=PHUQUY577920\\SQLEXPRESS;Initial Catalog=THITRACNGHIEM;Integrated Security=True");
            var form = new frmgv();
            var txtuser = new TextBox();
            txtuser.Text = "admin"; // Thiết lập tên đăng nhập
            var txtmk = new TextBox();
            txtmk.Text = "admin"; // Thiết lập mật khẩu
            SqlCommand cmd = null;

            // Act
            using (conn)
            {
                conn.Open();
                string sql = "select count(*) from GV where ID_gv = '" + txtuser.Text + "' and Pass = '" + txtmk.Text + "'";
                cmd = new SqlCommand(sql, conn);
                int val = (int)cmd.ExecuteScalar();
                if (val != 1)
                {
                    var result = frmgv.Equals(txtuser.Text, txtmk.Text); // Gọi phương thức Login
                                                                       // Assert
                    Assert.IsFalse(result); // Kiểm tra xem đăng nhập có không thành công không
                                            // Kiểm tra xem MessageBox có hiển thị thông báo không đăng nhập thành công không
                    Assert.IsTrue(MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu. Nếu bạn là Sinh viên vui lòng chọn ô Sinh viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information) != DialogResult.None);
                }
            }
        }
        [TestMethod]
        public void Test_btnlogin_Click_Successful()
        {
            // Arrange
            var conn = new SqlConnection("Data Source=PHUQUY577920\\SQLEXPRESS;Initial Catalog=THITRACNGHIEM;Integrated Security=True");
            var form = new frmlogin();
            form.txtuser.Text = "11191057"; // Đặt tên đăng nhập hợp lệ
            form.txtmk.Text = "111111";   // Đặt mật khẩu hợp lệ
            form.gvflag = false; // Đảm bảo rằng gvflag là false để kiểm tra đăng nhập sinh viên
            form.conn = conn; // Thiết lập kết nối cho form

            // Tạo một đối tượng IDatabaseService giả lập hoặc thực tế
            var connectionString = "Data Source=PHUQUY577920\\SQLEXPRESS;Initial Catalog=THITRACNGHIEM;Integrated Security=True";
            IDatabaseService databaseService = new DatabaseService(connectionString);

            // Act
            conn.Open(); // Mở kết nối
            form.btnlogin_Click(null, null); // Gọi phương thức btnlogin_Click

            // Assert
            // Kiểm tra xem form mới có được hiển thị khi đăng nhập thành công không
            Assert.IsTrue(Application.OpenForms.OfType<frminfo>().Any(), "Form frminfo không được mở sau khi đăng nhập thành công.");
            conn.Close(); // Đóng kết nối sau khi kiểm tra
        }

        [TestMethod]
        public void Test_btngv_Click_SetsGvFlagToTrue()
        {
            // Arrange
            var frmLogin = new frmlogin();

            // Act
            frmLogin.btngv_Click(null, null);

            // Assert
            Assert.IsTrue(frmLogin.gvflag);
        }

        [TestMethod]
        public void Test_btngv_MouseClick()
        {
            // Arrange
            var frmLogin = new frmlogin();

            // Act
            frmLogin.btngv_MouseClick(null, null);

            // Assert
            Assert.AreEqual(System.Drawing.Color.LightSalmon, frmLogin.btngv.BackColor);
            Assert.AreEqual(System.Drawing.Color.Red, frmLogin.btngv.ForeColor); // Sửa thành ForeColor thay vì TextColor
        }

        [TestMethod]
        public void Test_btnexit_Click()
        {
            // Arrange
            var frmLogin = new frmlogin();

            // Act
            frmLogin.btnexit_Click(null, null);

            // Assert
            Assert.IsTrue(frmLogin.IsDisposed); // Kiểm tra xem form đã được dispose hay chưa
        }
        [TestMethod]
        public void frmlogin_Load_OpenConnection_Success()
        {
            // Arrange
            var form = new frmlogin();

            // Act
            form.frmlogin_Load(null, EventArgs.Empty);

            // Assert
            Assert.IsTrue(form.conn.State == System.Data.ConnectionState.Open); // Kiểm tra xem kết nối đã mở hay không
        }
    }
}
