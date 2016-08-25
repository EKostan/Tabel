using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Contract;

namespace ReferenceEditor.Reports.ByEmployees
{
    class ReportByEmployeesPresenter : IDisposable
    {
        private ReportByEmployeesControl _view;

        public ReportByEmployeesPresenter(ReportByEmployeesControl view)
        {
            _view = view;
            _view.Load += _view_Load;

        }

        void _view_Load(object sender, System.EventArgs e)
        {
            ReloadData();
        }

        public void ReloadData()
        {
            var data = Project.Current.ReportByEmployees.Get(_view.BeginDate, _view.EndDate);
            data = FillMissingDates(data, _view.BeginDate, _view.EndDate);
            _view.SetReportByEmployees(data);
        }

        private List<ReportByEmployeesRecord> FillMissingDates(List<ReportByEmployeesRecord> records, DateTime beginDate, DateTime endDate)
        {
            var res = new List<ReportByEmployeesRecord>(records);
            var dates = CreateDates(beginDate, endDate);

            var dictByDate = GetRecByDate(records);

            var rec = records.First(x => x.EmployeeId > 0);

            foreach (var date in dates)
            {
                if (dictByDate.ContainsKey(date.Key))
                    continue;

                res.Add(new ReportByEmployeesRecord() { Date = date.Key, ContractCode = rec.ContractCode, EmployeeName = rec.EmployeeName, ObjectName = rec.ObjectName});


            }

            return res;
        }

        private Dictionary<DateTime, List<ReportByEmployeesRecord>> GetRecByDate(List<ReportByEmployeesRecord> records)
        {
            var res = new Dictionary<DateTime, List<ReportByEmployeesRecord>>();

            foreach (var record in records)
            {
                if (!res.ContainsKey(record.Date))
                    res[record.Date] = new List<ReportByEmployeesRecord>();

                res[record.Date].Add(record);
            }

            return res;
        }


        Dictionary<DateTime, DateTime> CreateDates(DateTime beginDate, DateTime endDate)
        {
            var res = new Dictionary<DateTime, DateTime>();
            var curDate = new DateTime(beginDate.Year, beginDate.Month, beginDate.Day);
            while (curDate <= endDate)
            {
                res.Add(curDate, curDate);
                curDate = curDate.AddDays(1);
            }

            return res;
        }
            

      
        

        public void Dispose()
        {
            _view.Load -= _view_Load;
        }
    }

   
    

}