using PasswordGenerator;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Globals
{
    public class Common
    {



        //shared folders
        public static string shared_folder_url = string.Empty;
        public static string db_connection_string = string.Empty;
        public static string webroot_path = string.Empty;
        public static string path_logs = string.Empty;
        public static string path_error_logs = string.Empty;
        public static string path_info_logs = string.Empty;
        public static string path_storage = string.Empty;


        public static string system_email = "zishumbak@gmail.com";
        public static string system_email_name = "Administrator";
        public static string system_email_password = "tqpbmwrxeavgcvff";
        public static string support_email = "adeyemi@gmail.com";
        public static string support_mobile = "+234 806 700 6917";

        public static string support_number = "+263 773 303 669";
        public static List<string> weekdays = new List<string> { "sunday", "monday", "tuesday", "wednesday", "thursday", "friday", "saturday" };
        public static List<string> months = new List<string> { "jan", "feb", "mar", "apr", "may", "jun", "jul", "aug", "sep", "oct", "nov", "dec" };
        public static string google_maps_key = "AIzaSyD28AepGY5iYf3pbh5b-KjmQBm0yNDrqFw";

        public static void Init(WebApplicationBuilder builder)
        {
            Globals.Common.db_connection_string = builder.Configuration.GetConnectionString("db");
            Globals.Common.shared_folder_url = builder.Configuration.GetValue<string>("shared_folder_url");
            Globals.Common.webroot_path = builder.Environment.WebRootPath;
            Globals.Common.path_logs = Path.Combine(shared_folder_url, "logs");
            Globals.Common.path_error_logs = Path.Combine(shared_folder_url, "logs", "error.txt");
            Globals.Common.path_info_logs = Path.Combine(shared_folder_url, "logs", "info.txt");
            Globals.Common.path_storage = Path.Combine(shared_folder_url, "storage");
        }


        public static async void LogError(string error)
        {
            System.IO.File.AppendAllText(path_error_logs, error + Environment.NewLine);
            await Task.CompletedTask;
        }
        public static async void LogInfo(string error)
        {
            System.IO.File.AppendAllText(path_info_logs, error + Environment.NewLine);
            await Task.CompletedTask;
        }
        public static string UCFirst(string str)
        {
            if (str == null)
                return null!;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }
        public static void SendEmail(string to, string subject, string message)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(Common.system_email, Common.system_email_name);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(Common.system_email, Common.system_email_password);
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(mail);
                }
            }
        }
        public static bool IsValidDomain(string domain)
        {
            try
            {
                MailAddress m = new MailAddress("a" + domain);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static bool IsValidEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static string GetPassword(int length = 8)
        {
            var password = new Password().IncludeNumeric().IncludeLowercase().IncludeUppercase().IncludeSpecial().LengthRequired(length);
            return password.Next();
        }
        public static string GetInitials(string full_name)
        {
            if (string.IsNullOrEmpty(full_name))
            {
                return "";
            }
            var initilas = "";
            var names = full_name.Split(" ");
            foreach (var name in names)
            {
                initilas += name.First() + ". ";
            }

            return initilas;
        }


        //tobacco
        public static double tobaccoGetMaxDifference(double? var_one, double? var_two)
        {
            var result = var_one - var_two;
            if (result > 0)
            {
                return (double)result;
            }
            else
            {
                return 0;
            }
        }

        public static double? tobaccoGetMaxDifferenceNullable(double? var_one, double? var_two)
        {
            if(var_one is null)
            {
                return null;
            }
            var result = var_one - var_two;
            if (result > 0)
            {
                return (double)result;
            }
            else
            {
                return 0;
            }
        }
    }
}


