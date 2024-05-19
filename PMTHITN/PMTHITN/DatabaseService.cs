using System;
using System.Data;
using System.Data.SqlClient;

public class DatabaseService : IDatabaseService
{
    private readonly string connectionString;

    public DatabaseService(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public DataTable GetExamInfo()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string sql = "SELECT * FROM MONTHI WHERE Thoigianthi = @Today";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@Today", DateTime.Now.ToString("yyyy-MM-dd"));
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }

    public DataTable GetStudentInfo(string studentId)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string sql = "SELECT * FROM SV WHERE MaSV = MaSV";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("MaSV", studentId);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
