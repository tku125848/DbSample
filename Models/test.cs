using Dapper;
using Microsoft.Data.SqlClient;

namespace DbSample.Models
{
    public class test
    {
        public int? sn { get; set; }

        public string title { get; set; }

        public DateTime? dcrt { get; set; }


        public static List<test> getTable(IConfiguration configuration , int sn)
        {
            List<test> list = new List<test>();
            string connstr = configuration.GetConnectionString("OPENDATA");
            using (var connection = new SqlConnection(connstr))
            {
                try
                {
                    var pars = new
                    {
                        sn = sn
                    };
                    var sql = @"select sn, title , dcrt from test where sn=@sn";
                    list = connection.Query<test>(sql, pars).ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return list;
        }

    }
}
