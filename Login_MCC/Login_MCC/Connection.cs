using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_MCC
{
    public class Connection
    {
       
        public static string connectionString = "Data Source=GILANG_AKRAM;Database=db_hr;Integrated Security=True;Connect Timeout=30;";

        
       public static SqlConnection connect = new SqlConnection(connectionString);
    }
}
