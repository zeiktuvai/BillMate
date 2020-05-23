using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics;
using System.IO;
using Windows.Storage;
using Windows.Storage.Streams;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Bill_Tracker.Models;


namespace Bill_Tracker.Models
{
    //public class Bill
    //{
    //    [SQLite.Net.Attributes.PrimaryKey, SQLite.Net.Attributes.AutoIncrement]
    //    public int BillID { get; set; }
    //    public string Name { get; set; }
    //    public string dispDueDate { get; set; }
    //    public string Frequency { get; set; }
    //    public double baseAmount { get; set; }
    //    public string Category { get; set; }
    //    public string Reminder { get; set; }

        //public static Bill parse(fbill bill)
        //{
        //    var convBill = new Bill();

        //    convBill.BillID = bill.BillID;
        //    convBill.Name = bill.Name;
        //    convBill.dispDueDate = bill.dispDueDate;
        //    convBill.Frequency = bill.Frequency;
        //    convBill.baseAmount = bill.baseAmount;
        //    convBill.Category = bill.Category;
        //    convBill.Reminder = bill.Reminder;
        //    return convBill;
        //}

        //converted to dataservices
        //public static List<Bill> parse(List<OneTime> otp)
        //{
        //    List<Bill> convList = new List<Bill>();

        //    foreach (OneTime item in otp)
        //    {
        //        var convBill = new Bill();

        //        convBill.BillID = 0;
        //        convBill.Name = item.Name;
        //        convBill.dispDueDate = item.DueDate;
        //        convBill.Frequency = item.Type;
        //        convBill.baseAmount = item.PayAmount;
        //        convBill.Category = item.Type;
        //        convBill.Reminder = "";

        //        convList.Add(convBill);
        //    }

        //    return convList;
        //}
    //}

    //public class fbill : Bill
    //{
    //    public DateTime dueDate { get; set; }
    //    public double Amount { get; set; }
    //    public bool isPaid { get; set; }
    //    public bool isPastDue { get; set; }
    //    public bool isPay { get; set; }
    //    public string catDue { get; set; }
    //    public string _stringDispDate { get; set; }
    //    public string _pastDueColor { get; set; }
    //    public string _pastDueThickness { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public string _RectColor { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public string _RectVisi { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public string _PastDVisi { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public int _pOfBudget { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public bool _isPosted { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public string _DispAmount { get; set; }

    //    public static fbill parse (Bill bill)
    //    {
    //        var convBill = new fbill();

    //        convBill.BillID = bill.BillID;
    //        convBill.Name = bill.Name;
    //        convBill.dispDueDate = bill.dispDueDate;
    //        convBill.Frequency = bill.Frequency;
    //        convBill.baseAmount = bill.baseAmount;
    //        convBill.Category = bill.Category;
    //        convBill.Reminder = bill.Reminder;
    //        return convBill;
    //    }

    //    // converted to data services
    //   // public static List<fbill> retrieveBillData(string sortOrder, int dateShift = 0)
    //   //{
    //   //     Cache.refreshBillCache();
    //   //     var processList = Cache.billCache;
    //   //     List<Bill> billslist = new List<Bill>();
    //   //     var paylist = Payment.parse(Cache.paymentCache);
    //   //     var flist = new List<fbill>();
    //   //     DateTime baseDate = DateTime.Now.AddMonths(dateShift);                
    //   //     List<Bill> otpList = Bill.parse(Cache.otpCache.FindAll(d => DateTime.Parse(d.DueDate).Month == baseDate.Date.Month && DateTime.Parse(d.DueDate).Year == baseDate.Date.Year).ToList());

    //   //     if (otpList.Count > 0)
    //   //     {
    //   //         foreach (var item in otpList)
    //   //         {
    //   //             processList.Add(item);
    //   //         }
    //   //     }

    //   //     //control variables
    //   //     decimal total = 0;
    //   //     double amntRem = 0;
    //   //     int billCnt = 0;
    //   //     double budget = 0;

    //   //     // get budget information
    //   //     if (LocalIO.getSetting("billBdgtAmt") == null)
    //   //     {
    //   //         budget = 1000;
    //   //     }
    //   //     else
    //   //     {
    //   //         budget = double.Parse(LocalIO.getSetting("billBdgtAmt").ToString());
    //   //     }


    //   //     //process bills for due date and archived.
    //   //     foreach (Bill item in processList)
    //   //     {
    //   //         if (item.Reminder.Contains("Archived"))
    //   //         {

