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
    public partial class Login_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string Userid = txt_UserID.Text;
            string Password = txt_Password.Text;

            string Usr_chk_connection = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            SqlConnection Usr_chk_con = new SqlConnection(Usr_chk_connection);
            Usr_chk_con.Open();

            // Check if the user ID exists
            string userIdQuery = "SELECT COUNT(1) FROM LoginCredentials WHERE UserId = @UserId";
            SqlCommand userIdCmd = new SqlCommand(userIdQuery, Usr_chk_con);
            userIdCmd.Parameters.AddWithValue("@UserId", Userid);
            int userExists = Convert.ToInt32(userIdCmd.ExecuteScalar());

            if (userExists == 0)
            {
                // If the user ID does not exist, show "User doesn't exist" message
                lbl_msg.Text = "User doesn't exist, please sign up.";
            }
            else
            {
                string connection = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                string query = "select count(1) from LoginCredentials where UserId= @Userid and Password = @Password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", Userid);
                cmd.Parameters.AddWithValue("@Password", Password);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 1)
                {
                    string StatusConnection = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                    SqlConnection StatusCon = new SqlConnection(StatusConnection);
                    StatusCon.Open();
                    string StatusQuery = "SELECT status FROM LoginCredentials WHERE UserId = @Userid";
                    SqlCommand Statuscommand = new SqlCommand(StatusQuery, con);
                    Statuscommand.Parameters.AddWithValue("@UserId ", Userid);
                    string Status = Convert.ToString(Statuscommand.ExecuteScalar());
                    StatusCon.Close();

                    if (Status == "Deactive")
                    {
                        Session["userid"] = txt_UserID.Text;
                        Session["password"] = txt_Password.Text;
                        Response.Redirect("Update_Password_Form.aspx");
                    }
                    else if (Status == "Active")
                    {
                        Session["userid"] = txt_UserID.Text;
                        Session["password"] = txt_Password.Text;
                        Response.Redirect("https://www.youtube.com/");
                    }

                }
                else
                {
                    lbl_msg.Text = "password is incorrect";
                }
            }
        }
    }
}