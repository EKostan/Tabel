using System;

namespace Contract
{
    public class ReportByEmployeesRecord : Record
    {
        public string Date { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public int Cost { get; set; }
        
        public int Hours { get; set; }

        public int ContractId { get; set; }

        public string ContractCode { get; set; }
        public string ContractName { get; set; }
        public string ObjectName { get; set; }
        

    }
}