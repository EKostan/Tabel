using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using TabelWeb.Models;

namespace TabelWeb.Dal
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base(new SQLiteConnection(@"Data Source=e:\Tabel\Db\mydatabase.sqlite; Version=3;"), true)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }

    }
}