    //   //         }
    //   //         else
    //   //         {
    //   //             switch (item.Frequency)
    //   //             {
    //   //                 case "Monthly":
    //   //                     Bill procBill = item;
    //   //                     DateTime dbDueDate = DateTime.Parse(item.dispDueDate);
    //   //                     if (dbDueDate.Day > 28)
    //   //                     {
    //   //                         if (DateTime.DaysInMonth(baseDate.Year, baseDate.Month) < 31)
    //   //                         {
    //   //                             procBill.dispDueDate = new DateTime(baseDate.Year, baseDate.Month, DateTime.DaysInMonth(baseDate.Year, baseDate.Month)).ToString();
    //   //                         }
    //   //                     }
    //   //                     else
    //   //                     {
    //   //                         procBill.dispDueDate = new DateTime(baseDate.Year, baseDate.Month, dbDueDate.Day).ToString();
    //   //                     }                            
    //   //                     billslist.Add(procBill);
    //   //                     //update db with current month due date.
    //   //                     //LocalIO.updateBill(procBill);
    //   //                     break;

    //   //                 case "Bi-Monthly":
    //   //                     Bill procBill1 = new Bill()
    //   //                     {
    //   //                         baseAmount = item.baseAmount,
    //   //                         BillID = item.BillID,
    //   //                         Category = item.Category,
    //   //                         dispDueDate = item.dispDueDate,
    //   //                         Frequency = item.Frequency,
    //   //                         Name = item.Name,
    //   //                         Reminder = item.Reminder
    //   //                     };
    //   //                     Bill procBill2 = new Bill()
    //   //                     {
    //   //                         baseAmount = item.baseAmount,
    //   //                         BillID = item.BillID,
    //   //                         Category = item.Category,
    //   //                         dispDueDate = item.dispDueDate,
    //   //                         Frequency = item.Frequency,
    //   //                         Name = item.Name,
    //   //                         Reminder = item.Reminder
    //   //                     };
    //   //                     var date = item.dispDueDate.Split(',');
    //   //                     DateTime due1;
    //   //                     DateTime due2;
    //   //                     if (date.Count() <= 1)
    //   //                     {
    //   //                         due1 = DateTime.Parse(date[0]);
    //   //                         due2 = DateTime.Parse(date[0]);
    //   //                     }
    //   //                     else
    //   //                     {
    //   //                         due1 = DateTime.Parse(date[0]);
    //   //                         due2 = DateTime.Parse(date[1]);
    //   //                     }

    //   //                     if (due1.Day > 28 || due2.Day > 28)
    //   //                     {
    //   //                         if (DateTime.DaysInMonth(baseDate.Year, baseDate.Month) < 31)
    //   //                         {
    //   //                             if (due1.Day > 28)
    //   //                             {
    //   //                                 procBill1.dispDueDate = new DateTime(baseDate.Year, baseDate.Month, DateTime.DaysInMonth(baseDate.Year, baseDate.Month)).ToString();
    //   //                             }
    //   //                             else
    //   //                             {
    //   //                                 procBill1.dispDueDate = new DateTime(baseDate.Year, baseDate.Month, due1.Day).ToString();
    //   //                             }
    //   //                             if (due2.Day > 28)
    //   //                             {
    //   //                                 procBill2.dispDueDate = new DateTime(baseDate.Year, baseDate.Month, DateTime.DaysInMonth(baseDate.Year, baseDate.Month)).ToString();
    //   //                             }
    //   //                             else
    //   //                             {
    //   //                                 procBill2.dispDueDate = new DateTime(baseDate.Year, baseDate.Month, due2.Day).ToString();
    //   //                             }
    //   //                         }
    //   //                         else
    //   //                         {
    //   //                             procBill1.dispDueDate = new DateTime(baseDate.Year, baseDate.Month, due1.Day).ToString();
    //   //                             procBill2.dispDueDate = new DateTime(baseDate.Year, baseDate.Month, due2.Day).ToString();
    //   //                         }
    //   //                     }
    //   //                     else
    //   //                     { 
    //   //                         procBill1.dispDueDate = new DateTime(baseDate.Year, baseDate.Month, due1.Day).ToString();
    //   //                         procBill2.dispDueDate = new DateTime(baseDate.Year, baseDate.Month, due2.Day).ToString();
    //   //                     }
    //   //                     billslist.Add(procBill1);
    //   //                     billslist.Add(procBill2);

