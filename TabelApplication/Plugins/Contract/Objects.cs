using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace Contract
{
    public class Objects
    {
        public List<ObjectRecord> Get()
        {
            using (var conn = Project.CreateConnection())
            {
                return conn.Query<ObjectRecord>(@"select * from objects").ToList();
            }
        }




        public void SetTime(List<ObjectRecord> list)
        {
        }
    }
}