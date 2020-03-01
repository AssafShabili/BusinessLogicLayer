using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameBLL.BLL_Classess;
using GameDAL;
using System.Data;
namespace AdminWebSite
{
    public partial class DashBoardPage : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminUserBL userBL = new AdminUserBL();
            DataTable dataTable = userBL.GetAdminPercentageTable();

            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }
    }
}