using System;
using Windows.Storage;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
using Windows.System;
using SQLite;

namespace Bill_Tracker.Models
{
    //public static class LocalIO
    //{
    //    internal static string dbLoc = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "bills.db3");
    //    internal static SQLiteConnection con = null;
        //converted
        //public static Object getSetting(string settingName)
        //{
        //    ApplicationDataContainer localsettings = ApplicationData.Current.LocalSettings;
        //    Object value = localsettings.Values[settingName];
        //    return value;
        //}
        //converted
        //internal static void setSetting(string settingName, string value)
        //{
        //    ApplicationDataContainer localsettings = ApplicationData.Current.LocalSettings;
        //    localsettings.Values[settingName] = value;            
        //}
        //converted
        //internal static bool checkSetting(string settingName)
        //{
        //    ApplicationDataContainer localsettings = ApplicationData.Current.LocalSettings;
        //    return localsettings.Values.ContainsKey(settingName);
        //}

        //public static void openDB()
        //{
        //    con = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), dbLoc);
        //}

        //public static void closeDB()
        //{
        //    con.Close();
        //}



        //table operations
        //internal static List<Bill> getBillTable()
        //{
        //    var billsLst = new List<Bill>();
        //    billsLst = (from p in con.Table<Bill>() select p).ToList();

        //    return billsLst;
        //}

        //internal static List<Payment> getPaymentTable()
        //{
        //    var payLst = new List<Payment>();
        //    payLst = (from p in con.Table<Payment>() select p).ToList();

        //    return payLst;
        //}

        //internal static List<Account> getAcctTable()
        //{
        //    var billsLst = new List<Account>();
        //    billsLst = (from p in con.Table<Account>() select p).ToList();

        //    return billsLst;
        //}

        //internal static List<version> getVersionTable()
        //{
        //    var currentVersion = (from p in con.Table<version>() select p).ToList();
        //    return currentVersion;
        //}

        //internal static List<Trans> getTransactionTable()
        //{
        //    return (from p in con.Table<Trans>() select p).ToList();
        //}

        //internal static List<Goal> getGoalTable()
        //{
        //    return (from g in con.Table<Goal>() select g).ToList();
        //}

        //internal static List<OneTime> getOtpTable()
        //{
        //    return (from o in con.Table<OneTime>() select o).ToList();
        //}

        //bill operations
        //internal static Bill getSingleBill(int billid)
        //{
        //    var sBill = new Bill();
        //    sBill = con.Table<Bill>().Where(p => p.BillID == billid).SingleOrDefault();
        //    return sBill;
        //}


        //internal static void updateBill(Bill updtBill)
        //{
        //    con.Update(updtBill);
        //    Cache.refreshBillCache();
        //}

        //internal static void createBill(Bill cBill)
        //{
        //    con.Insert(cBill);
        //    Cache.refreshBillCache();
        //}

        //internal static void deleteBill(Bill dBill)
        //{
        //    //implememnt in deletion code
        //    List<Payment> dPay = con.Table<Payment>().Where(p => p.BillID == dBill.BillID).ToList<Payment>();
        //    foreach (Payment item in dPay)
        //    {
        //        con.Delete(item);
        //    }

        //    con.Delete(dBill);
        //    //Cache.refreshBillCache();
        //}

        //Payment Operations
        //internal static void createPayment(Payment pay)
        //{
        //    con.Insert(pay);
        //    Cache.refreshPaymentCache();
        //}
        //internal static void updatePaymen(Payment uPay)
        //{
        //    con.Update(uPay);
        //    Cache.refreshPaymentCache();
        //}

        //internal static void removePayment(Payment dPay)
        //{
        //    con.Delete(dPay);
        //    Cache.refreshPaymentCache();
        //}

        //account operations
        //internal static void addAcct(Account aAcct)
        //{
        //    con.Insert(aAcct);
        //    Cache.refreshAcctCache();
        //}

        //internal static void updateAcct(Account aAcct)
        //{
        //    con.Update(aAcct);
        //    Cache.refreshAcctCache();
        //}

        //internal static void deleteAcct(Account dAcct)
        //{
        //    con.Delete(dAcct);
        //    Cache.refreshAcctCache();
        //}

        //internal static void addTransaction(Trans aTrans)
        //{
        //    con.Insert(aTrans);
        //    Cache.refreshTransCache();
        //}

        //internal static void removeTransaction(Trans rTrans)
        //{
        //    con.Delete(rTrans);
        //    Cache.refreshTransCache();
        //}

        //goal operations
        //internal static void addGoal(Goal aGoal)
        //{
        //    con.Insert(aGoal);
        //    Cache.refreshGoalCache();
        //}

        //internal static void updateGoal(Goal uGoal)
        //{
        //    con.Update(uGoal);
        //    Cache.refreshGoalCache();
        //}

        //internal static void removeGoal(Goal dGoal)
        //{
        //    con.Delete(dGoal);
        //    Cache.refreshGoalCache();
        //}

        //otp Operations
        //internal static void addOTP(OneTime aOTP)
        //{
        //    con.Insert(aOTP);
        //    Cache.refreshOtpCache();
        //}

        //internal static void updateOTP(OneTime uOTP)
        //{
        //    con.Update(uOTP);
        //    Cache.refreshOtpCache();
        //}

