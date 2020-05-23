using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bill_Tracker.Models
{
    //public class Goal
    //{
    //    [SQLite.Net.Attributes.PrimaryKey, SQLite.Net.Attributes.AutoIncrement]
    //    public int ID { get; set; }
    //    public string goalName { get; set; }
    //    public double goalAmount { get; set; }
    //    public double currentAmount { get; set; }
    //    public string goalDate { get; set; }
    //    public bool isComplete { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public string _completionText { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public double progress { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public string _dispCurAmnt { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public string _dispGoalAmnt { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public string _dispGoalDate { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public DateTime _goalDate { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public string _background { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public string _textFore { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public string _pastSuspense { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public string _barColor { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public string minPay { get; set; }


    //    internal static List<Goal> formatGoalData (List<Goal> glist)
    //    {
    //        foreach (Goal item in glist)
    //        {
    //            item.progress = (item.currentAmount/ item.goalAmount) * 100;
    //            item._dispCurAmnt = GenFunc.formatCurrency(item.currentAmount);
    //            item._dispGoalAmnt = GenFunc.formatCurrency(item.goalAmount);
    //            item._dispGoalDate = GenFunc.formatDate(DateTime.Parse(item.goalDate));
    //            item._goalDate = DateTime.Parse(item.goalDate);

    //            if (item.currentAmount == item.goalAmount)
    //            {
    //                item.isComplete = true;
    //            }

    //            if (item.isComplete == true)
    //            {
    //                item._background = "Lightgreen";
    //                item._completionText = "Complete";
    //                item._barColor = "Green";
    //            } else
    //            {
    //                if (item._goalDate < DateTime.Now)
    //                {
    //                    item._textFore = "Red";
    //                    item._pastSuspense = "Visible";
    //                    item._barColor = "Red";
    //                } else
    //                {
    //                    item._textFore = "Black";
    //                    item._pastSuspense = "Collapsed";
    //                    item._barColor = "Black";
    //                }
    //                item._background = "CornflowerBlue";
    //                item._completionText = "In Progress";
    //            }

    //            item.minPay = calcMinPay(item);
    //        }

    //        return glist;
    //    }
    //    internal static string calcMinPay(Goal curGoal)
    //    {
    //        var dueDate = curGoal._goalDate;
    //        var ammnt = curGoal.goalAmount;           
    //        string minPay = "";
    //        int dateDiff = ((dueDate.Year - DateTime.Now.Year) * 12) + dueDate.Month - DateTime.Now.Month;            


    //        switch (dateDiff)
    //        {
    //            case var expression when dateDiff <= 0:
    //                minPay = "Per Mo: " + (ammnt - curGoal.currentAmount).ToString("C0");
    //                break;
    //            case var expression when dateDiff > 0:
    //                minPay = "Per Mo: " + ((ammnt - curGoal.currentAmount) / dateDiff).ToString("C0");
    //                break;       
    //        }
    //        return minPay;
    //    }

    //}
}
