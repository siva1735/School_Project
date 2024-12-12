using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace School_Project
{
    public partial class Update_Password_Form : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Ensure this logic only runs on the first page load
            {
                if (Session["userid"] != null)
                {
                    lblErrorMsg.Text = "";
                    lblSuccessMsg.Text = "";
                    string user = Session["userid"].ToString();
                    txtUsername.Value = user;
                    txtUsername.Disabled = true; // Prevent editing of the username
                }
                else
                {
                    lblErrorMsg.Text = "User session expired. Please login again.";
                    Response.Redirect("Login_Page.aspx"); // Redirect to login if session is missing
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Value != txtConfirmPassword.Value)
            {
                lblErrorMsg.Text = "New password and confirm password do not match.";
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            string status = "Active";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = "UPDATE LoginCredentials SET Password = @Password, Status = @Status WHERE UserId = @UserId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Password", txtConfirmPassword.Value);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@UserId", txtUsername.Value);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            lblSuccessMsg.Text = "Password updated successfully!";
                            lblErrorMsg.Text = "";
                        }
                        else
                        {
                            lblErrorMsg.Text = "Password update failed. User not found.";
                            lblSuccessMsg.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "An error occurred: " + ex.Message;
                lblSuccessMsg.Text = "";
            }
        }
    }
}