        //internal static void removeOTP(OneTime dOTP)
        //{
        //    con.Delete(dOTP);
        //    Cache.refreshOtpCache();
        //}

        //general db statements
        //internal static void importRecords(List<Bill> billList)
        //{
        //    foreach (Bill item in billList)
        //    {
        //        con.Insert(item);
        //    }
        //}

        //internal static void setVersion(version ver)
        //{
        //    con.Update(ver);
            
        //}

        //internal static string executeCmd(string cmd)
        //{
        //    var result = con.Execute(cmd);
        //    return result.ToString();
        //}



        //DB Maintenance area

        //public static void checkTable()
        //{
        //    var vercheck = getVersionTable();
        //    vercheck = getVersionTable();

        //    try
        //    {
        //        getAcctTable();
        //    }
        //    catch (Exception)
        //    {
        //        string cCmd = "CREATE TABLE 'Account' ('accountID' INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, 'acctName' TEXT NOT NULL, " +
        //            "'acctBal' REAL, 'creditLimit' REAL, 'mnthPayAmnt' REAL NOT NULL, 'APR' REAL NOT NULL, 'acctType' TEXT NOT NULL, " +
        //            "'billID' INTEGER NOT NULL, 'startBal' REAL NOT NULL, 'startDate' TEXT NOT NULL, " +
        //            "FOREIGN KEY('BillID') REFERENCES 'Bill'('BillID') ON DELETE NO ACTION ON UPDATE NO ACTION); ";
        //        executeCmd(cCmd);
        //    }
        //    try
        //    {
        //        var temp = getVersionTable();
        //    }
        //    catch (Exception)
        //    {
        //        string cCmd = "CREATE TABLE 'version' ('verID' INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, 'ver' TEXT NOT NULL);";
        //        executeCmd(cCmd);
        //        executeCmd("INSERT INTO 'version' ('ver') VALUES ('1.0');");

        //    }

        //    if (vercheck[0].ver == "1.0")
        //    {
        //        string cCmd = "CREATE TABLE 'Trans' ('ID' INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, 'entryAmount' REAL NOT NULL, 'intrestAmount' REAL, " +
        //                "'entryDate' TEXT NOT NULL, 'Desc' TEXT, 'isInterest' TEXT NOT NULL,  'accountID' INTEGER NOT NULL, 'paymentID' INTEGER," +
        //                    "FOREIGN KEY('accountID') REFERENCES 'Account'('accountID') ON DELETE NO ACTION ON UPDATE NO ACTION); ";
        //        executeCmd(cCmd);
        //        executeCmd("UPDATE 'version' SET 'ver' = '1.1';");
        //    }


        //    if (vercheck[0].ver == "1.1")
        //    {
        //        try
        //        {
        //            Account test = new Account() { acctBal = 1000, acctName = "test", acctType = acctType.Credit, APR = 9.99, mnthPayAmnt = 100, creditLimit = 1000, startDate = DateTime.Now };
        //            addAcct(test);
        //            deleteAcct(test);
        //            executeCmd("UPDATE 'version' SET 'ver' = '1.2';");
        //        }
        //        catch (Exception)
        //        {
        //            string dCmd = "DROP TABLE 'Account';";
        //            string cCmd = "CREATE TABLE 'Account' ('accountID' INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, 'acctName' TEXT NOT NULL, " +
        //            "'acctBal' REAL, 'creditLimit' REAL, 'mnthPayAmnt' REAL NOT NULL, 'APR' REAL NOT NULL, 'acctType' TEXT NOT NULL, " +
        //            "'billID' INTEGER NOT NULL, 'startBal' REAL NOT NULL, 'startDate' TEXT NOT NULL, " +
        //            "FOREIGN KEY('BillID') REFERENCES 'Bill'('BillID') ON DELETE NO ACTION ON UPDATE NO ACTION); ";
        //            executeCmd(dCmd);
        //            executeCmd(cCmd);
        //            executeCmd("UPDATE 'version' SET 'ver' = '1.2';");
        //        }
        //    }

        //    if (vercheck[0].ver == "1.2")
        //    {
        //        string cCmd = "CREATE TABLE 'Goal' ('ID' INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, 'goalName' TEXT NOT NULL, 'goalAmount' REAL NOT NULL, 'currentAmount' REAL NOT NULL, 'goalDate' TEXT NOT NULL, 'isComplete' TEXT NOT NULL);";
        //        executeCmd(cCmd);
        //        executeCmd("UPDATE 'version' SET 'ver' = '1.3';");
        //    }

        //    if (vercheck[0].ver == "1.3")
        //    {
        //        string cCmd = "ALTER TABLE 'Account' ADD 'closed' INTEGER";
        //        executeCmd(cCmd);
        //        executeCmd("UPDATE 'version' SET 'ver' = '1.4';");
        //    }

        //    if (vercheck[0].ver == "1.4")
        //    {
        //        string cCmd = "CREATE TABLE 'oneTime' ('otpID' INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, 'Name' TEXT NOT NULL, 'PayAmount' REAL NOT NULL, 'DueDate' TEXT NOT NULL, 'Paid' INTEGER NOT NULL, 'Type' TEXT NOT NULL);";
        //        executeCmd(cCmd);                
        //        executeCmd("UPDATE 'version' SET 'ver' = '1.5';");
        //    }

        //    Cache.refreshAllCache();
        //}

    //}
}
