using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CACore;
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
            Employees = new Employees();
            Times = new Times();
            Contracts = new Contracts();
            ReportByEmployees = new ReportByEmployees();
        }

        public static string ConnectionString 
        {
            get
            {
                var path = SettingsController<MainSettings>.Settings.DbFilePath;
                return string.Format(@"Data Source={0}; Version=3;", path);
            }
        }

        public static SQLiteConnection CreateConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }


        public Employees Employees { get; set; }
        public Times Times { get; set; }

        public Contracts Contracts { get; set; }

        public ReportByEmployees ReportByEmployees { get; set; }

    }
}
