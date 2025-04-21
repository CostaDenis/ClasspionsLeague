using Microsoft.Data.SqlClient;

namespace ClasspionsLeague
{

    public static class Database
    {
        public static SqlConnection Connection = new SqlConnection();
    }
}