using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
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

        public void ErrClear()
        {
            lblErrMsg.Text = "";
        }

        public void ExcClear()
        {
            lblExcMsg.Text = "";
        }

        public string GenerateUserId()
        {
            string firstNamePart = txtFullName.Value.Length >= 3
                ? txtFullName.Value.Substring(0, 3)
                : txtFullName.Value;

            string phoneNumber = txtPhoneNumber.Value;
            string phonePart = phoneNumber.Length >= 4
                ? phoneNumber.Substring(phoneNumber.Length - 4)
                : phoneNumber;

            return firstNamePart + phonePart;
        }

        public string GeneratePassword()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void RegisterUser(string userId, string password)
        {
            SaveUserToDatabase(userId, password);
        }

        private void SaveUserToDatabase(string userId, string password)
        {
            string status = "Deactive";
            string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO LoginCredentials (UserID, Password, Status) VALUES (@UserID, @Password, @Status)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string checkQuery = "SELECT COUNT(*) FROM StudentRegistration WHERE PhoneNumber = @PhoneNumber OR Email = @Email";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Value);
                        checkCmd.Parameters.AddWithValue("@Email", txtEmail.Value);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            ExcClear();
                            lblErrMsg.Text = "Phone number or email is already registered";
                            return;
                        }
                    }

                    string query = "INSERT INTO StudentRegistration (FullName, DateOfBirth, Gender, Class, Address, PhoneNumber, Email, RegistrationDate) " +
                                   "VALUES (@FullName, @DateOfBirth, @Gender, @Class, @Address, @PhoneNumber, @Email, @RegistrationDate)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FullName", txtFullName.Value);
                        cmd.Parameters.AddWithValue("@DateOfBirth", txtDateOfBirth.Value);
                        cmd.Parameters.AddWithValue("@Gender", ddlGender.Value);
                        cmd.Parameters.AddWithValue("@Class", txtClass.Value);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Value);
                        cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Value);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Value);
                        cmd.Parameters.AddWithValue("@RegistrationDate", txtRegistrationDate.Value);

                        int rowsInserted = cmd.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            string userId = GenerateUserId();
                            string password = GeneratePassword();
                            RegisterUser(userId, password);

                            Session["user_id"] = userId;
                            Session["password"] = password;

                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Student registered successfully!');", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Registration failed. Please try again.');", true);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                lblErrMsg.Text = "Database error: " + ex.Message;
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "Unexpected error: " + ex.Message;
            }
        }
    }
}
