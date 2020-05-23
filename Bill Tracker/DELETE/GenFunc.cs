using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Bill_Tracker.Dialog;
using System.Globalization;


namespace Bill_Tracker.Models
{
    //class GenFunc
    //{                
    //    // Converted
    //    //internal static string formatDec(string format)
    //    //{            
    //    //    if (format.Contains(".") == false)
    //    //    {
    //    //        format += ".00";
    //    //    }
    //    //    return string.Format("{0:F2}", format);
    //    //}
    //    // Converted.
    //    internal static string formatCurrency(double currency)
    //    {
    //        //return string.Format("{0:C}", currency);
    //        return string.Format(CultureInfo.CurrentCulture, "{0:C}", currency);
    //        //CultureInfo.CreateSpecificCulture("en-GB")
    //    }
    //    //converted
    //    internal static string formatDate(DateTime date)
    //    {
    //        return date.ToString("dd MMM yyyy");
    //    }
    //    // UNUSED? //
    //    //internal static DateTime formatDate(string date)
    //    //{
    //    //    DateTime returndate = new DateTime();
    //    //    DateTime.TryParse(date.Split()[0], out returndate);
    //    //    return returndate;
    //    //}
    //    //converted
    //    internal static string formatCurrencyEntry(string content)
    //    {
    //        //string value = content.TrimStart('$');
    //        string value = content;
    //        string output = value;

    //        foreach (char digit in value)
    //        {
    //            if (!char.IsDigit(digit))
    //                if (!char.IsPunctuation(digit))
    //                {
    //                    var pos = value.IndexOf(digit);
    //                    value = value.Remove(value.IndexOf(digit));
    //                    output = value;
    //                }

    //            if (digit.Equals('-'))
    //            {
    //                value = value.Remove(value.IndexOf(digit));
    //                output = value;
    //            }

    //        }

    //        if (value.Contains("."))
    //        {
    //            int pPos = value.IndexOf(".");
    //            string main = value.Substring(0, pPos);
    //            string dec = value.Substring(pPos + 1);

    //            if (dec.Contains("."))
    //            {
    //                dec = dec.Remove(dec.IndexOf("."), 1);
    //            }

    //            if (dec.Length > 2)
    //            {
    //                dec = dec.Substring(0, 2);
    //            }

    //            string amnt = main + "." + dec;
    //            output = amnt;
    //        }

    //        //return output.Insert(0, "$");
    //        return output;
    //    }
    //    //converted
    //    internal static string formatNumberEntry(string content)
    //    {
    //        string value = content;
    //        string output = value;

    //        foreach (char digit in value)
    //        {
    //            if (!char.IsDigit(digit))
    //                if (digit != '.')
    //                {
    //                    var pos = value.IndexOf(digit);
    //                    value = value.Remove(pos);
    //                    output = value;
    //                }
    //        }

    //        if (value.Contains("."))
    //        {
    //            int pPos = value.IndexOf(".");
    //            string main = value.Substring(0, pPos);
    //            string dec = value.Substring(pPos + 1);

    //            if (dec.Contains("."))
    //            {
    //                dec = dec.Remove(dec.IndexOf("."), 1);
    //            }

    //            string amnt = main + "." + dec;
    //            output = amnt;
    //        }
    //        return output;
    //    }
    //    //converted
    //    internal static double extractCurrencyVal(string val)
    //    {
    //        // double converted = 0;
    //        // if (val.Contains("(") == true)
    //        // {
    //        //     converted = 
    //        return double.Parse(val, NumberStyles.Currency, CultureInfo.CurrentCulture);                
    //        //}else
    //       // {
    //       //     converted = double.Parse(val.TrimStart('$'));
    //       // }
    //       // return converted;
    //    }
    //    //converted
    //    internal static double formatEntryToNumber(string val)
    //    {
    //        return double.Parse(string.Concat(val?.Where(c => char.IsNumber(c) || c == '.') ?? ""));
    //    }


        //UI Functions
        //public class UI
        //{

        //    internal static void pointerEnter(object sender, PointerRoutedEventArgs e)
        //    {
        //        if (e.Pointer.PointerDeviceType != Windows.Devices.Input.PointerDeviceType.Touch)
        //        {

        //            Grid item = sender as Grid;
        //            if (item.DataContext is Bill)
        //            {
        //                if ((item.DataContext as Bill).Frequency == "OneTime")
        //                {

        //                } else
        //                {
        //                    foreach (var child in item.Children)
        //                    {
        //                        if (child is RelativePanel)
        //                        {
        //                            if ((child as RelativePanel).Name == "bttnPanel")
        //                            {
        //                                child.Visibility = Visibility.Visible;
        //                            }
        //                        }
        //                    }
        //                }

        //            }
        //            else
        //            {
        //                foreach (var child in item.Children)
        //                {
        //                    if (child is RelativePanel)
        //                    {
        //                        if ((child as RelativePanel).Name == "bttnPanel")
        //                        {
        //                            child.Visibility = Visibility.Visible;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    internal static void pointerExit(object sender, PointerRoutedEventArgs e)
        //    {
        //        Grid item = sender as Grid;
        //        foreach (var child in item.Children)
        //        {
        //            if (child is RelativePanel)
        //            {
        //                if ((child as RelativePanel).Name == "bttnPanel")
        //                {
        //                    child.Visibility = Visibility.Collapsed;
        //                }
        //            }
        //        }
        //    }


        //public class Help
        //{
        //    static int taps { get; set; }
        //    internal static async void swipe(object sender, TappedRoutedEventArgs e)
        //    {
        //        if (e.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Touch)
        //        {
        //            taps++;
        //            if (taps == 3)
        //            {
        //                if (LocalIO.getSetting("swipeHelp") == null)
        //                {
        //                    help_swipe help = new help_swipe();
        //                    await help.ShowAsync();
        //                    LocalIO.setSetting("swipeHelp", "true");
        //                }
        //            }
        //        }
        //    }

        //    internal static void showHelp(Frame mainframe)
        //    {
        //        mainframe.Navigate(typeof(Pages.Help));
        //    }
        //}
        //}

    //} 
}
