using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace School_Project
{
    public partial class Registration_Form : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set the registration date
                txtRegistrationDate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            // Retrieve data from input fields
            string fullName = txtFullName.Value;
            string dateOfBirth = txtDateOfBirth.Value;
            string gender = ddlGender.Value;
            string studentClass = txtClass.Value;
            string address = txtAddress.Value;
            string phoneNumber = txtPhoneNumber.Value;
            string email = txtEmail.Value;
            string registrationDate = txtRegistrationDate.Value;

            // Database connection string
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            // Insert query
            string query = "INSERT INTO StudentRegistration (FullName, DateOfBirth, Gender, Class, Address, PhoneNumber, Email, RegistrationDate) " +
                           "VALUES (@FullName, @DateOfBirth, @Gender, @Class, @Address, @PhoneNumber, @Email, @RegistrationDate)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@Class", studentClass);
                        cmd.Parameters.AddWithValue("@Address", address);
                        cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@RegistrationDate", registrationDate);

                        // Execute the query
                        int rowsInserted = cmd.ExecuteNonQuery();
                        if (rowsInserted > 0)
                        {
                            // Successfully inserted
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Student registered successfully!');", true);
                        }
                        else
                        {
                            // Insertion failed
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Registration failed. Please try again.');", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle errors
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('An error occurred: {ex.Message}');", true);
            }
        }
    }
}