    //   //                     break;

    //   //                 case "Weekly":
    //   //                     int daysInMont = DateTime.DaysInMonth(baseDate.Year, baseDate.Month);


    //   //                     for (int i = 1; i < daysInMont; i++)
    //   //                     {
    //   //                         DateTime currentDate = new DateTime(baseDate.Year, baseDate.Month, i);
    //   //                         if (currentDate.DayOfWeek.ToString() == item.dispDueDate)
    //   //                         {
    //   //                             Bill weeklyBill = new Bill()
    //   //                             {
    //   //                                 baseAmount = item.baseAmount,
    //   //                                 BillID = item.BillID,
    //   //                                 Category = item.Category,
    //   //                                 dispDueDate = currentDate.Date.ToString(),
    //   //                                 Frequency = item.Frequency,
    //   //                                 Name = item.Name,
    //   //                                 Reminder = item.Reminder
    //   //                             };
    //   //                             billslist.Add(weeklyBill);
    //   //                         }
    //   //                     }
    //   //                     break;

    //   //                 case "Annual":
    //   //                     Bill procBilla = item;
    //   //                     var dueDate = DateTime.Parse(procBilla.dispDueDate);
    //   //                     procBilla.dispDueDate = (new DateTime(DateTime.Now.Year, dueDate.Month, dueDate.Day)).ToString();
    //   //                     dueDate = DateTime.Parse(procBilla.dispDueDate);

    //   //                     if (dueDate.Month == baseDate.Month && dueDate.Year == baseDate.Year)
    //   //                     {
    //   //                         billslist.Add(procBilla);                            
    //   //                     }

    //   //                     //if (DateTime.Parse(procBilla.dispDueDate).Year != DateTime.Now.Year )
    //   //                     //{
    //   //                     //    procBilla.dispDueDate = (new DateTime(baseDate.Year, dueDate.Month, dueDate.Day)).ToString();
    //   //                     //}
    //   //                     break;

    //   //                 case "Single Future Payment":
    //   //                     Bill procBillb = item;
    //   //                     billslist.Add(procBillb);
    //   //                     break;

    //   //                 case "OneTime":
    //   //                     Bill procBillOtp = item;
    //   //                     DateTime dbDueDateOtp = DateTime.Parse(item.dispDueDate);
    //   //                     if (dbDueDateOtp.Day > 28)
    //   //                     {
    //   //                         if (DateTime.DaysInMonth(baseDate.Year, baseDate.Month) < 31)
    //   //                         {
    //   //                             procBillOtp.dispDueDate = new DateTime(baseDate.Year, baseDate.Month, DateTime.DaysInMonth(baseDate.Year, baseDate.Month)).ToString();
    //   //                         }
    //   //                     }
    //   //                     else
    //   //                     {
    //   //                         procBillOtp.dispDueDate = new DateTime(baseDate.Year, baseDate.Month, dbDueDateOtp.Day).ToString();
    //   //                     }
    //   //                     billslist.Add(procBillOtp);
    //   //                     //update db with current month due date.
    //   //                     //LocalIO.updateBill(procBill);
    //   //                     break;
    //   //             }
    //   //         }
    //   //     }


    //   //     //Find all payments for each bill
    //   //     foreach (Bill item in billslist)
    //   //     {
    //   //         var nbill = new fbill();
    //   //         nbill = fbill.parse(item);
    //   //         DateTime today = DateTime.Today.Date;

    //   //         DateTime dbDueDate = DateTime.Parse(nbill.dispDueDate);
    //   //         List<Payment> listOfPay = paylist.FindAll(p => p.BillID == nbill.BillID);
    //   //         var billPay = listOfPay.Where(d => DateTime.Parse(d.dispPayDate).Month == baseDate.Month && DateTime.Parse(d.dispPayDate).Year == baseDate.Year).ToList();

    //   //         if (nbill.Frequency == "Annual")
    //   //         {
    //   //             nbill.dueDate = dbDueDate;
    //   //             billPay.AddRange(listOfPay.Where(f => DateTime.Parse(f.dispPayDate).Year == baseDate.Year).ToList());
    //   //         }
    //   //         else
    //   //         {
    //   //             nbill.dueDate = new DateTime(baseDate.Year, baseDate.Month, dbDueDate.Day);
    //   //         }

    //   //         nbill._DispAmount = GenFunc.formatCurrency(item.baseAmount);

