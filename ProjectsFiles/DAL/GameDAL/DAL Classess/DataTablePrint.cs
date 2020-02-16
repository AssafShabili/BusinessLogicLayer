using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GameDAL.DAL_Classess
{
    public static class DataTablePrint
    {
        public static string BuildTable(DataTable dt, int spacing)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            foreach (DataColumn dc in dt.Columns)
            {
                sb.AppendFormat("│{0," + spacing + "}", dc.ColumnName.ToString());
                count++;

            }
            sb.AppendLine();
            sb.Append("├");
            sb.Append(new string('─', spacing));
            for (int i = 0; i < count; i++)
            {
                if (i != count - 1)
                {
                    sb.Append("┼");
                    sb.Append(new string('─', spacing));
                }
                else
                {
                    sb.Append("┼");
                }
            }
            sb.AppendLine();
            //Adding the values to the tables
            foreach (DataRow dr in dt.Rows)
            {

                foreach (var dc in dr.ItemArray)
                {

                    sb.AppendFormat("│{0," + spacing + "}", dc);

                }
                sb.AppendLine();

            }
            return sb.ToString();
        }
    }
}
