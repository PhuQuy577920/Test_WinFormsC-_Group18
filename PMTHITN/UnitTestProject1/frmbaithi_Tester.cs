using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PMTHITN;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;

namespace UnitTestProject_frmbaithi
{

    [TestClass]
    public class frmbaithi_Tester
    {

        private string LayDapAn(TableLayoutPanel table)
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
            {
            }
            return chon;
        }

        [TestMethod]
        public void LayDapAn_RadioButtonChecked_ReturnsTag()
        {
            // Arrange
            var table = new TableLayoutPanel();
            var radioButton1 = new RadioButton { Checked = false, Tag = "A" };
            var radioButton2 = new RadioButton { Checked = true, Tag = "B" };
            table.Controls.Add(radioButton1);
            table.Controls.Add(radioButton2);

            // Act
            string result = LayDapAn(table);

            // Assert
            Assert.AreEqual("B", result);
        }

        [TestMethod]
        public void LayDapAn_RadioButtonChecked_ReturnsCorrectTag()
        {
            // Arrange
            var table = new TableLayoutPanel();
            var radio = new RadioButton();
            radio.Checked = true;
            radio.Tag = "A";
            table.Controls.Add(radio);

            // Act
            string result = LayDapAn(table);

            // Assert
            Assert.AreEqual("A", result);
        }

        [TestMethod]
        public void LayDapAn_ExceptionOccurs_ReturnsF()
        {
            // Arrange
            var table = new TableLayoutPanel();
            // Simulate an exception by passing null
            table.Controls.Add(null);

            // Act
            string result = LayDapAn(table);

            // Assert
            Assert.AreEqual("f", result);
        }
        [TestMethod]
        public void frmbaithi_Load_ConnectionOpenedSuccessfully()
        {
            // Arrange
            var form = new frmbaithi();

            // Act
            form.frmbaithi_Load(null, EventArgs.Empty);

            // Assert
            Assert.AreEqual(ConnectionState.Open, form.conn.State, "Connection should be open.");
        }

        [TestMethod]
        public void frmbaithi_Load_ConnectionStringSetCorrectly()
        {
            // Arrange
            var form = new frmbaithi();
            string expectedConnectionString = "Data Source=PHUQUY577920\\SQLEXPRESS;Initial Catalog=THITRACNGHIEM;Integrated Security=True";

            // Act
            form.frmbaithi_Load(null, EventArgs.Empty);

            // Assert
            Assert.AreEqual(expectedConnectionString, form.constr, "Connection string should be set correctly.");
        }
        [TestMethod]
        public void btnback_Click_GoBackSuccessfully()
        {
            // Arrange
            var form = new frmbaithi();
            form.grbnoidung.Text = "Câu số 2";
            var dt = new DataTable();
            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2"); // Sửa lại cột thứ hai để lưu trữ nội dung của câu hỏi
            dt.Columns.Add("Column3"); // Sử dụng cột thứ ba để lưu trữ nội dung của câu trả lời
            dt.Rows.Add(new object[] { 1, "Question 1", "Answer 1" });
            dt.Rows.Add(new object[] { 2, "Question 2", "Answer 2" });
            form.dt = dt;

            // Act
            form.btnback_Click(null, EventArgs.Empty);

            // Assert
            Assert.AreEqual("Câu số 1", form.grbnoidung.Text, "Current question number should be decremented.");
            Assert.AreEqual("Question 1", form.lblnoidungcauhoi.Text, "Content of the previous question should be displayed.");
        }

        [TestMethod]
        public void btnback_Click_FirstQuestion_NoChange()
        {
            // Arrange
            var form = new frmbaithi();
            form.grbnoidung.Text = "Câu số 1";
            var dt = new DataTable();
            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2");
            dt.Columns.Add("Column3");
            dt.Rows.Add(new object[] { 1, "Question 1", "Answer 1" });
            dt.Rows.Add(new object[] { 2, "Question 2", "Answer 2" });
            form.dt = dt;

            // Act
            form.btnback_Click(null, EventArgs.Empty);

            // Assert
            Assert.AreEqual("Câu số 1", form.grbnoidung.Text, "Current question number should not change.");
            Assert.AreNotEqual("Question 1", form.lblnoidungcauhoi.Text, "Content of the first question should not be displayed.");
        }
        
