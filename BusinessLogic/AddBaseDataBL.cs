using BSNLEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BusinessLogic
{
    public class AddBaseDataBL
    {
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["BSNLContext"].ConnectionString;
        }
        //public static void ShowColumn(Repeater rpt)
        //{
        //    try
        //    {
        //        SqlConnection SqlConn = new SqlConnection();
        //        SqlConn.ConnectionString = GetConnectionString();
        //        string SqlString = "EXEC sp_columns [BaseData]";

        //        using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
        //        {
        //            SqlConn.Open();
        //            rpt.DataSource = SqlCom.ExecuteReader();
        //            rpt.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(ex.Message);
        //    }
        //}

        public static void InsertBaseData(BaseData details)
        {
            try
            {
                using (BSNLContext db = new BSNLContext())
                {
                    db.BaseDatas.Add(details);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static int checkDuplicateID(int id)
        {
            int flag = 0;
            using (BSNLContext db = new BSNLContext())
            {
                var query = from c in db.BaseDatas
                            where c.CustomerID == id
                            select c;
                if (query.Count() > 0)
                {
                    flag = 1;
                }

                return flag;
            }
        }
    }
}
