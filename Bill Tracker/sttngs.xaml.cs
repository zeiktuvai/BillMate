using BillMate.Services.ViewModel.CloudProviders;
using BillMate.Services.ViewModel.Configuration;
using BillMate.Services.ViewModel.Providers;
using Microsoft.Toolkit.Services.OneDrive;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Bill_Tracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class sttngs : Page
    {
        internal VersionDataProvider VP { get; set; }
        public sttngs()
        {
            this.InitializeComponent();
            VP = new VersionDataProvider();
            Package pack = Package.Current;
            PackageId packId = pack.Id;
            PackageVersion pver = packId.Version;

            lblVer.Text = "Version " + string.Format("{0}.{1}.{2}.{3}", pver.Major, pver.Minor, pver.Build, pver.Revision);
            if (ConfigurationManager.GetLocalSetting("loginEnbld").ToString().ToLower() == "true")
            {
                tgglLogin.IsOn = true;
            }
            if (ConfigurationManager.GetLocalSetting("AutoBkup") != null && ConfigurationManager.GetLocalSetting("AutoBkup").ToString() == "True")
            {
                tgglAutoDB.IsOn = true;
            }
            tgglLogin.Toggled += tgglLogin_Toggled;
            lblDBVer.Text = "DB Version " + VP.GetVersion();

            if (ConfigurationManager.CheckLocalSetting("EnableAcct")) {             
                tgglAccts.IsOn = (ConfigurationManager.GetLocalSetting("EnableAcct").ToString() == "Visibility.Visible") ? true : false; 
            
            };

            var loginInfo = ConfigurationManager.GetLocalSetting("MSLogin");

            if (loginInfo != null  && loginInfo.ToString()  == "True")
            {
                bttnLogin.Content = "Sign out";
                bttnSttngExportODS.IsEnabled = true;
                bttnSttngImportODS.IsEnabled = true;
                tgglAutoDB.IsEnabled = true;
                getUser();
                getDBdate();
            } else
            {
                bttnSttngExportODS.IsEnabled = false;
                bttnSttngImportODS.IsEnabled = false;
                tgglAutoDB.IsEnabled = false;
                bttnLogin.Content = "Log in";
            }
        }

        internal static string hash(string input)
        {
            var alg = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
            IBuffer buff = CryptographicBuffer.ConvertStringToBinary(input, BinaryStringEncoding.Utf8);
            var hashed = alg.HashData(buff);
            return CryptographicBuffer.EncodeToHexString(hashed);

        }

        private async void bttnSttngImprt_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Windows.UI.Popups.MessageDialog(string.Format("This action will over write the existing data with data from the selected database.  "), "Replace Database?");
            dialog.Options = Windows.UI.Popups.MessageDialogOptions.AcceptUserInputAfterDelay;
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Yes") { Id = 1 });
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("No") { Id = 0 });
            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 0;

            var action = await dialog.ShowAsync();
           
            if (action.Id.ToString() == "1")
            {
                StorageFile file = await SelectFile(false, PickerLocationId.Downloads, Tuple.Create("SQLite Database", ".db3"));
                if (file != null)
                {
                    Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Wait, 0);
                    SQLiteRawDataProvider RDP = new SQLiteRawDataProvider();
                    RDP.ImportSQLiteDB(file);
                }                
            }
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 0);
        }

        private async void bttnSttngExprt_Click(object sender, RoutedEventArgs e)
        {
            StorageFile file = await SelectFile(true, PickerLocationId.DocumentsLibrary, Tuple.Create("SQLite Database", ".db3"), "bills.db3");

            if (file != null)
            {
                FileSystemProvider FSP = new FileSystemProvider();
                FSP.SQLiteSaveToFile(file);
            }
        }

        private void tgglLogin_Toggled(object sender, RoutedEventArgs e)
        {
            ConfigurationManager.SetLocalSetting("loginEnbld", tgglLogin.IsOn.ToString());
            if (tgglLogin.IsOn == true)
            {
                setPassword();
            }
        }

        private async void setPassword()
        {
            Dialog.Password dialog = new Dialog.Password();
            await dialog.ShowAsync();
            string pass = dialog.result;
            if (pass != null)
            {
                ConfigurationManager.SetLocalSetting("usrPasswrd", hash(pass));
            }
            else
            {
                tgglLogin.IsOn = false;
            }
        }

        private async void BttnLogin_Click(object sender, RoutedEventArgs e)
        {
            var login = ConfigurationManager.GetLocalSetting("MSLogin");
            

            if (login == null || login.ToString() == "False")
            {

                try
                {
                    await OneDriveService.Instance.LoginAsync();
                    ConfigurationManager.SetLocalSetting("MSLogin", "True");
                    bttnLogin.Content = "Sign out";
                    this.Frame.Navigate(typeof(sttngs));
                }
                catch (Exception)
                {
                    var dialog = new Windows.UI.Popups.MessageDialog(string.Format("Failed to log in with this account."), "Login Failed");
                    var action = await dialog.ShowAsync();
                }

                
            }
            else if (login.ToString() == "True")
            {
                var dialog = new Windows.UI.Popups.MessageDialog(string.Format("Log out of one drive?  "), "Logout?");
                dialog.Options = Windows.UI.Popups.MessageDialogOptions.AcceptUserInputAfterDelay;
                dialog.Commands.Add(new Windows.UI.Popups.UICommand("Yes") { Id = 1 });
                dialog.Commands.Add(new Windows.UI.Popups.UICommand("No") { Id = 0 });
                dialog.DefaultCommandIndex = 0;
                dialog.CancelCommandIndex = 0;

                var action = await dialog.ShowAsync();

                if (action.Id.ToString() == "1")
                {
                    if (MicrosoftGraphProvider.disconnectODS().Result == true)
                    {
                        bttnLogin.Content = "Log in";
                    } else
                    {
                        var dialog2 = new Windows.UI.Popups.MessageDialog(string.Format("Failed to log out of this account."), "Logout Failed?");
                        var action2 = await dialog2.ShowAsync();
                    }
                }
            }
        }

        private async void getUser()
        {
            var userInfo = await MicrosoftGraphProvider.getODSuser();
            lblUser.Text = "Logged in as: " + ConfigurationManager.GetLocalSetting("UserEmail");
            lblUser.Visibility = Visibility.Visible;
        }

        private async void getDBdate()
        {
            var folder = await OneDriveService.Instance.AppRootFolderAsync();
            var ODSItems = await folder.GetFileAsync("bills.db3");
            if (ODSItems != null)
            {
                var bdate = ODSItems.DateModified.ToString();
                lblLbkup.Text = "Last Backup: " +  bdate.Substring(0, bdate.IndexOf(' '));
            }
            else if (NetworkInterface.GetIsNetworkAvailable())
            {
                lblLbkup.Text = "Last Backup: Unable to retrieve - Offline";
            }
            else
            {
                lblLbkup.Text = "Last Backup: None";
            }
        }

        private async void BttnSttngExportODS_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Extract
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                var okdialog = new Windows.UI.Popups.MessageDialog(string.Format("This action will overwrite the existing data stored in OneDrive."), "Upload to OneDrive?");
                okdialog.Options = Windows.UI.Popups.MessageDialogOptions.AcceptUserInputAfterDelay;
                okdialog.Commands.Add(new Windows.UI.Popups.UICommand("Yes") { Id = 1 });
                okdialog.Commands.Add(new Windows.UI.Popups.UICommand("No") { Id = 0 });
                okdialog.DefaultCommandIndex = 0;
                okdialog.CancelCommandIndex = 0;

                var action = await okdialog.ShowAsync();

                if (action.Id.ToString() == "1")
                {

                    Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Wait, 1);
                    var folder = await OneDriveService.Instance.AppRootFolderAsync();

                    try
                    {
                        StorageFile expfile = await ApplicationData.Current.LocalFolder.GetFileAsync("bills.db3");
                        using (var localStream = await expfile.OpenReadAsync())
                        {
                            var fileCreated = await folder.StorageFolderPlatformService.CreateFileAsync(expfile.Name, CreationCollisionOption.ReplaceExisting, localStream);
                        }
                        var dialog = new Windows.UI.Popups.MessageDialog("Upload to OneDrive successfully completed.", "Complete");
                        dialog.Options = Windows.UI.Popups.MessageDialogOptions.None;
                        await dialog.ShowAsync();
                    }
                    catch (Exception)
                    {
                        var dialog = new Windows.UI.Popups.MessageDialog("An error occured exporting the file.", "Error");
                        dialog.Options = Windows.UI.Popups.MessageDialogOptions.None;
                        await dialog.ShowAsync();
                    }
                    Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
                    this.Frame.Navigate(typeof(sttngs));
                }
                else
                {
                    Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
                    var dialog = new Windows.UI.Popups.MessageDialog("Error, please check network connection.", "No Network");
                    dialog.Options = Windows.UI.Popups.MessageDialogOptions.None;
                    await dialog.ShowAsync();
                }
            }
        }

        private async void BttnSttngImportODS_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Extract
            //if (NetworkInterface.GetIsNetworkAvailable())
            //{
            //    var dialog = new Windows.UI.Popups.MessageDialog(string.Format("This action will over write the existing data with data stored in OneDrive."), "Replace Database?");
            //    dialog.Options = Windows.UI.Popups.MessageDialogOptions.AcceptUserInputAfterDelay;
            //    dialog.Commands.Add(new Windows.UI.Popups.UICommand("Yes") { Id = 1 });
            //    dialog.Commands.Add(new Windows.UI.Popups.UICommand("No") { Id = 0 });
            //    dialog.DefaultCommandIndex = 0;
            //    dialog.CancelCommandIndex = 0;

            //    var action = await dialog.ShowAsync();

            //    if (action.Id.ToString() == "1")
            //    {

            //        Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Wait, 1);
            //        var folder = await OneDriveService.Instance.AppRootFolderAsync();
            //        var ODSItems = await folder.GetFileAsync("bills.db3");

            //        if (ODSItems != null)
            //        {
            //            OneDriveStorageFile odsFile = ODSItems;
            //            var localFolder = ApplicationData.Current.LocalFolder;
            //            var mylocalfile = await localFolder.CreateFileAsync("ods.db3", CreationCollisionOption.ReplaceExisting);

            //            using (var remoteStream = (await odsFile.StorageFilePlatformService.OpenAsync()) as IRandomAccessStream)
            //            {
            //                byte[] buffer = new byte[remoteStream.Size];
            //                var localBuffer = await remoteStream.ReadAsync(buffer.AsBuffer(), (uint)remoteStream.Size, InputStreamOptions.ReadAhead);

            //                using (var localStream = await mylocalfile.OpenAsync(FileAccessMode.ReadWrite))
            //                {
            //                    await localStream.WriteAsync(localBuffer);
            //                    await localStream.FlushAsync();
            //                }
            //            }

            //            var result = await importDB(mylocalfile);
            //            await mylocalfile.DeleteAsync();

            //            if (result == true)
            //            {
            //                var sdialog = new Windows.UI.Popups.MessageDialog("Import operation completed successfully.", "Import Complete");
            //                await sdialog.ShowAsync();
            //                this.Frame.Navigate(typeof(billList));
            //            }
            //            else
            //            {
            //                var errdialog = new Windows.UI.Popups.MessageDialog("An error occured importing the file. Data may have been lost.", "Error");
            //                await errdialog.ShowAsync();
            //            }
            //            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
            //        }
            //    }
            //} else
            //{
            //    Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
            //    var dialog = new Windows.UI.Popups.MessageDialog("Error, please check network connection.", "No Network");
            //    dialog.Options = Windows.UI.Popups.MessageDialogOptions.None;
            //    await dialog.ShowAsync();
            //}
        }

        //private async Task<bool> importDB(Windows.Storage.StorageFile file)
        //{
        //    //TODO: Extract
        //    try
        //    {
        //        Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Wait, 0);
        //        //open connection to file                       
        //        await file.CopyAsync(ApplicationData.Current.LocalFolder, "tempdb.db3", NameCollisionOption.ReplaceExisting);
        //        StorageFile tempdb = await ApplicationData.Current.LocalFolder.GetFileAsync("tempdb.db3");
        //        SQLiteConnection tempCon = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), tempdb.Path);

        //        //get db version
        //        List<version> tempVer = tempCon.Table<version>().ToList();

        //        //import each table as list
        //        List<Bill> tempBills = tempCon.Table<Bill>().ToList();
        //        List<Payment> tempPay = tempCon.Table<Payment>().ToList();
        //        List<Account> tempAcct = tempCon.Table<Account>().ToList();
        //        List<Trans> tempTrans = tempCon.Table<Trans>().ToList();
        //        List<Goal> tempGoal = tempCon.Table<Goal>().ToList();
        //        List<OneTime> tempOTP = tempCon.Table<OneTime>().ToList();

        //        if (tempVer[0].ver == "1.5")
        //        {
        //            tempOTP = tempCon.Table<OneTime>().ToList();
        //        }


        //        //drop all tables
        //        StorageFile origdb = await ApplicationData.Current.LocalFolder.GetFileAsync("bills.db3");
        //        LocalIO.closeDB();
        //        await origdb.DeleteAsync();
        //        StorageFile stopfile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///bills.db3"));
        //        await stopfile.CopyAsync(ApplicationData.Current.LocalFolder);
        //        LocalIO.openDB();
        //        LocalIO.checkTable();


        //        //add each item to new db
        //        foreach (Bill bll in tempBills)
        //        {
        //            //LocalIO.createBill(bll);
        //            string sqlcmd = string.Format("INSERT INTO 'Bill' VALUES ({0},'{1}','{2}','{3}',{4},'{5}','{6}');", bll.BillID, bll.Name, bll.dispDueDate, bll.Frequency, bll.baseAmount, bll.Category, bll.Reminder);
        //            LocalIO.executeCmd(sqlcmd);
        //        }

        //        foreach (Payment pymnt in tempPay)
        //        {
        //            //LocalIO.createPayment(pymnt);
        //            string sqlcmd = string.Format("INSERT INTO 'Payment' VALUES ({0},'{1}',{2},'{3}',{4});", pymnt.paymentID, pymnt.dispPayDate, pymnt.amount, pymnt.posted, pymnt.BillID);
        //            LocalIO.executeCmd(sqlcmd);
        //        }

        //        foreach (Account acct in tempAcct)
        //        {
        //            //LocalIO.addAcct(acct);
        //            string sqlcmd = string.Format("INSERT INTO 'Account' VALUES ({0},'{1}',{2},{3},{4},{5},'{6}',{7},{8},'{9}',{10});", acct.accountID, acct.acctName, acct.acctBal, acct.creditLimit, acct.mnthPayAmnt, acct.APR, acct.acctType, acct.billID, acct.startBal, acct.startDate, acct.closed);
        //            LocalIO.executeCmd(sqlcmd);
        //        }

        //        foreach (Trans trns in tempTrans)
        //        {
        //            //LocalIO.addTransaction(trns);
        //            string sqlcmd = string.Format("INSERT INTO 'Trans' VALUES ({0},{1},{2},'{3}','{4}','{5}',{6},{7});", trns.ID, trns.entryAmount, trns.intrestAmount, trns.entryDate, trns.Desc, trns.isInterest, trns.accountID, trns.paymentID);
        //            LocalIO.executeCmd(sqlcmd);
        //        }

        //        foreach (Goal gal in tempGoal)
        //        {
        //            //LocalIO.addGoal(gal);
        //            string sqlcmd = string.Format("INSERT INTO 'Goal' VALUES ({0},'{1}',{2},{3},'{4}','{5}');", gal.ID, gal.goalName, gal.goalAmount, gal.currentAmount, gal.goalDate, gal.isComplete);
        //            LocalIO.executeCmd(sqlcmd);
        //        }

        //        if (tempOTP != null)
        //        {
        //            foreach (OneTime otp in tempOTP)
        //            {
        //                string sqlcmd = string.Format("INSERT INTO 'oneTime' VALUES ({0}, '{1}', {2}, '{3}', {4}, '{5}');", otp.otpID, otp.Name, otp.PayAmount, otp.DueDate, otp.Paid, otp.Type);
        //                LocalIO.executeCmd(sqlcmd);
        //            }
        //        }


        //        //cleanup
        //        tempCon.Close();
        //        await tempdb.DeleteAsync();
        //        Cache.refreshAllCache();
        //        Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 0);
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        private void TgglAutoDB_Toggled(object sender, RoutedEventArgs e)
        {
            if (tgglAutoDB.IsOn)
            {
                ConfigurationManager.SetLocalSetting("AutoBkup", "True");

            } else
            {
                ConfigurationManager.SetLocalSetting("AutoBkup", "False");
            }
        }

        private void tgglAccts_Toggled(object sender, RoutedEventArgs e)
        {
            ConfigurationManager.SetLocalSetting("EnableAcct", (tgglAccts.IsOn) ? "Visibility.Visible" : "Visibility.Collapsed");
            MainPage main = (Window.Current.Content as Frame).Content as MainPage;
            main.setAcctPageVis((ConfigurationManager.GetLocalSetting("EnableAcct").ToString() == "Visibility.Visible") ? true : false);
        }

        internal async Task<StorageFile> SelectFile(bool isSave, PickerLocationId pickerLocationId, Tuple<string, string> FileTypeChoice, string SuggestedFileName = "")
        {
            if (isSave == false)
            {
                var picker = new FileOpenPicker();
                picker.ViewMode = PickerViewMode.Thumbnail;
                picker.SuggestedStartLocation = pickerLocationId;
                picker.FileTypeFilter.Add(".db3");
                return await picker.PickSingleFileAsync();
            }
            else
            {
                var picker = new FileSavePicker();
                picker.SuggestedFileName = SuggestedFileName;
                picker.SuggestedStartLocation = pickerLocationId;
                picker.FileTypeChoices.Add(FileTypeChoice.Item1, new List<string>() { FileTypeChoice.Item2 });
                return await picker.PickSaveFileAsync();
            }
        }
    }
}