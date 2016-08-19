using System.Collections.Generic;
using System.Data.SQLite;
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


        public void Set(List<ContractRecord> items)
        {
            using (var conn = Project.CreateConnection())
            {

                var insertCollection = new List<ContractRecord>();
                var updateCollection = new List<ContractRecord>();
                var deleteCollection = new List<ContractRecord>();

                foreach (var Contract in items)
                {
                    switch (Contract.Status)
                    {
                        case Status.Update:
                            updateCollection.Add(Contract);
                            break;
                        case Status.Delete:
                            deleteCollection.Add(Contract);
                            break;
                        case Status.Insert:
                            insertCollection.Add(Contract);
                            break;
                    }
                }

                InsertContracts(insertCollection, conn);
                UpdateContracts(updateCollection, conn);
                DeleteContracts(deleteCollection, conn);
            }
        }

        private void DeleteContracts(List<ContractRecord> items, SQLiteConnection conn)
        {
            foreach (var Contract in items)
            {
                if (Contract.Id <= 0)
                    continue;

                var command =
                    string.Format("delete from Contracts where id = {0}", Contract.Id);
                conn.Query<ContractRecord>(command);
            }
        }

        private void InsertContracts(List<ContractRecord> items, SQLiteConnection conn)
        {
            foreach (var Contract in items)
            {
                var command =
                    string.Format("insert into Contracts(Name) values('{0}')",
                        Contract.Name);
                conn.Query<ContractRecord>(command);
            }
        }

        private void UpdateContracts(List<ContractRecord> items, SQLiteConnection conn)
        {
            foreach (var Contract in items)
            {
                if (Contract.Id <= 0)
                    continue;

                var command =
                    string.Format(@"
                                    update Contracts
                                    set Name = '{0}'
                                    where id = {1}",
                        Contract.Name, Contract.Id);
                conn.Query<ContractRecord>(command);
            }
        }
    }
}