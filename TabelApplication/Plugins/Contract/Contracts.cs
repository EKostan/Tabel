using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace Contract
{
    public class Contracts
    {
        public List<ContractRecord> Get()
        {
            using (var conn = Project.CreateConnection())
            {
                return conn.Query<ContractRecord>(@"select * from Contracts").ToList();
            }
        }




        public void SetTime(List<ContractRecord> list)
        {
        }
    }
}