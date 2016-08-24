using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;

namespace Contract
{
    public class Employees
    {
        public List<EmployeeRecord> Get()
        {
            using (var conn = Project.CreateConnection())
            {
                return conn.Query<EmployeeRecord>("select * from Employees").ToList();
            }
        }

        public void Set(List<EmployeeRecord> items)
        {
            using (var conn = Project.CreateConnection())
            {

                var insertCollection = new List<EmployeeRecord>();
                var updateCollection = new List<EmployeeRecord>();
                var deleteCollection = new List<EmployeeRecord>();

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

                InsertEmployees(insertCollection, conn);
                UpdateEmployees(updateCollection, conn);
                DeleteEmployees(deleteCollection, conn);
            }
        }

        private void DeleteEmployees(List<EmployeeRecord> items, SQLiteConnection conn)
        {
            foreach (var employee in items)
            {
                if (employee.Id <= 0)
                    continue;

                var command =
                    string.Format("delete from Employees where id = {0}", employee.Id);
                conn.Query<EmployeeRecord>(command);
            }
        }

        private void InsertEmployees(List<EmployeeRecord> items, SQLiteConnection conn)
        {
            foreach (var employee in items)
            {
                var command =
                    string.Format("insert into Employees(Name, Position, Email, Rate) values('{0}', '{1}', '{2}', {3})",
                        employee.Name, employee.Position, employee.Email, employee.Rate);
                conn.Query<EmployeeRecord>(command);
            }
        }

        private void UpdateEmployees(List<EmployeeRecord> items, SQLiteConnection conn)
        {
            foreach (var employee in items)
            {
                if (employee.Id <= 0)
                    continue;

                var command =
                    string.Format(@"
                                    update Employees
                                    set Name = '{0}',
                                        Position = '{1}',
                                        Rate = {2},
                                        Email = '{3}'
                                    where id = {4}",
                        employee.Name, employee.Position, employee.Rate, employee.Email, employee.Id);
                conn.Query<EmployeeRecord>(command);
            }
        }
    }
}