    //   //         //get payment info
    //   //         foreach (Payment pay in billPay)
    //   //         {
    //   //             switch (nbill.Frequency)
    //   //             {
    //   //                 case "Monthly":
    //   //                     nbill.Amount = pay.amount;                            
    //   //                     nbill.isPaid = true;
    //   //                     total += Convert.ToDecimal(pay.amount);
    //   //                     if (dateShift == -1)
    //   //                     {
    //   //                         nbill.dueDate = DateTime.Parse(pay.dispPayDate);
    //   //                     }
    //   //                     break;
    //   //                 case "Bi-Monthly":
    //   //                     if (System.DateTime.Parse(pay.dispPayDate).Day == System.DateTime.Parse(nbill.dispDueDate).Day)
    //   //                     {
    //   //                         nbill.Amount = pay.amount;
    //   //                         nbill.isPaid = true;
    //   //                         total += Convert.ToDecimal(pay.amount);
    //   //                     }
    //   //                     break;
    //   //                 case "Weekly":
    //   //                     if (System.DateTime.Parse(pay.dispPayDate).Day == System.DateTime.Parse(nbill.dispDueDate).Day)
    //   //                     {
    //   //                         nbill.Amount = pay.amount;
    //   //                         nbill.isPaid = true;
    //   //                         total += Convert.ToDecimal(pay.amount);
    //   //                     }
    //   //                     break;
    //   //                 case "Annual":
    //   //                     nbill.Amount = pay.amount;
    //   //                     nbill.isPaid = true;
    //   //                     total += Convert.ToDecimal(pay.amount);
    //   //                     break;
    //   //                 case "Single Future Payment":
    //   //                     nbill.Amount = pay.amount;
    //   //                     nbill.isPaid = true;
    //   //                     total += Convert.ToDecimal(pay.amount);
    //   //                     break;
    //   //             }

    //   //         }

    //   //         //if no payment set defaults
    //   //         if (!nbill.isPaid == true)
    //   //         {
    //   //             if (nbill.Amount == 0 || nbill.isPaid == false)
    //   //             {
    //   //                 nbill.isPaid = false;
    //   //                 nbill.Amount = nbill.baseAmount;
    //   //             }
    //   //         }

    //   //         billCnt++;


    //   //         nbill._stringDispDate = nbill.dueDate.ToString("dddd, dd MMMM yyyy");


    //   //         //Past due section

    //   //         if (nbill.isPaid == true)
    //   //         {
    //   //             nbill.isPastDue = false;
    //   //         }
    //   //         else
    //   //         {
    //   //             //if (nbill.Frequency != "OneTime")
    //   //             //{
    //   //                 if (today > nbill.dueDate)
    //   //                 {
    //   //                     nbill.isPastDue = true;
    //   //                     amntRem += nbill.baseAmount;
    //   //                 }
    //   //                 else
    //   //                 {
    //   //                     nbill.isPastDue = false;
    //   //                     amntRem += nbill.baseAmount;
    //   //                 }
    //   //            // }
    //   //         }




    //   //         if (sortOrder == "srtByCat")
    //   //         {
    //   //             nbill.catDue = nbill._stringDispDate;
    //   //         }
    //   //         else
    //   //         {
    //   //             nbill.catDue = nbill.Category;
    //   //         }

    //   //         switch (nbill.Frequency)
    //   //         {
    //   //             case "OneTime":
    //   //                 nbill._pastDueColor = "White";
    //   //                 nbill._RectColor = "Orchid";
    //   //                 nbill._RectVisi = "Visible";
    //   //                 nbill._PastDVisi = "Collapsed";
    //   //                 break;
    //   //             case "Annual":
    //   //                 nbill._pastDueColor = "White";
    //   //                 nbill._RectColor = "Brown";
    //   //                 nbill._RectVisi = "Visible";
    //   //                 nbill._PastDVisi = "Collapsed";
    //   //                 break;
    //   //             default:
    //   //                 nbill._pastDueColor = "White";
    //   //                 nbill._RectColor = "Blue";
    //   //                 nbill._RectVisi = "Visible";
    //   //                 nbill._PastDVisi = "Collapsed";
    //   //                 break;
    //   //         }

