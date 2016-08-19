using System.Collections.Generic;
using System.Data.SQLite;
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


        public void Set(List<JobRecord> items)
        {
            using (var conn = Project.CreateConnection())
            {

                var insertCollection = new List<JobRecord>();
                var updateCollection = new List<JobRecord>();
                var deleteCollection = new List<JobRecord>();

                foreach (var Job in items)
                {
                    switch (Job.Status)
                    {
                        case Status.Update:
                            updateCollection.Add(Job);
                            break;
                        case Status.Delete:
                            deleteCollection.Add(Job);
                            break;
                        case Status.Insert:
                            insertCollection.Add(Job);
                            break;
                    }
                }

                InsertJobs(insertCollection, conn);
                UpdateJobs(updateCollection, conn);
                DeleteJobs(deleteCollection, conn);
            }
        }

        private void DeleteJobs(List<JobRecord> items, SQLiteConnection conn)
        {
            foreach (var Job in items)
            {
                if (Job.Id <= 0)
                    continue;

                var command =
                    string.Format("delete from Jobs where id = {0}", Job.Id);
                conn.Query<JobRecord>(command);
            }
        }

        private void InsertJobs(List<JobRecord> items, SQLiteConnection conn)
        {
            foreach (var Job in items)
            {
                var command =
                    string.Format("insert into Jobs(Name) values('{0}')",
                        Job.Name);
                conn.Query<JobRecord>(command);
            }
        }

        private void UpdateJobs(List<JobRecord> items, SQLiteConnection conn)
        {
            foreach (var Job in items)
            {
                if (Job.Id <= 0)
                    continue;

                var command =
                    string.Format(@"
                                    update Jobs
                                    set Name = '{0}'
                                    where id = {1}",
                        Job.Name, Job.Id);
                conn.Query<JobRecord>(command);
            }
        }
 

        
    }
}