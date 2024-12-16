using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School_Project
{
    public partial class Attendence_From : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (IsPostBack && Request["__EVENTTARGET"] == "attendanceDate")
            {
                string selectedDate = attendanceDate.Value;
                if (!string.IsNullOrWhiteSpace(selectedDate))
                {
                    FetchAttendance(selectedDate);
                }
            }
        }

        private void FetchAttendance(string date)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            try
            {
                string id = Session["studentid"].ToString();
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "select count(1) from Attendence where StudentID= "id"";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StudentID", id);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 1)
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string query = @" SELECT s.StudentID, s.Student_Name,  ISNULL(a.Status, 'Absent') AS Status  FROM Students s LEFT JOIN AttendanceRecords a  ON s.StudentID = a.StudentID AND a.Date = @Date";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@Date", date);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                studentTable.Controls.Clear();

                                while (reader.Read())
                                {
                                    string studentId = reader["StudentID"].ToString();
                                    string studentName = reader["Student_Name"].ToString();
                                    string status = reader["Status"].ToString();

                                    TableRow row = new TableRow();

                                    TableCell idCell = new TableCell { Text = studentId };
                                    TableCell nameCell = new TableCell { Text = studentName };
                                    TableCell statusCell = new TableCell { Text = status };

                                    row.Cells.Add(idCell);
                                    row.Cells.Add(nameCell);
                                    row.Cells.Add(statusCell);

                                    studentTable.Controls.Add(row);
                                }
                            }
                        }
                    }

                }
                else
                {
                    dateError.InnerText = "something went wrong please try again " + ex.Message;
                }
        
            }
            catch (Exception ex)
            {
                dateError.InnerText = "Error fetching attendance: " + ex.Message;
            }
        }
    }
}