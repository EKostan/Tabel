using System;
using System.Collections.Generic;
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
            var data = Project.Current.ReportByEmployees.Get(_view.Year);
            var records = ConvertRecords(data);
            _view.SetReportByEmployees(records);
        }

        private List<Record> ConvertRecords(List<ReportByEmployeesRecord> data)
        {
            var byEmp = CollectByEmployees(data);
            var res = new List<Record>();

            foreach (var item in byEmp)
            {
                var record = new Record(){EmployeeName = item.Key};

                foreach (var repByEmpRec in item.Value)
                {
                    FillHoursByMonth(repByEmpRec, record);
                }

                res.Add(record);
            }


            return res;
        }

        Dictionary<string, List<ReportByEmployeesRecord>> CollectByEmployees(List<ReportByEmployeesRecord> data)
        {
            var res = new Dictionary<string, List<ReportByEmployeesRecord>>();

            foreach (var record in data)
            {
                if(!res.ContainsKey(record.EmployeeName))
                    res.Add(record.EmployeeName, new List<ReportByEmployeesRecord>());

                res[record.EmployeeName].Add(record);
            }

            return res;
        }


        void FillHoursByMonth(ReportByEmployeesRecord recByEmp, Record rec)
        {
            switch (recByEmp.Month)
            {
                case "01":
                    rec.Jan += recByEmp.Hours;
                    break;
                case "02":
                    rec.Feb += recByEmp.Hours;
                    break;
                case "03":
                    rec.March += recByEmp.Hours;
                    break;
                case "04":
                    rec.Apr += recByEmp.Hours;
                    break;
                case "05":
                    rec.May += recByEmp.Hours;
                    break;
                case "06":
                    rec.June += recByEmp.Hours;
                    break;
                case "07":
                    rec.Jule += recByEmp.Hours;
                    break;
                case "08":
                    rec.Aug += recByEmp.Hours;
                    break;
                case "09":
                    rec.Sep += recByEmp.Hours;
                    break;
                case "10":
                    rec.Oct += recByEmp.Hours;
                    break;
                case "11":
                    rec.Nov += recByEmp.Hours;
                    break;
                case "12":
                    rec.Dec += recByEmp.Hours;
                    break;
            }
        }

        public void Dispose()
        {
            _view.Load -= _view_Load;
        }
    }


    class Record
    {
        public string EmployeeName { get; set; }

        public int Jan { get; set; }
        public int Feb { get; set; }
        public int March { get; set; }
        public int Apr { get; set; }
        public int May { get; set; }
        public int June { get; set; }
        public int Jule { get; set; }
        public int Aug { get; set; }
        public int Sep { get; set; }
        public int Oct { get; set; }
        public int Nov { get; set; }
        public int Dec { get; set; }
    }

}