using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; // Required for ConfigurationManager
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School_Project
{
    public partial class Attendance : Page
    {
        // Get the connection string from web.config
        private string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Ensure session data is available
                if (Session["studentid"] == null)
                {
                    Response.Redirect("Login.aspx"); // Redirect to login if session is not set
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string startDate = hdnStartDate.Value;
            string endDate = hdnEndDate.Value;

            if (string.IsNullOrWhiteSpace(startDate) || string.IsNullOrWhiteSpace(endDate))
            {
                dateError.Text = "Please select both start and end dates.";
                return;
            }

            try
            {
                DateTime start = DateTime.Parse(startDate);
                DateTime end = DateTime.Parse(endDate);

                if (start > end)
                {
                    dateError.Text = "Start date cannot be after end date.";
                    return;
                }

                dateError.Text = string.Empty; // Clear error
                FetchAttendanceData(start, end);
            }
            catch (FormatException)
            {
                dateError.Text = "Invalid date format. Please select valid dates.";
            }
        }

        private void FetchAttendanceData(DateTime startDate, DateTime endDate)
        {
            studentTable.Rows.Clear();

            // Add header row
            TableHeaderRow headerRow = new TableHeaderRow();
            headerRow.Cells.Add(new TableHeaderCell { Text = "Student ID" });
            headerRow.Cells.Add(new TableHeaderCell { Text = "Student Name" });
            headerRow.Cells.Add(new TableHeaderCell { Text = "Date" });
            headerRow.Cells.Add(new TableHeaderCell { Text = "Status" });
            studentTable.Rows.Add(headerRow);

            try
            {
                string studentId = Session["studentid"]?.ToString();
                if (string.IsNullOrEmpty(studentId))
                {
                    dateError.Text = "Session expired. Please log in again.";
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetAttendanceByDateRange", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StartDate", startDate);
                        cmd.Parameters.AddWithValue("@EndDate", endDate);
                        cmd.Parameters.AddWithValue("@StudentID", studentId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                dateError.Text = "No attendance records found for the selected date range.";
                                return;
                            }

                            while (reader.Read())
                            {
                                TableRow row = new TableRow();

                                row.Cells.Add(new TableCell { Text = reader["StudentID"].ToString() });
                                row.Cells.Add(new TableCell { Text = reader["StudentName"].ToString() });
                                row.Cells.Add(new TableCell { Text = Convert.ToDateTime(reader["Date"]).ToString("yyyy-MM-dd") });
                                row.Cells.Add(new TableCell { Text = reader["Status"].ToString() });

                                studentTable.Rows.Add(row);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dateError.Text = "Error fetching data: " + ex.Message;
            }
        }
    }
}




