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
            _view.SetReportByEmployees(Convert(data, _view.BeginDate, _view.EndDate));
        }

        Dictionary<string, List<ReportByEmployeesRecord>> GetRecordByEmpContr(List<ReportByEmployeesRecord> records)
        {
            var res = new Dictionary<string, List<ReportByEmployeesRecord>>();

            foreach (var record in records)
            {
                var key = GetKey(record);
                if(!res.ContainsKey(key))
                    res[key] = new List<ReportByEmployeesRecord>();

                res[key].Add(record);
            }

            return res;
        }

        private string GetKey(ReportByEmployeesRecord record)
        {
            return "EmployeeId=" + record.EmployeeId + "::" + "ContractId=" + record.ContractId;
        }


        List<ReportRecord> Convert(List<ReportByEmployeesRecord> records, DateTime beginDate, DateTime endDate)
        {
            var res = new List<ReportRecord>();
            var byEmpCotr = GetRecordByEmpContr(records);

            var dates = CreateDates(_view.BeginDate, _view.EndDate);

            // создаем записи

            var sumDict = new Dictionary<string, DateHours>();
            var sumByDates = new Dictionary<string, Dictionary<string, DateHours>>();

            foreach (var item in byEmpCotr)
            {
                if(item.Value.Count <=0 )
                    continue;


                var rec = new ReportRecord
                {
                    EmployeeName = item.Value[0].EmployeeName,
                    ObjectName = item.Value[0].ObjectName,
                    ContractName = item.Value[0].ContractName
                };

                int sumCost = 0;
                int sumHours = 0;

                foreach (var date in dates)
                {
                    int cost = 0;
                    int hours = 0;
                    var findRec = item.Value.FirstOrDefault(x => x.Date == date.Key);

                    if (findRec != null)
                    {
                        cost = findRec.Cost;
                        hours = findRec.Hours;

                        sumCost += cost;
                        sumHours += hours;

                        if(!sumDict.ContainsKey(findRec.EmployeeName))
                            sumDict[findRec.EmployeeName] = new DateHours();
                        sumDict[findRec.EmployeeName].Cost += cost;
                        sumDict[findRec.EmployeeName].Hours += hours;

                        if(!sumByDates.ContainsKey(findRec.EmployeeName))
                            sumByDates[findRec.EmployeeName] = new Dictionary<string, DateHours>();

                        if(!sumByDates[findRec.EmployeeName].ContainsKey(date.Key))
                            sumByDates[findRec.EmployeeName][date.Key] = new DateHours();
                        
                        sumByDates[findRec.EmployeeName][date.Key].Cost += cost;
                        sumByDates[findRec.EmployeeName][date.Key].Hours += hours;
                        sumByDates[findRec.EmployeeName][date.Key].Date = date.Key;


                    }

                    rec.DateHours.Add(new DateHours(){Date = date.Key, Cost = cost, Hours = hours});
                }

                rec.SumCost = sumCost;
                rec.SumHours = sumHours;
                res.Add(rec);
            }

            foreach (var item in sumDict)
            {
                var rec = new ReportRecord()
                {
                    EmployeeName = item.Key,
                    SumHours = item.Value.Hours,
                    SumCost = item.Value.Cost,
                    DateHours = sumByDates[item.Key].Values.ToList(),
                    RecordType = RecordType.Sum,
                    ObjectName = "ИТОГО:"
                };
                res.Add(rec);
            }

            res = res.OrderBy(x => x.EmployeeName).ToList();

            return res;
        }

        Dictionary<string, string> CreateDates(DateTime beginDate, DateTime endDate)
        {
            var res = new Dictionary<string, string>();
            var curDate = new DateTime(beginDate.Year, beginDate.Month, beginDate.Day);
            while (curDate <= endDate)
            {
                res.Add(curDate.ToString("yyyy-MM-dd"), curDate.ToString("yyyy-MM-dd"));
                curDate = curDate.AddDays(1);
            }

            return res;
        }
            
        DataTable CreateDataTable(List<ReportByEmployeesRecord> records)
        {
            var table = new DataTable();

            // Инженер
            var empCol = table.Columns.Add();
            empCol.Caption = "Инженер";
            empCol.ColumnName = "EmployeeName";


            var row = table.NewRow();
            row["EmployeeName"] = "Епишин";
            table.Rows.Add(row);

            return table;
        }

      
        

        public void Dispose()
        {
            _view.Load -= _view_Load;
        }
    }

    enum RecordType
    {
        None,
        Sum
    }

    class ReportRecord
    {
        public string EmployeeName { get; set; }
        public string ObjectName { get; set; }
        public string ContractName { get; set; }

        
        public List<DateHours> DateHours = new List<DateHours>();
        public RecordType RecordType = RecordType.None;

        public int SumHours { get; set; }
        public int SumCost { get; set; }
    }

    class DateHours
    {
        public string Date { get; set; }

        public int Hours { get; set; }

        public int Cost { get; set; }

    }

}