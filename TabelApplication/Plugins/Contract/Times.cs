using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace Contract
{
    public class Times
    {
        public List<TimeRecord> GetTime()
        {
            using (var conn = Project.CreateConnection())
            {
                return conn.Query<TimeRecord>(@"
                    select t.*, e.Name as EmployeeName, j.Name as JobName, o.Name as ObjectName
                    from time as t
                    inner join employees as e on e.Id = t.EmployeeId
                    left outer join jobs as j on j.Id = t.JobId
                    left outer join objects as o on o.Id = t.ObjectId").ToList();
            }
        }




        public void SetTime(List<TimeRecord> list)
        {
        }
    }
}