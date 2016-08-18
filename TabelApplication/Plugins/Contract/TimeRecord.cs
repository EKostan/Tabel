﻿namespace Contract
{
    public class TimeRecord : Record
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public int JobId { get; set; }
        public string JobName { get; set; }


        public int ObjectId { get; set; }
        public string ObjectName { get; set; }
    }
}