using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class EmployeeRecord : Record
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public string Position { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }
        
    }
}
