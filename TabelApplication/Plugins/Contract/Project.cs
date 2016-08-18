using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;


namespace Contract
{
    public class Project
    {
        public static Project Current
        {
            get { return MainSystem.Instance.Services.GetService<Project>(); }
        }

        public Project()
        {
            ConnectionString = @"Data Source=e:\Tabel\Db\tabel.sqlite; Version=3;";
            //ConnectionString = @"e:\Tabel\Db\tabel.sqlite";

            Employees = new Employees();
            Times = new Times();
            Jobs = new Jobs();
            Objects = new Objects();
            Contracts = new Contracts();
        }

        public static string ConnectionString { get; set; }

        public static SQLiteConnection CreateConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }


        public Employees Employees { get; set; }
        public Times Times { get; set; }

        public Jobs Jobs { get; set; }

        public Objects Objects { get; set; }

        public Contracts Contracts { get; set; }

    }
}
