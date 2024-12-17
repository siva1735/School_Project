using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School_Project
{
    public partial class Student_Credentials : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_usrnm.Text = Session["user_id"].ToString();
            lbl_pasrd.Text = Session["password"].ToString();
        }
    }
}