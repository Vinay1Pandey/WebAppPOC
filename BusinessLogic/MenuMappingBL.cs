using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using BSNLEntity;
namespace BusinessLogic
{
    public class MenuMappingBL
    {
        public static void MenuMapping(Repeater rpt)
        {
            using (BSNLContext db = new BSNLContext())
            {
                var query = (from p in db.MenuMasters
                             where p.isActive == true
                             select p).ToList();
                rpt.DataSource = query;
                rpt.DataBind();

            }
        }
    }
}
