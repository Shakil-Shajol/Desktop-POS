using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PointOfSales
{
    public class Connection
    {
       public SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=projectPointOfSales_DB;Integrated Security=True");

    }
}
