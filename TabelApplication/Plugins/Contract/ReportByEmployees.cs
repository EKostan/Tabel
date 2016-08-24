using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace Contract
{
    public class ReportByEmployees
    {
        public List<ReportByEmployeesRecord> Get(DateTime beginDate, DateTime endDate)
        {
            using (var conn = Project.CreateConnection())
            {
                return conn.Query<ReportByEmployeesRecord>(string.Format(@"
                    select q.Date,  q.EmployeeId, e.Name as EmployeeName, e.Rate*q.hours as Cost, 
q.ContractId, c.Code as ContractCode, c.Name as ContractName, c.Object as ObjectName, q.hours
from
(select EmployeeId, strftime('%Y-%m-%d', date) as Date, ContractId, sum(hours) as hours
from time as t
where t.date > '{0}' AND t.date < '{1}'
group by t.EmployeeId, strftime('%Y-%m-%d', t.date), ContractId) q
inner join employees as e on e.Id = q.EmployeeId
inner join contracts as c on c.Id = q.ContractId", beginDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"))).ToList();
            }
        }
    }
}