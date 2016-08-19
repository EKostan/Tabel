using System.Collections.Generic;
using System.Data.SQLite;
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




        public void Set(List<ObjectRecord> items)
        {
            using (var conn = Project.CreateConnection())
            {

                var insertCollection = new List<ObjectRecord>();
                var updateCollection = new List<ObjectRecord>();
                var deleteCollection = new List<ObjectRecord>();

                foreach (var Object in items)
                {
                    switch (Object.Status)
                    {
                        case Status.Update:
                            updateCollection.Add(Object);
                            break;
                        case Status.Delete:
                            deleteCollection.Add(Object);
                            break;
                        case Status.Insert:
                            insertCollection.Add(Object);
                            break;
                    }
                }

                InsertObjects(insertCollection, conn);
                UpdateObjects(updateCollection, conn);
                DeleteObjects(deleteCollection, conn);
            }
        }

        private void DeleteObjects(List<ObjectRecord> items, SQLiteConnection conn)
        {
            foreach (var Object in items)
            {
                if (Object.Id <= 0)
                    continue;

                var command =
                    string.Format("delete from Objects where id = {0}", Object.Id);
                conn.Query<ObjectRecord>(command);
            }
        }

        private void InsertObjects(List<ObjectRecord> items, SQLiteConnection conn)
        {
            foreach (var Object in items)
            {
                var command =
                    string.Format("insert into Objects(Name) values('{0}')",
                        Object.Name);
                conn.Query<ObjectRecord>(command);
            }
        }

        private void UpdateObjects(List<ObjectRecord> items, SQLiteConnection conn)
        {
            foreach (var Object in items)
            {
                if (Object.Id <= 0)
                    continue;

                var command =
                    string.Format(@"
                                    update Objects
                                    set Name = '{0}'
                                    where id = {1}",
                        Object.Name, Object.Id);
                conn.Query<ObjectRecord>(command);
            }
        }
 
    }
}