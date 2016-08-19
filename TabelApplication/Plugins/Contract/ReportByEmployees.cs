using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace Contract
{
    public class ReportByEmployees
    {
        public List<ReportByEmployeesRecord> Get(int year)
        {
            using (var conn = Project.CreateConnection())
            {
                return conn.Query<ReportByEmployeesRecord>(string.Format(@"
                    select e.Name as EmployeeName, q.EmployeeId, q.Month, q.hours
                    from
                    (select t.EmployeeId, strftime('%m', t.date) as Month, sum(t.hours) as hours
                    from time as t
                    inner join employees as e on e.Id = t.EmployeeId
                    where strftime('%Y', t.date) = '{0}'
                    group by t.EmployeeId, strftime('%m', date)) q
                    inner join employees as e on e.Id = q.EmployeeId", year)).ToList();
            }
        }
    }
}