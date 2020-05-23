using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bill_Tracker.Models
{
    //public enum acctType { Credit, Loan }
    //public class Account
    //{
    //    [SQLite.Net.Attributes.PrimaryKey, SQLite.Net.Attributes.AutoIncrement]
    //    public int accountID { get; set; }
    //    public string acctName { get; set; }
    //    public double acctBal { get; set; }
    //    public double startBal { get; set; }
    //    public double creditLimit { get; set; }
    //    public DateTime startDate { get; set; }
    //    public double mnthPayAmnt { get; set; }
    //    public double APR { get; set; }
    //    public acctType acctType { get; set; }
    //    public int billID { get; set; }
    //    public int closed { get; set; }


    //    //public static Account parse(fAccount acct)
    //    //{
    //    //    return new Account()
    //    //    {
    //    //        accountID = acct.accountID,
    //    //        acctName = acct.acctName,
    //    //        acctBal = acct.acctBal,
    //    //        creditLimit = acct.creditLimit,
    //    //        startBal = acct.startBal,
    //    //        startDate = acct.startDate,
    //    //        mnthPayAmnt = acct.mnthPayAmnt,
    //    //        APR = acct.APR,
    //    //        acctType = acct.acctType,
    //    //        billID = acct.billID,
    //    //        closed = acct.closed
    //    //    };
    //    //}

    //    public double getAcctBal()
    //    {             
    //        var bal = Cache.transCache.FindAll(t => t.accountID == accountID).Sum(s => s.entryAmount);
    //        return bal;
    //    }
    //}

    //public class fAccount : Account
    //{
    //    public string estPayoff { get; set; }
    //    public string dispStartDate { get; set; }
    //    public string dispBal { get; set; }
    //    public string dispMonthly { get; set; }
    //    public string dispColor { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public int _currPercentage { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public string _Limit { get; set; }
    //    [SQLite.Net.Attributes.Ignore]
    //    public string _radialColor { get; set; }

        //public static List<fAccount> parse(List<Account> aList)
        //{
        //    var fList = new List<fAccount>();

        //    foreach (var acct in aList)
        //    {
        //        fList.Add(new fAccount()
        //        {
        //            dispStartDate = GenFunc.formatDate(acct.startDate),
        //            dispBal = GenFunc.formatCurrency(acct.acctBal),
        //            dispMonthly = GenFunc.formatCurrency(acct.mnthPayAmnt),
        //            accountID = acct.accountID,
        //            acctBal = acct.acctBal,
        //            creditLimit = acct.creditLimit,
        //            acctName = acct.acctName,
        //            acctType = acct.acctType,
        //            APR = acct.APR,
        //            billID = acct.billID,
        //            closed = acct.closed,
        //            mnthPayAmnt = acct.mnthPayAmnt,
        //            startBal = acct.startBal,                    
        //            startDate = acct.startDate,
        //            estPayoff = ""
                    
        //        });
        //    }

        //    foreach (var item in fList)
        //    {
        //        if (item.acctType == acctType.Credit)
        //        {
        //            item.dispColor = "CornflowerBlue";
        //        } else
        //        {
        //            item.dispColor = "LightGreen";
        //        }
        //    }

        //    return fList;
        //}

        //public double getBalance()
        //{
        //    return double.Parse(this.dispBal.TrimStart('$'));
        //}

        //public static List<fAccount> formatAccount(List<fAccount> alist)
        //{
        //    var accounts = alist;
        //    foreach (fAccount item in accounts)
        //    {
        //        var transact = Cache.transCache.FindAll(t => t.accountID == item.accountID).ToList();
        //        var balance = transact.Sum(s => s.entryAmount);
        //        item.dispBal = GenFunc.formatCurrency(balance);

             

        //        double payoffDays = Models.Calculate.Finance.creditPayoffMo(item.APR, balance, item.mnthPayAmnt);
        //        if (!(double.IsNaN(payoffDays)) && !(double.IsInfinity(payoffDays)))
        //        {
        //            item.estPayoff = GenFunc.formatDate(DateTime.Now.AddMonths((int)payoffDays));
        //        }
        //        else
        //        {
        //            item.estPayoff = "Unknown";
        //        }

        //        if (!(item.billID == 0))
        //        {
        //            item.dispMonthly = GenFunc.formatCurrency(Cache.billCache.Find(b => b.BillID == item.billID).baseAmount);

        //            var bill = Cache.billCache.Find(b => b.BillID == item.billID);
        //            if (bill.Name != item.acctName)
        //            {
        //                item.acctName = bill.Name;
        //                LocalIO.updateAcct(Account.parse(item));
        //            }
        //        }

        //        if (item.acctType == acctType.Credit)
        //        {                    
        //            item._currPercentage = Convert.ToInt32((Convert.ToDouble(balance) / item.creditLimit) * 100);
        //            item._Limit = GenFunc.formatCurrency(item.creditLimit);
        //        }
        //        else
        //        {                 
        //            item._currPercentage = Convert.ToInt32((Convert.ToDouble(balance) / item.startBal) * 100);
        //            item._Limit = GenFunc.formatCurrency(item.startBal);
        //        }
        //        if (item._currPercentage > 80)
        //        {
        //            item._radialColor = "Red";
        //        }
        //        else
        //        {
        //            item._radialColor = "Blue";
        //        }
        //    }

        //    return accounts;
        //}

        //public static void applyCreditInterest()
        //{
        //    var creditAcct = formatAccount(parse(Cache.acctCache.FindAll(a => a.acctType == acctType.Credit).ToList()));            
        //    DateTime currDte = DateTime.Now.Date;

        //    if (creditAcct.Count != 0)
        //    {
        //        foreach (fAccount item in creditAcct)
        //        {
        //            if (!(GenFunc.extractCurrencyVal(item.dispBal) <= 0))
        //            {
        //                var trans = Cache.transCache.FindAll(t => t.accountID == item.accountID).FindAll(ti => ti.isInterest == true).Find(tim => tim.entryDate.Month == currDte.Month);
        //                if (trans == null)
        //                {
        //                    if (currDte.Month != item.startDate.Month || currDte.Year != item.startDate.Year)
        //                    {
        //                        LocalIO.addTransaction(new Trans()
        //                        {
        //                            accountID = item.accountID,
        //                            Desc = "Monthly Interest",
        //                            entryAmount = Math.Truncate((Calculate.Finance.monthlyInterest(item.APR, double.Parse(item.dispBal.TrimStart('$')))) * 100) / 100,
        //                            entryDate = currDte,
        //                            isInterest = true,
        //                            intrestAmount = 0,
        //                            paymentID = 0
        //                        });
        //                    }
        //                }              

        //            }
        //        }

        //        Cache.refreshTransCache();
        //    }

        //}

    //}


    //public class Trans
    //{
    //    [SQLite.Net.Attributes.PrimaryKey, SQLite.Net.Attributes.AutoIncrement]
    //    public int ID { get; set; }
    //    public double entryAmount { get; set; }
    //    public double intrestAmount { get; set; }
    //    public DateTime entryDate { get; set; }
    //    public string Desc { get; set; }
    //    public bool isInterest { get; set; }
    //    public int accountID { get; set; }
    //    public int paymentID { get; set; }    
    //    [SQLite.Net.Attributes.Ignore]
    //    public string _entDate { get; set; }

    //    public static List<Trans> formatTrans (List<Trans> tranlist)
    //    {
    //        foreach (Trans item in tranlist)
    //        {
    //            item._entDate = GenFunc.formatDate(item.entryDate);
    //        }
    //        return tranlist;
    //    }
    //}
}
