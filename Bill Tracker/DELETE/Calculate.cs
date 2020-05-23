using System;
using Bill_Tracker.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_Tracker.Models
{
    //namespace Calculate
    //{
    //    class Finance
    //    {
    //        /// <summary>
    //        /// Takes an APR in standard notation (e.x. 1.99) and converts it to calculateable value (.0199).
    //        /// </summary>
    //        /// <param name="APR"></param>
    //        /// <returns></returns>
    //        //public static double convertAPR(double APR)
    //        //{
    //        //    double apr;
    //        //    if (APR > 100)
    //        //    {
    //        //        apr = 100 / 100;
    //        //    }
    //        //    else if (APR <= 0)
    //        //    {
    //        //        apr = .01;
    //        //    }
    //        //    else
    //        //    {
    //        //        apr = APR / 100;
    //        //    }
    //        //    return apr;
    //        //}

    //        /// <summary>
    //        /// Takes the APR, Balance and Monthly payment of a credit card and calculates the number of months to pay it off.
    //        /// </summary>
    //        /// <param name="APR"></param>
    //        /// <param name="balance"></param>
    //        /// <param name="mPayment"></param>
    //        /// <returns></returns>
    //        //public static double creditPayoffMo(double APR, double balance, double mPayment)
    //        //{
    //        //    double apr = convertAPR(APR);

    //        //    double calculation = (Math.Log((1 + (balance / mPayment) * (1 - (Math.Pow(1 + (apr / 365), 30)))))) / (Math.Log((1 + (apr / 365))));
    //        //    double months = (-0.033333333333333333) * calculation;
                
    //        //    return months;
    //        //}

    //        /// <summary>
    //        /// Takes a loan APR, Balance and monthly payment and calculates the number in months untill paid off.
    //        /// </summary>
    //        /// <param name="APR"></param>
    //        /// <param name="balance"></param>
    //        /// <param name="mPayment"></param>
    //        /// <returns></returns>
    //        //public static double loanPayoffMo(double APR, double balance, double mPayment)
    //        //{
    //        //    return -(Math.Log(1 - (balance / mPayment) * (APR / 12)) / Math.Log(1 + (APR / 12)));
    //        //}

    //        ///// <summary>
    //        ///// Takes a loan APR, Balance and monthly payment and calculates the number in months untill paid off with an extra payment.
    //        ///// </summary>
    //        ///// <param name="APR"></param>
    //        ///// <param name="balance"></param>
    //        ///// <param name="mPayment"></param>
    //        ///// <param name="extraPayment"></param>
    //        ///// <returns></returns>
    //        //public static double loanPayoffMo(double APR, double balance, double mPayment, double extraPayment)
    //        //{
    //        //    double newBalance = balance - extraPayment;
    //        //    return -(Math.Log(1 - (newBalance / mPayment) * (APR / 12)) / Math.Log(1 + (APR / 12)));
    //        //}
            
    //        ///// <summary>
    //        ///// Takes the APR and Current Balance of an account and calculates the interest accrued for one month.
    //        ///// </summary>
    //        ///// <param name="APR"></param>
    //        ///// <param name="balance"></param>
    //        ///// <returns></returns>
    //        public static double monthlyInterest (double APR, double balance)
    //        {
    //            double aprMo = convertAPR(APR) / 12;
    //            return balance * aprMo;
    //        }

    //        /// <summary>
    //        /// Takes the loan APR, Monthly Payment, and Balance and returns the principal paid on the loan for a monthly payment.
    //        /// </summary>
    //        /// <param name="APR"></param>
    //        /// <param name="balance"></param>
    //        /// <param name="payment"></param>
    //        /// <returns></returns>
    //        public static double loanPaymentPrincipal(double APR, double balance, double payment)
    //        {
    //            return Math.Truncate((payment - monthlyInterest(APR, balance)) * 100) / 100;
    //        }
    //    }

        //class General
        //{
        //    /// <summary>
        //    /// Takes two numbers and calculates the percent that one number is of the other.
        //    /// </summary>
        //    /// <param name="num1"></param>
        //    /// <param name="num2"></param>
        //    ///// <returns></returns>
        //    //public static double percentOfTwoNumbers (double num1, double num2)
        //    //{
        //    //    return (num1 / num2) * 100;
        //    //}

        //    ///// <summary>
        //    ///// Takes two numbers and calculates the percent difference between the two.
        //    ///// </summary>
        //    ///// <param name="num1"></param>
        //    ///// <param name="num2"></param>
        //    ///// <returns></returns>
        //    //public static double percentCompletion (double num1, double num2)
        //    //{
        //    //    return 100 - ((num1 / num2) * 100);
        //    //}
        //}
    //}
}
