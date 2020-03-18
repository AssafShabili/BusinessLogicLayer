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
        AdminUserBL adminUser;
       

        protected void Page_Load(object sender, EventArgs e)
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
            LabelNUmberOfUsers.Text = adminUser.GetNumberOfUsers().ToString();
            LabelNumberOfTowers.Text = adminUser.GetNumberOfTowers().ToString();
            DataTable dataTable = /*adminUser.GetAdminPercentageTable();*/ AdminWebServiceSoapClient.GetAdminPercentageTable();




            GridViewProperties.DataSource = adminUser.GetWaveProperties();
            GridViewProperties.DataBind();

            InitializeTextBoxs(dataTable);
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


        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            adminUser.SetAdminPercentageHighestCurrentWinrate(
                double.Parse(TextBoxHighestCurrentWinrate.Text));

            adminUser.SetAdminPercentageLowestCurrentWinrate(
               double.Parse(TextBoxLowestCurrentWinrate.Text));

            adminUser.SetAdminPercentageLowestWinrate(
              double.Parse(TextBoxLowestWinrate.Text));

            adminUser.SetUpdateAdminPercentageHighestWinrate(
              double.Parse(TextBoxHighestWinrate.Text));
        }
    }
}