using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_Tracker.Models
{
    //public class OneTime
    //{
    //    [SQLite.Net.Attributes.PrimaryKey, SQLite.Net.Attributes.AutoIncrement]
    //    public int otpID { get; set; }
    //    public string Name { get; set; }
    //    public double PayAmount { get; set; }
    //    public string DueDate { get; set; }
    //    public int Paid { get; set; }
    //    public string Type { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public bool _isPastDue { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public string _rectColor { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public string _rectVis { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public string _pastVis { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public string _dueDate { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public string _formattedPayAmount { get; set; }


    //    public static List<OneTime> formatOTP(List<OneTime> otpList)
    //    {
    //        var nowMo = DateTime.Today.Month;
    //        var nowYr = DateTime.Today.Year;

    //        foreach (OneTime item in otpList)
    //        {
    //            DateTime itemDate = DateTime.Parse(item.DueDate);

    //            if (nowMo > itemDate.Month && nowYr >= itemDate.Year)
    //            {
    //                item._isPastDue = true;
    //                item._rectColor = "White";
    //                item._pastVis = "Visible";
    //            } else
    //            {
    //                item._isPastDue = false;
    //                item._rectColor = "White";
    //                item._pastVis = "Collapsed";
    //            }

    //            if (item.Paid == 1)
    //            {
    //                item._isPastDue = false;
    //                item._rectColor = "LightGreen";
    //                item._pastVis = "Collapsed";
    //            }

    //            item._dueDate = GenFunc.formatDate(itemDate);

    //            item._formattedPayAmount = GenFunc.formatCurrency(item.PayAmount);
    //        }
    //        return otpList;
    //    }
    //}
}
