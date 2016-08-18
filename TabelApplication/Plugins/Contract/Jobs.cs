using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace Contract
{
    public class Jobs
    {
        public List<JobRecord> Get()
        {
            using (var conn = Project.CreateConnection())
            {
                return conn.Query<JobRecord>(@"select * from jobs").ToList();
            }
        }




        public void SetTime(List<JobRecord> list)
        {
        }
    }
}