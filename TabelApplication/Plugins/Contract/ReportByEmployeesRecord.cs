using System;

namespace Contract
{
    public class ReportByEmployeesRecord : Record
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string Month { get; set; }
        
        public int Hours { get; set; }


    }
}