    //   //         if (nbill.isPastDue == true)
    //   //         {
    //   //             if (nbill.Frequency == "OneTime")
    //   //             {
    //   //                 nbill._pastDueColor = "White";
    //   //                 nbill._RectColor = "Orchid";
    //   //                 nbill._RectVisi = "Visible";
    //   //                 nbill._PastDVisi = "Visible";
    //   //             } else
    //   //             {
    //   //                 nbill._pastDueColor = "White";
    //   //                 nbill._RectColor = "DarkRed";
    //   //                 nbill._RectVisi = "Collapsed";
    //   //                 nbill._PastDVisi = "Visible";
    //   //             }
    //   //         }
    //   //         else if (nbill.isPaid == true)
    //   //         {
    //   //             nbill._pastDueColor = "#61BF80";
    //   //             nbill._RectColor = "DarkGreen";
    //   //             nbill._RectVisi = "Visible";
    //   //             nbill._PastDVisi = "Collapsed";
    //   //         }

    //   //         int pob = (int)((item.baseAmount / budget) * 100);
    //   //         if (pob > 100)
    //   //         {
    //   //             pob = 100;
    //   //         }
    //   //         else if (pob < 0)
    //   //         {
    //   //             pob = 0;
    //   //         }
    //   //         nbill._pOfBudget = pob;

    //   //         if (nbill.isPaid == true)
    //   //         {
    //   //             if (nbill.Frequency != "Annual")
    //   //             {
    //   //                 var isanypay = Cache.paymentCache.Find(p => p.BillID == nbill.BillID && DateTime.Parse(p.dispPayDate).Month == DateTime.Now.AddMonths(Globals._WORKING_MONTH).Month && DateTime.Parse(p.dispPayDate).Year == DateTime.Now.AddMonths(Globals._WORKING_MONTH).Year);
    //   //                 if (isanypay != null)
    //   //                 {
    //   //                     nbill._isPosted = isanypay.posted;
    //   //                 } else
    //   //                 {
    //   //                     nbill._isPosted = false;
    //   //                 }
    //   //             }

    //   //         }
    //   //         else
    //   //         {
    //   //             nbill._isPosted = false;
    //   //         }


    //   //         flist.Add(nbill);
    //   //     }


    //   //     return flist;
    //   // }

                             
    //}

    //public class Payment
    //{
    //    [SQLite.Net.Attributes.PrimaryKey, SQLite.Net.Attributes.AutoIncrement]
    //    public int paymentID { get; set; }
    //    public int BillID { get; set; }
    //    public string dispPayDate { get; set; }
    //    public double amount { get; set; }
    //    public bool posted { get; set; }

        //public static Payment parse(Payment payment)
        //{
        //    var convPay = new Payment();

        //    convPay.paymentID = payment.paymentID;
        //    convPay.BillID = payment.BillID;
        //    if (payment.dispPayDate.Length <= 10)
        //    {
        //        convPay.dispPayDate = payment.dispPayDate;
        //    }
        //    else
        //    {
        //        convPay.dispPayDate = payment.dispPayDate.Substring(0, payment.dispPayDate.IndexOf(' '));
        //    }            
        //    convPay.amount = payment.amount;
        //    convPay.posted = payment.posted;           

        //    return convPay;
        //}

        //public static List<Payment> parse(List<Payment> payments)
        //{
        //    List<Payment> convList = new List<Payment>();
        //    foreach (Payment paym in payments)
        //    {
        //        var convPay = new Payment();
        //        convPay.paymentID = paym.paymentID;
        //        convPay.BillID = paym.BillID;
        //        if (paym.dispPayDate.Length <= 10)
        //        {
        //            convPay.dispPayDate = paym.dispPayDate;
        //        } else
        //        {
        //            convPay.dispPayDate = paym.dispPayDate.Substring(0, paym.dispPayDate.IndexOf(' '));
        //        }
        //        convPay.amount = paym.amount;
        //        convPay.posted = paym.posted;
        //        convList.Add(convPay);
        //    }

        //    return convList;
        //}
    //}
    //public class fPayment : Payment
    //{
    //    public string billName { get; set; }
    //    public DateTime payDate { get; set; }
    //    public string _ledgerBalanceColor { get; set; }
    //    public double ledgerBalance { get; set; }
    //    public string _ledgerBalance { get; set; }
    //    public string _displayDate { get; set; }
    //    public string _ledgerLinePosted { get; set; }
    //    public string _displayAmount { get; set; }
    //    public string _bgColor { get; set; }

        //public static fPayment parse(fPayment payment)
        //{
        //    var convPay = new fPayment();

