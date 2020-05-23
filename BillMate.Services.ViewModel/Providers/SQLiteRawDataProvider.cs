using BillMate.Services.Data.Factory;
using BillMate.Services.Data.Repository;
using BillMate.Services.ViewModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;

namespace BillMate.Services.ViewModel.Providers
{
    public class SQLiteRawDataProvider
    {
        internal SQLiteDatabaseOperation<object> SQLiteProvider { get; set; }

        public SQLiteRawDataProvider()
        {
            SQLiteProvider = new SQLiteDatabaseOperation<object>();
        }

        public void ExecuteSQLCommand(string command)
        {
            SQLiteProvider.ExecuteCmd(command);
        }

        public void ImportSQLiteDB(StorageFile file)
        {
            ImportDB(file);
        }


        internal async void ImportDB(StorageFile file)
        {
            try
            {
         //TODO: Finish implementing this.       
                //open connection to file                       
                await file.CopyAsync(ApplicationData.Current.LocalFolder, "tempdb.db3", NameCollisionOption.ReplaceExisting);
                string TempDBPath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "tempdb.db3");

                //get db version
                //List<version> tempVer = tempCon.Table<version>().ToList();
                List<version> tempVer = new SQLiteDatabaseOperation<version>(TempDBPath).GetTable(new version()).ToList();               

                //import each table as list
                //List<Bill> tempBills = tempCon.Table<Bill>().ToList();
                List<Bill> tempBills = new SQLiteDatabaseOperation<Bill>(TempDBPath).GetTable(new Bill()).ToList();
                //List<Payment> tempPay = tempCon.Table<Payment>().ToList();
                List<Payment> tempPay = new SQLiteDatabaseOperation<Payment>(TempDBPath).GetTable(new Payment()).ToList();
                //List<Goal> tempGoal = tempCon.Table<Goal>().ToList();
                List<Goal> tempGoal = new SQLiteDatabaseOperation<Goal>(TempDBPath).GetTable(new Goal()).ToList();
                //List<OneTime> tempOTP = tempCon.Table<OneTime>().ToList();
                List<OneTime> tempOTP = new SQLiteDatabaseOperation<OneTime>(TempDBPath).GetTable(new OneTime()).ToList();

                if (tempVer[0].ver == "1.5")
                {
                    tempOTP = new SQLiteDatabaseOperation<OneTime>(TempDBPath).GetTable(new OneTime()).ToList();
                }


                //drop all tables
                //StorageFile origdb = await ApplicationData.Current.LocalFolder.GetFileAsync("bills.db3");                
               //await origdb.DeleteAsync();
                //StorageFile stopfile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///bills.db3"));
                //await stopfile.CopyAsync(ApplicationData.Current.LocalFolder);
                //TODO: Implement the new create DB code.
                //CreateSQLiteDatabase();


                //add each item to new db
                //foreach (Bill bll in tempBills)
                //{
                //    //LocalIO.createBill(bll);
                //    string sqlcmd = string.Format("INSERT INTO 'Bill' VALUES ({0},'{1}','{2}','{3}',{4},'{5}','{6}');", bll.BillID, bll.Name, bll.dispDueDate, bll.Frequency, bll.baseAmount, bll.Category, bll.Reminder);
                //    LocalIO.executeCmd(sqlcmd);
                //}

                //foreach (Payment pymnt in tempPay)
                //{
                //    //LocalIO.createPayment(pymnt);
                //    string sqlcmd = string.Format("INSERT INTO 'Payment' VALUES ({0},'{1}',{2},'{3}',{4});", pymnt.paymentID, pymnt.dispPayDate, pymnt.amount, pymnt.posted, pymnt.BillID);
                //    LocalIO.executeCmd(sqlcmd);
                //}

                //foreach (Account acct in tempAcct)
                //{
                //    //LocalIO.addAcct(acct);
                //    string sqlcmd = string.Format("INSERT INTO 'Account' VALUES ({0},'{1}',{2},{3},{4},{5},'{6}',{7},{8},'{9}',{10});", acct.accountID, acct.acctName, acct.acctBal, acct.creditLimit, acct.mnthPayAmnt, acct.APR, acct.acctType, acct.billID, acct.startBal, acct.startDate, acct.closed);
                //    LocalIO.executeCmd(sqlcmd);
                //}

                //foreach (Trans trns in tempTrans)
                //{
                //    //LocalIO.addTransaction(trns);
                //    string sqlcmd = string.Format("INSERT INTO 'Trans' VALUES ({0},{1},{2},'{3}','{4}','{5}',{6},{7});", trns.ID, trns.entryAmount, trns.intrestAmount, trns.entryDate, trns.Desc, trns.isInterest, trns.accountID, trns.paymentID);
                //    LocalIO.executeCmd(sqlcmd);
                //}

                //foreach (Goal gal in tempGoal)
                //{
                //    //LocalIO.addGoal(gal);
                //    string sqlcmd = string.Format("INSERT INTO 'Goal' VALUES ({0},'{1}',{2},{3},'{4}','{5}');", gal.ID, gal.goalName, gal.goalAmount, gal.currentAmount, gal.goalDate, gal.isComplete);
                //    LocalIO.executeCmd(sqlcmd);
                //}

                //if (tempOTP != null)
                //{
                //    foreach (OneTime otp in tempOTP)
                //    {
                //        string sqlcmd = string.Format("INSERT INTO 'oneTime' VALUES ({0}, '{1}', {2}, '{3}', {4}, '{5}');", otp.otpID, otp.Name, otp.PayAmount, otp.DueDate, otp.Paid, otp.Type);
                //        LocalIO.executeCmd(sqlcmd);
                //    }
                //}


                //cleanup 
                //StorageFile tempdb = await ApplicationData.Current.LocalFolder.GetFileAsync("tempdb.db3");
                //await tempdb.DeleteAsync();






                //if (result == true)
                //{
                //    Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 0);
                //    var sdialog = new Windows.UI.Popups.MessageDialog("Import operation completed successfully.", "Import Complete");
                //    await sdialog.ShowAsync();
                //    this.Frame.Navigate(typeof(billList));
                //}
                //else
                //{
                //    Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 0);
                //    var errdialog = new Windows.UI.Popups.MessageDialog("An error occured importing the file. Data may have been lost.", "Error");
                //    await errdialog.ShowAsync();
                //}

            }
            catch (Exception)
            {

            }
        }

    }
}