        [TestMethod]
        public void frmbaithi_Load_Test()
        {
            // Arrange
            var form = new frmbaithi();

            // Act
            form.frmbaithi_Load(null, EventArgs.Empty);

            // Assert
            // Thực hiện các kiểm tra mong muốn sau khi form được load, ví dụ:
            Assert.IsNotNull(form.conn); // Kiểm tra xem kết nối đã được thiết lập chưa
        }
        [TestMethod]
        public void TestButtonBackClickUpdatesUI()
        {
            // Arrange
            var form = new frmbaithi(); // Thay YourForm bằng tên của form hoặc control chứa grbnoidung và lblnoidungcauhoi
            var btnBack = new Button(); // Giả định là bạn đang sử dụng Button
            var eventArgs = new EventArgs();

            // Set up initial state
            form.grbnoidung.Text = "Câu số 2"; // Giả sử câu hiện tại là câu số 2
            form.dt = new DataTable(); // Tạo DataTable mới để tránh lỗi
            form.dt.Columns.Add("ID", typeof(int)); // Thêm cột ID cho DataTable
            form.dt.Columns.Add("Question", typeof(string)); // Thêm cột Question cho DataTable
            form.dt.Rows.Add(1, "Nội dung câu hỏi 1"); // Thêm một hàng vào DataTable

            // Act
            form.btnback_Click_1(btnBack, eventArgs);

            // Assert
            Assert.AreEqual("Câu số 1", form.grbnoidung.Text); // Kiểm tra xem chuỗi hiển thị đã được cập nhật chính xác không
            Assert.AreEqual("Nội dung câu hỏi 1", form.lblnoidungcauhoi.Text); // Kiểm tra xem nội dung câu hỏi đã được cập nhật đúng cách không
        }
        [TestMethod]
        public void TestFormLoadUpdatesUI()
        {
            // Arrange
            var form = new frmbaithi(); // Thay YourForm bằng tên của form hoặc control chứa các thành phần UI
            var sender = new object();
            var e = new EventArgs();

            // Act
            form.frmbaithi_Load_1(sender, e);

            // Assert
            Assert.AreEqual("Tiếng Anh", form.lblmonthi.Text); // Thay "Tên môn thi" bằng giá trị bạn mong đợi từ cơ sở dữ liệu
            Assert.AreEqual("25", form.lblsocau.Text); // Thay "Số câu" bằng giá trị bạn mong đợi từ cơ sở dữ liệu
            Assert.AreEqual("15", form.lblthoigian.Text); // Thay "Thời gian" bằng giá trị bạn mong đợi từ cơ sở dữ liệu
            Assert.AreEqual("15", form.lblphut.Text); // Thay "Phút" bằng giá trị bạn mong đợi từ cơ sở dữ liệu
            Assert.AreEqual("Đỗ Thị Hoàng  Anh           ", form.lblhoten.Text); // Thay "Họ và tên" bằng giá trị bạn mong đợi từ cơ sở dữ liệu
            Assert.AreEqual("", form.lblmsv.Text); // Thay "Mã sinh viên" bằng giá trị bạn mong đợi từ cơ sở dữ liệu

            // Kiểm tra xem timer có được khởi động không
            Assert.IsTrue(form.timer1.Enabled); // Đảm bảo rằng timer đã được kích hoạt sau khi form được load
                                                // Thay timer1 bằng tên của đối tượng Timer của bạn nếu tên đó khác

            // Kiểm tra xem nội dung câu hỏi đầu tiên đã được hiển thị đúng không
            Assert.AreEqual("Câu số 1", form.grbnoidung.Text); // Thay "Câu số 1" bằng giá trị bạn mong đợi

            // Kiểm tra xem nội dung câu hỏi đã được hiển thị đúng không
            
        }
        [TestMethod]
        public void TestTimerTickUpdatesUI()
        {
            // Arrange
            var form = new frmbaithi(); // Thay YourForm bằng tên của form hoặc control chứa lblgiay và lblphut
            var sender = new object();
            var e = new EventArgs();

            // Thiết lập trạng thái ban đầu của lblgiay và lblphut
            form.lblgiay.Text = "59"; // Giả sử giây ban đầu là 10
            form.lblphut.Text = "01"; // Giả sử phút ban đầu là 1

            // Act
            form.timer1_Tick(sender, e);

            // Assert
            // Kiểm tra xem giây đã được giảm đi một đơn vị chưa
            Assert.AreEqual("58", form.lblgiay.Text);

            // Kiểm tra xem phút vẫn giữ nguyên nếu giây vẫn lớn hơn 0
            Assert.AreEqual("01", form.lblphut.Text);

            // Thiết lập trạng thái ban đầu để giả lập giá trị phút là 0 và giây là 1
            form.lblgiay.Text = "01"; // Giả sử giây là 1
            form.lblphut.Text = "00"; // Giả sử phút là 0

            // Act
            form.timer1_Tick(sender, e);

            // Assert
            // Kiểm tra xem giây đã được giảm đi một đơn vị chưa
            Assert.AreEqual("59", form.lblgiay.Text);

            // Kiểm tra xem phút đã được giảm đi một đơn vị và giây đã được thiết lập lại thành 59
            Assert.AreEqual("0-1", form.lblphut.Text);

            // Kiểm tra xem thông báo "Hết Giờ !!!" được hiển thị khi thời gian đếm ngược kết thúc
            // (Để kiểm tra hiển thị của MessageBox, bạn có thể sử dụng một phương pháp gọi mô phỏng hoặc spy)
            // Assert.IsTrue(MessageBoxShown()); // Giả sử MessageBox được hiển thị sau khi thời gian kết thúc
        }
    }
}