        //    convPay.paymentID = payment.paymentID;
        //    convPay.BillID = payment.BillID;
        //    if (payment.dispPayDate.Length < 10)
        //    {
        //        convPay.dispPayDate = payment.dispPayDate;
        //    }
        //    else
        //    {
        //        convPay.dispPayDate = payment.dispPayDate.Substring(0, payment.dispPayDate.IndexOf(' '));
        //    }            
        //    convPay.amount = payment.amount;
        //    convPay.posted = payment.posted;
        //    convPay.billName = Cache.billCache.Find(b => b.BillID == convPay.BillID).Name; //    LocalIO.getSingleBill(convPay.BillID)).Name;
        //    convPay.payDate = DateTime.Parse(convPay.dispPayDate);
        //    convPay._ledgerBalanceColor = "";
        //    convPay._ledgerLinePosted = "";
        //    convPay.ledgerBalance = 0;
        //    convPay._ledgerBalance = "";
        //    convPay._displayDate = (DateTime.Parse(payment.dispPayDate)).ToString("MM/dd/yyyy");
        //    convPay._displayAmount = GenFunc.formatCurrency(payment.amount);
        //    convPay._bgColor = setPayBGColor(convPay.posted);

        //    return convPay;
        //}

        //public static List<fPayment> Parse(List<Payment> payment)
        //{
        //    List<fPayment> convList = new List<fPayment>();

        //    foreach (Payment paym in payment)
        //    {
        //    var convPay = new fPayment();

        //    convPay.paymentID = paym.paymentID;
        //    convPay.BillID = paym.BillID;
        //        if (paym.dispPayDate.Length <= 10)
        //        {
        //            convPay.dispPayDate = paym.dispPayDate;
        //        }
        //        else
        //        {
        //            convPay.dispPayDate = paym.dispPayDate.Substring(0, paym.dispPayDate.IndexOf(' '));
        //        }                
        //    convPay.amount = paym.amount;
        //    convPay.posted = paym.posted;
        //        convPay._bgColor = setPayBGColor(paym.posted);
        //        try
        //        {
        //            convPay.billName = Cache.billCache.Find(b => b.BillID == convPay.BillID).Name;
        //            convPay.payDate = DateTime.Parse(convPay.dispPayDate);
        //            convPay._ledgerBalanceColor = "";
        //            convPay._ledgerLinePosted = "";
        //            convPay.ledgerBalance = 0;
        //            convPay._ledgerBalance = "";
        //            convPay._displayDate = (DateTime.Parse(paym.dispPayDate)).ToString("MM/dd/yyyy");
        //            convPay._displayAmount = GenFunc.formatCurrency(paym.amount);

        //            convList.Add(convPay);
        //        }
        //        catch (Exception)
        //        {

        //        }
        //    }


        //    return convList;
        //}

        //internal static string setPayBGColor(bool post)
        //{
        //    string bgcolor;
        //    if (post == true)
        //    {
        //        bgcolor = "DarkGreen";
        //    } else
        //    {
        //        bgcolor = "LightGray";
        //    }
        //    return bgcolor;
        //}

        //internal static List<fPayment> Parse(IEnumerable<Payment> selPayments)
        //{
        //    List<fPayment> convList = new List<fPayment>();

        //    foreach (Payment paym in selPayments)
        //    {
        //        var convPay = new fPayment();

        //        convPay.paymentID = paym.paymentID;
        //        convPay.BillID = paym.BillID;
        //        convPay.dispPayDate = paym.dispPayDate;
        //        convPay.amount = paym.amount;
        //        convPay.posted = paym.posted;
        //        convPay.billName = Cache.billCache.Find(b => b.BillID == convPay.BillID).Name;
        //        convPay.payDate = DateTime.Parse(convPay.dispPayDate);
        //        convPay._ledgerBalanceColor = "";
        //        convPay.ledgerBalance = 0;
        //        convPay._ledgerBalance = "";
        //        convPay._displayDate = (DateTime.Parse(paym.dispPayDate)).ToString("MM/dd/yyyy");
        //        convPay._displayAmount = GenFunc.formatCurrency(paym.amount);
        //        convPay._bgColor = setPayBGColor(paym.posted);

        //        convList.Add(convPay);
        //    }


        //    return convList;
        //}
    //}


    //public class version
    //{
    //    [SQLite.Net.Attributes.PrimaryKey, SQLite.Net.Attributes.AutoIncrement]
    //    public int verID { get; set; }
    //    public string ver { get; set; }
    //}
}
