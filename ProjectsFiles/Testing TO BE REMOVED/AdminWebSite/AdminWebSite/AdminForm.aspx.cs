using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameBLL.BLL_Classess;

namespace AdminWebSite
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        AdminUserBL adminUser = new AdminUserBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(TextBoxName.Text.Equals(adminUser.GetUserName()) && 
                TextBoxPassword.Text.Equals(adminUser.GetPassword()))
            {
                Session["AdminUser"] = adminUser;
                Response.Redirect("~/DashBoardPage.aspx");
            }
            else
            {
                //text-inverse text-left m-b-0
                //text-error text-left m-b-0
                LabelError.CssClass = "text-error text-left m-b-0";
                LabelError.Text = "[ERROR] - one of the inputs was incorrect!";
            }
        }
    }
}