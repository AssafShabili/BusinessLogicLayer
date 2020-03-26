using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameBLL.BLL_Classess;
using System.Data;
using AdminWebProject.AdminServiceReference;

namespace AdminWebProject
{
    public partial class DashBoradAdmin : System.Web.UI.Page
    {
        AdminUserBL adminUser;
        AdminServiceClient AdminServiceClient;
        DataTable dataTable = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            //AdminUserBL adminUserBL = new AdminUserBL();
            //DataTable table = adminUserBL.GetWaveProperties();
            //table.Columns.RemoveAt(0);
            //GridViewPropertes.DataSource = table;
            //InitializeTextBoxs(adminUserBL.GetAdminPercentageTable());
            //GridViewPropertes.DataBind();

            if (!IsPostBack)
            {
                try
                {
                    adminUser = (AdminUserBL)Session["AdminUser"];

                }
                catch (Exception)
                {
                    // קרתה טעות 
                    adminUser = new AdminUserBL();
                }
                try
                {
                    using (AdminServiceClient = new AdminServiceClient())
                    {
                        LabelNumberOfUsers.Text = AdminServiceClient.GetNumberOfCurrentUsers().ToString();
                        LabelNumberOfTowers.Text = AdminServiceClient.GetNumberOfCurrentTowers().ToString();
                        dataTable = AdminServiceClient.GetAdminPercentageTable();
                       
                    }
                }
                catch (Exception)
                {
                    Response.Redirect("~/WebFormError.aspx");
                }
               

                GridViewPropertes.DataSource = adminUser.GetWaveProperties();
                GridViewPropertes.DataBind();
                InitializeTextBoxs(dataTable);
            }

        }


        /// <summary>
        /// פעולה להכנסת הנתונים שמובאים מבסיס הנתונים לתוך השדות המתאימים
        /// </summary>
        /// <param name="dataTable">טבלת הנתונים </param>
        public void InitializeTextBoxs(DataTable dataTable)
        {
            if (dataTable != null)
            {
                TextBoxLowestWinrate.Text = dataTable.Rows[0]["AdminPercentage_Lowest_winrate"].ToString();
                TextBoxHighestWinrate.Text = dataTable.Rows[0]["AdminPercentage_Highest_winrate"].ToString();
                TextBoxLowestCurrentWinrate.Text = dataTable.Rows[0]["AdminPercentage_Lowest_Current_Winrate"].ToString();
                TextBoxHighestCurrentWinrate.Text = dataTable.Rows[0]["AdminPercentage_Highest_Current_Winrate"].ToString();
            }
        }


        protected void GridViewPropertes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewPropertes.PageIndex = e.NewPageIndex;
            GridViewPropertes.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //LabelNumberOfUsers.Text = "testing update!";
            using (AdminServiceClient = new AdminServiceClient())
            {
                AdminServiceClient.SetAdminPercentageHighestCurrentWinrate(
                    double.Parse(TextBoxHighestCurrentWinrate.Text));
                AdminServiceClient.SetAdminPercentageLowestCurrentWinrate(
                   double.Parse(TextBoxLowestCurrentWinrate.Text));
                AdminServiceClient.SetAdminPercentageLowestWinrate(
                  double.Parse(TextBoxLowestWinrate.Text));
                AdminServiceClient.SetUpdateAdminPercentageHighestWinrate(
                  double.Parse(TextBoxHighestWinrate.Text));
            }
        }
    }
}