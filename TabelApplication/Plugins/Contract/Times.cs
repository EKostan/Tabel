using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SQLite;

namespace Contract
{
    public class Times
    {
        public List<TimeRecord> Get()
        {
            using (var conn = Project.CreateConnection())
            {
                return conn.Query<TimeRecord>(@"
                    select t.*, e.Name as EmployeeName, c.Code as ContractCode
                    from time as t
                    inner join employees as e on e.Id = t.EmployeeId
                    left outer join Contracts as c on c.Id = t.ContractId").ToList();
            }
        }




        public void Set(List<TimeRecord> items)
        {
            using (var conn = Project.CreateConnection())
            {

                var insertCollection = new List<TimeRecord>();
                var updateCollection = new List<TimeRecord>();
                var deleteCollection = new List<TimeRecord>();

                foreach (var employee in items)
                {
                    switch (employee.Status)
                    {
                        case Status.Update:
                            updateCollection.Add(employee);
                            break;
                        case Status.Delete:
                            deleteCollection.Add(employee);
                            break;
                        case Status.Insert:
                            insertCollection.Add(employee);
                            break;
                    }
                }

                Insert(insertCollection, conn);
                Update(updateCollection, conn);
                Delete(deleteCollection, conn);
            }
        }

        private void Delete(List<TimeRecord> items, SQLiteConnection conn)
        {
            foreach (var item in items)
            {
                if (item.Id <= 0)
                    continue;

                var command =
                    string.Format("delete from Time where id = {0}", item.Id);
                conn.Query<EmployeeRecord>(command);
            }
        }

        private void Insert(List<TimeRecord> items, SQLiteConnection conn)
        {
            foreach (var item in items)
            {
                var command =
                    string.Format(@"
                                    insert into Time(EmployeeId, ContractId, Date, Hours) 
                                    values({0}, {1}, '{2}', {3})",
                                    item.EmployeeId, item.ContractId, item.Date.ToString("yyyy-MM-dd HH:mm:ss"), item.Hours);
                conn.Query<EmployeeRecord>(command);
            }
        }

        private void Update(List<TimeRecord> items, SQLiteConnection conn)
        {
            foreach (var record in items)
            {
                if (record.Id <= 0)
                    continue;

                var command =
                    string.Format(@"
                                    update Time
                                    set EmployeeId = {0},
                                        ContractId = {1},
                                        Date = '{2}',
                                        Hours = {3}
                                    where id = {4}",
                        record.EmployeeId, 
                        record.ContractId, 
                        record.Date.ToString("yyyy-MM-dd HH:mm:ss"),
                        record.Hours, 
                        record.Id);
                conn.Query<EmployeeRecord>(command);
            }
        }
    }
}