using BillMate.Services.ViewModel.Configuration;
using Microsoft.Toolkit.Services.OneDrive;
using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Windows.Storage;

namespace BillMate.Services.ViewModel.CloudProviders
{
    public class MicrosoftGraphProvider
    {
        public static async Task<bool> connectODS()
        {
            if (ConfigurationManager.CheckLocalSetting("MSLogin"))
            {
                if (ConfigurationManager.GetLocalSetting("MSLogin").ToString() == "True")
                {
                    try
                    {
                        //TODO: update this to the new services
                        await OneDriveService.Instance.LoginAsync();
                        ConfigurationManager.SetLocalSetting("MSLogin", "True");
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static async Task<bool> disconnectODS()
        {
            if (ConfigurationManager.GetLocalSetting("MSLogin").ToString() == "True")
            {
                try
                {
                    await OneDriveService.Instance.LogoutAsync();
                    ConfigurationManager.SetLocalSetting("MSLogin", "False");
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }



        public static async Task<Microsoft.Graph.User> getODSuser()
        {
            if (OneDriveService.Instance.Provider.IsAuthenticated == true)
            {
                var userFields = new Microsoft.Toolkit.Services.MicrosoftGraph.MicrosoftGraphUserFields[] { Microsoft.Toolkit.Services.MicrosoftGraph.MicrosoftGraphUserFields.DisplayName };
                Microsoft.Graph.User user = await OneDriveService.Instance.Provider.User.GetProfileAsync(userFields);
                ConfigurationManager.SetLocalSetting("UserName", user.DisplayName);
                ConfigurationManager.SetLocalSetting("UserEmail", user.UserPrincipalName);
                return user;
            }
            else
            {
                return new Microsoft.Graph.User();
            }
        }

        public static async Task<bool> backupDBODS()
        {
            //TODO: update this so it takes an object instead of getting it from here.
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                var folder = await OneDriveService.Instance.AppRootFolderAsync();

                try
                {
                    StorageFile expfile = await ApplicationData.Current.LocalFolder.GetFileAsync("bills.db3");
                    using (var localStream = await expfile.OpenReadAsync())
                    {
                        var fileCreated = await folder.StorageFolderPlatformService.CreateFileAsync(expfile.Name, CreationCollisionOption.ReplaceExisting, localStream);
                    }
                    return true;
                }
                catch (Exception)
                {
                    return true;
                }
            }
            else
            {
                return true;
            }


        }
    }
}
