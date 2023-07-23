using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using UETV.Models;

namespace UETV.Controllers
{
    public class Bussiness_API_Config
    {
        public static DateTime minDOB = DateTime.Now.AddYears(-71);
        public static DateTime maxDOB = DateTime.Now.AddYears(-21);
        public static List<string> ValidGenders = new List<string>() {"male" , "female" , "others" };
        
        public static List<string> ValidIds = new List<string>() { "id card", "passport", "officer card" };
        public static DateTime MinDate = new DateTime(1900, 1, 1);
       public static  DateTime MaxDate = DateTime.Now.AddYears(-25);
        private static Random random = new Random();
        public static bool IsArabicText( string input)
        {
            return Regex.IsMatch(input, @"\p{IsArabic}");
        }
        public static string TranslateText(String word)
        
        {
            var toLanguage = "en";//English
            var fromLanguage = "ar";//Arabic
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(word)}";
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = webClient.DownloadString(url);
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return result.ToLower();
            }
            catch
            {
                return "Error";
            }
        }
        public static ValidationResult PromoValidFrom(object input)
        {
            var result = ValidationResult.Success;
            if (input != null)
            {
                DateTime InDate = Convert.ToDateTime(input);
                DateTime CurrentDate = DateTime.Now.Date;
                DateTime MaxDate = DateTime.Now.AddYears(1);
                if (InDate.Date < CurrentDate.Date || InDate.Date > MaxDate.Date)
                {
                    result = new ValidationResult("Invalid date input for validfrom value should be between (" + CurrentDate.ToString("MM/dd/yyyy HH:mm") + ") and (" + MaxDate.ToString("MM/dd/yyyy HH:mm") + ").");
                }
                return result;
            }
            return result;
        }
        public static ValidationResult PromoValidTo(object input)
        {
            var result = ValidationResult.Success;
            if (input != null)
            {
                DateTime InDate = Convert.ToDateTime(input);
                DateTime CurrentDate = DateTime.Now.AddDays(1).Date;
                DateTime MaxDate = DateTime.Now.AddYears(1);
                if (InDate.Date < CurrentDate.Date || InDate.Date > MaxDate.Date)
                {
                    result = new ValidationResult("Invalid date input for validto value should be between (" + CurrentDate.ToShortDateString() + ") and (" + MaxDate.ToShortDateString() + ").");
                }
                return result;
            }
            return result;
        }
        public static ValidationResult accountExpiresIn(object input)
        {
            var result = ValidationResult.Success;
            if (input != null)
            {
                DateTime InDate = Convert.ToDateTime(input);
                if (InDate < DateTime.Now) {
                    result = new ValidationResult("4007");
                }
                return result;
            }
            return result;
        }
        public static ValidationResult DOBFamilyMember(object input)
        {
            var result = ValidationResult.Success;
            DateTime MaximumDate =DateTime.Now.AddDays(-1);
            if (input != null)
            {
                DateTime InDate = Convert.ToDateTime(input);
                if (InDate < MinDate || InDate > MaximumDate)
                {
                    result = new ValidationResult("Invalid date input for dateOfBirth value should be between (" + MinDate.ToShortDateString() + ") and (" + MaximumDate.ToShortDateString() + ").");
                }
                return result;
            }
            return result;
        }
        public static ValidationResult AppoinmentDate(object input)
        {
            var result = ValidationResult.Success;
            if (input != null)
            {
                DateTime InDate = Convert.ToDateTime(input);
                DateTime CurrentDate = DateTime.Now;
                DateTime MaxDate = DateTime.Now.AddDays(14);
                if (InDate.Date < CurrentDate.Date || InDate.Date > MaxDate.Date)
                {
                    result = new ValidationResult("Invalid date input for appoinmentDate value should be between (" + CurrentDate.ToString("MM/dd/yyyy HH:mm") + ") and (" + MaxDate.ToString("MM/dd/yyyy HH:mm") + ").");
                }
                return result;
            }
            return result;
        }
        public static ValidationResult FilteredDate(object input)
        {
            var result = ValidationResult.Success;
            if (input != null)
            {
                DateTime InDate = Convert.ToDateTime(input);
                DateTime CurrentDate = DateTime.Now;
                DateTime MaxDate = DateTime.Now.AddDays(14);
                if (InDate.Date < CurrentDate.Date || InDate.Date > MaxDate.Date)
                {
                    result = new ValidationResult("Invalid date input for dayDate value should be between (" + CurrentDate.ToString("MM/dd/yyyy HH:mm") + ") and (" + MaxDate.ToString("MM/dd/yyyy HH:mm") + ").");
                }
                return result;
            }
            return result;
        }
        public static bool IsValidCancelAppoinment(TimeSpan AppoinmentStart)
        {
            bool IsValid = false;
            TimeSpan TimeNow = DateTime.Now.TimeOfDay;
            if(TimeNow >= AppoinmentStart)
            return IsValid;
            else
            {
                int remained = (AppoinmentStart - TimeNow).Hours;
                if (remained >= 2)
                    return true;
                else
                    return IsValid;
            }
            return IsValid;

        }
        public static ValidationResult StartedWorking(object input)
        {
            var result = ValidationResult.Success;
            DateTime MaxInDate = DateTime.Now.AddYears(-1);
            if (input != null)
            {
                DateTime InDate = Convert.ToDateTime(input);
                if (InDate < MinDate || InDate > MaxInDate)
                {
                    result = new ValidationResult("Invalid date input for StartedWorking value should be between (" + MinDate.ToShortDateString() + ") and (" + MaxInDate.ToShortDateString() + ").");
                }
                return result;
            }
            return result;
        }
        public static ValidationResult TodayOrTommorow(object input)
        {
            var result = ValidationResult.Success;
            DateTime TodayDate = DateTime.Now.Date;
            DateTime TommorowDate = DateTime.Now.AddDays(1).Date;
            if (input != null)
            {
                DateTime InDate = Convert.ToDateTime(input).Date;
                if (InDate != TodayDate && InDate != TommorowDate)
                {
                    result = new ValidationResult("Invalid date input for dayDate value should be equal (" + TodayDate.ToShortDateString() + ") or (" + TommorowDate.ToShortDateString() + ").");
                }
                return result;
            }
            return result;
        }
        public static ValidationResult ValidStatusId(object input)
        {
            var result = ValidationResult.Success;
            if (input != null)
            {
                int StatusId = Convert.ToInt32(input);
                if (StatusId!=2 && StatusId!=3)
                {
                    result = new ValidationResult("Invalid statusId input should be (2 for cancel) or (3 for approve).");
                }
                return result;
            }
            return result;
        }
        public static ValidationResult PatientValidStatusId(object input)
        {
            var result = ValidationResult.Success;
            if (input != null)
            {
                int StatusId = Convert.ToInt32(input);
                if (StatusId!=1 &&StatusId != 2 && StatusId != 3)
                {
                    result = new ValidationResult("Invalid statusId input should be (3 for cancel).");
                }
                return result;
            }
            return result;
        }
        public static ValidationResult PasswordValidation(object password)
        {
            var result = ValidationResult.Success;
            if ( password != null && !String.IsNullOrEmpty(password.ToString()))
            {
                if (String.IsNullOrEmpty(password.ToString()) || password.ToString().Length < 8)
                {
                    result = new ValidationResult("4002");
                }

                int counter = 0;
                List<string> patterns = new List<string>();
                patterns.Add(@"[a-z]"); // lowercase  
                patterns.Add(@"[A-Z]"); // uppercase  
                patterns.Add(@"[0-9]"); // digits  
                patterns.Add(@"[!@#$%^&*\(\)_\+\-\={}<>,\.\|""'~`:;\\?\/\[\] ]"); // special symbols

                // count type of different chars in password  
                foreach (string p in patterns)
                {
                    if (Regex.IsMatch(password.ToString(), p))
                    {
                        counter++;
                    }  
                }

                if (counter < 4)
                {
                    result = new ValidationResult("4003");
                }
            }
            return result;
        }
        public static APIStatus Get_API_Obj(string Lang, string Mark)
        {


        APIStatus Status = new APIStatus();
       
            if (!String.IsNullOrEmpty(Mark))
            {
                if (Mark.ToLower().Equals("select"))
                {
                    
                    Status.code =200;
                    if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("en"))
                        Status.message = "Data Successfully Fetched";
                    else if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("ar"))
                        Status.message = "تم استرجاع البيانات بنجاح";
                    else
                        Status.message = "Data Successfully Fetched";
                }
                else if (Mark.ToLower().Equals("post") )
                {
                    Status.code = 200;
                    if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("en"))
                        Status.message = "Data Successfully Posted";
                    else if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("ar"))
                        Status.message = "تم اضافة البيانات بنجاح";
                    else
                        Status.message = "Data Successfully Posted";
                }
                else if (Mark.ToLower().Equals("edit"))
                {
                    Status.code = 200;
                    if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("en"))
                        Status.message = "Data Successfully Edited";
                    else if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("ar"))
                        Status.message = "تم تعديل البيانات بنجاح";
                    else
                        Status.message = "Data Successfully Posted";
                }
                else if (Mark.ToLower().Equals("invalid_post"))
                {
                    Status.code = 300;
                    if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("en"))
                        Status.message = "Record Not Posted Error Connection";
                    else if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("ar"))
                        Status.message = "فشل في اضافة البيانات";
                    else
                        Status.message = "Record Not Posted Error Connection";
                }
                else if (Mark.ToLower().Equals("put"))
                {
                    Status.code = 200;
                    if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("en"))
                        Status.message = "Data Successfully Edited";
                    else if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("ar"))
                        Status.message = "تم تعديل البيانات بنجاح";
                    else
                        Status.message = "Data Successfully Edited";
                }
                    else if (Mark.ToLower().Equals("invalid_put"))
                {
                    Status.code = 700;
                    if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("en"))
                        Status.message = "Record Not Edited Error Connection";
                    else if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("ar"))
                        Status.message = "فشل في تعديل البيانات";
                    else
                        Status.message = "Record Not Edited Error Connection";
                }
                else if (Mark.ToLower().Equals("delete"))
                {
                    Status.code = 200;
                    if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("en"))
                        Status.message = "Data Successfully Deleted";
                    else if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("ar"))
                        Status.message = "تم حذف البيانات بنجاح";
                    else
                        Status.message = "Data Successfully Deleted";
                }
                else if (Mark.ToLower().Equals("notfound"))
                {
                    Status.code = 404;
                    if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("en"))
                        Status.message = "Data Not Found";
                    else if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("ar"))
                        Status.message = "لم يتم العثور علي البيانات";
                    else
                        Status.message = "Data Not Found";
                }
                else if (Mark.ToLower().Equals("inv_mod"))
                {
                    Status.code = 203;
                    if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("en"))
                        Status.message = "Invalid Model";
                    else if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("ar"))
                        Status.message = "محتوي البيانات خاطئ";
                    else
                        Status.message = "Invalid Model";
                }
                else if (Mark.ToLower().Equals("not_edit"))
                {
                    Status.code = 505;
                    if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("en"))
                        Status.message = "Invalid Operation not editable record";
                    else if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("ar"))
                        Status.message = "عملية خاطئة الحركة اللتي تحاول تعديلها غير قابلة للتعديل";
                    else
                        Status.message = "Invalid Operation not editable record";
                }
                else if (Mark.ToLower().Equals("sl"))
                {
                    Status.code = 200;
                    if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("en"))
                        Status.message = "Successfully Logined";
                    else if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("ar"))
                        Status.message = "تم تسجيل الدخول بنجاح";
                    else
                        Status.message = "Successfully Logined";
                }
                else if (Mark.ToLower().Equals("fl"))
                {
                    Status.code = 201;
                    if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("en"))
                        Status.message = "Failed Login";
                    else if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("ar"))
                        Status.message = "فشل تسجيل الدخول بنجاح";
                    else
                        Status.message = "Failed Login";
                }
                else if (Mark.ToLower().Equals("exp"))
                {
                    Status.code = 204;
                    if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("en"))
                        Status.message = "Expired Account";
                    else if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("ar"))
                        Status.message = "تم انتهاء فترة تسجيلكم لدينا";
                    else
                        Status.message = "Expired Account";
                }
                else if (Mark.ToLower().Equals("unauth"))
                {
                    Status.code = 401;
                    if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("en"))
                        Status.message = "Unauthorized Access";
                    else if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("ar"))
                        Status.message = "غير مصرح بالدخول";
                    else
                        Status.message = "Unauthorized Access";
                }
                else if (Mark.ToLower().Equals("ser_err"))
                {
                    Status.code = 500;
                    if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("en"))
                        Status.message = "Server Error";
                    else if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("ar"))
                        Status.message = "خطأ بالخادم";
                    else
                        Status.message = "Server Error";
                }
                else if (Mark.ToLower().Equals("tok_ex"))
                {

                    Status.code = 200;
                    if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("en"))
                        Status.message = "New Generated Token";
                    else if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("ar"))
                        Status.message = "مفتاح جديد تمت ولادته";
                    else
                        Status.message = "New Generated Token";
                }

                else if (Mark.ToLower().Equals("mail_sent"))
                {
                    Status.code = 303;
                    if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("en"))
                        Status.message = "Mail Sent";
                    else if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("ar"))
                        Status.message = "تم ارسال الايميل";
                    else
                        Status.message = "Mail Sent";
                }
              
              
                else if (Mark.ToLower().Equals("mail_exist"))
                {
                    Status.code = 204;
                    if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("en"))
                        Status.message = "Exist Mail";
                    else if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("ar"))
                        Status.message = "تم تسجيل هذا الايميل سابقا";
                    else
                        Status.message = "Exist Mail";
                }
                else if (Mark.ToLower().Equals("phone_exist"))
                {
                    Status.code = 205;
                    if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("en"))
                        Status.message = "Exist Phone";
                    else if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("ar"))
                        Status.message = "تم تسجيل هذا رقم الموبايل سابقا";
                    else
                        Status.message = "Exist Phone";
                }
                else if (Mark.ToLower().Equals("code_ex"))
                {
                    Status.code = 111;
                    if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("en"))
                        Status.message = "Expired Code";
                    else if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("ar"))
                        Status.message = "الكود منتهي";
                    else
                        Status.message = "Expired Code";
                }
                else if (Mark.ToLower().Equals("not_verified_user"))
                {
                    Status.code = 112;
                    if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("en"))
                        Status.message = "Not Verified User";
                    else if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("ar"))
                        Status.message = "مستخدم لم يكمل ادخال الكود";
                    else
                        Status.message = "Not Verified User";
                }
                else if (Mark.ToLower().Equals("not_edit"))
                {
                    Status.code = 219;
                    if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("en"))
                        Status.message = "Cannot edit that record";
                    else if (!String.IsNullOrEmpty(Lang) && Lang.ToLower().Equals("ar"))
                        Status.message = "لن تستطيع تعديل ";
                    else
                        Status.message = "Cannot edit that record";
                }
            }
     
            return Status;

        }
        public static long GetTimeStamp(DateTime value)
        {
            DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long TotSecs = 0;
            //if (value > Epoch)
            //{
            TimeSpan elapsedTime = value - Epoch;
            TotSecs = Convert.ToInt64(elapsedTime.TotalMilliseconds);
            return TotSecs;
            //}
            // return TotSecs;
        }
        public static string CreateMD5(string input)
        {

            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString().ToLower();
            }
        }
        public static int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
        public static string GetRateCount(string RateCounter)
        {
            string rateCounterFlag = null;
            int RateCounterValue = Convert.ToInt32(RateCounter);
            if (RateCounterValue >= 0 && RateCounterValue < 10)
                rateCounterFlag = "-10";
            else if (RateCounterValue >= 10 && RateCounterValue < 100)
                rateCounterFlag = "+10";
            else if (RateCounterValue >= 100 && RateCounterValue < 200)
                rateCounterFlag = "+100";

            else if (RateCounterValue >= 200 && RateCounterValue < 300)
                rateCounterFlag = "+200";
            else if (RateCounterValue >= 300 && RateCounterValue < 400)
                rateCounterFlag = "+300";
            else if (RateCounterValue >= 400 && RateCounterValue < 500)
                rateCounterFlag = "+400";
            else if (RateCounterValue >= 500 && RateCounterValue < 600)
                rateCounterFlag = "+500";
            else if (RateCounterValue >= 600 && RateCounterValue < 700)
                rateCounterFlag = "+600";
            else if (RateCounterValue >= 700 && RateCounterValue < 800)
                rateCounterFlag = "+700";
            else if (RateCounterValue >= 800 && RateCounterValue < 900)
                rateCounterFlag = "+800";
            else if (RateCounterValue >= 900 && RateCounterValue < 1000)
                rateCounterFlag = "+900";
            else if (RateCounterValue >= 1000 && RateCounterValue < 2000)
                rateCounterFlag = "+1K";
            else if (RateCounterValue >= 2000 && RateCounterValue < 3000)
                rateCounterFlag = "+2K";
            else if (RateCounterValue >= 3000 && RateCounterValue < 4000)
                rateCounterFlag = "+3K";
            else if (RateCounterValue >= 4000 && RateCounterValue < 5000)
                rateCounterFlag = "+4K";
            else if (RateCounterValue >= 5000 && RateCounterValue < 6000)
                rateCounterFlag = "+5K";
            else if (RateCounterValue >= 6000 && RateCounterValue < 7000)
                rateCounterFlag = "+6K";
            else if (RateCounterValue >= 7000 && RateCounterValue < 8000)
                rateCounterFlag = "+7K";
            else if (RateCounterValue >= 8000 && RateCounterValue < 9000)
                rateCounterFlag = "+8K";
            else if (RateCounterValue >= 9000 && RateCounterValue < 10000)
                rateCounterFlag = "+9K";
            else if (RateCounterValue >= 10000)
                rateCounterFlag = "+10K";
            return rateCounterFlag;
        }
        public static List<int> GenerateIntArray(string str)
        {
            List<int> arr = new List<int>();
            int[] EmptyArr = new int[4] {0,0,0,0 };
            if (!String.IsNullOrEmpty(str))
            {
                if(str.Contains(","))
                str = str.Replace(",", "");
                if (str.Contains("1")) EmptyArr[0] = 1;
                if (str.Contains("2")) EmptyArr[1] = 2;
                if (str.Contains("3")) EmptyArr[2] = 3;
                if (str.Contains("4")) EmptyArr[3] = 4;
                arr = EmptyArr.ToList();
            }
            else
                arr = EmptyArr.ToList();
            return arr;
        }
        public static List<int> GenerateIntArrayVer02(string str)
        {
            List<int> arr = new List<int>();
            str= string.Concat(str.Skip(1).Take(str.Length - 2));

            if (!String.IsNullOrEmpty(str))
            {
                int CommCount = str.Where(v => v.Equals(',')).Count();
                if (CommCount == 0) CommCount = 1;
                else if (CommCount > 0) CommCount = CommCount + 1;
                string[] StrNums = new string[CommCount];
                StrNums = str.Split(',');
                for (int i = 0; i < CommCount; i++)
                    if (StrNums[i]!="[" || StrNums[i]!="]")
                        arr.Add(Convert.ToInt32(StrNums[i]));
            }

            return arr;
        }
        public static double[] GenerateDoubleArray(string str)
        {
            double []arr = new double[3];

            if (!String.IsNullOrEmpty(str))
            {
                int CommCount = str.Where(v => v.Equals(',')).Count();
                if (CommCount == 0) CommCount = 1;
                else if (CommCount > 0) CommCount = CommCount + 1;
                string[] StrNums = new string[CommCount];
                StrNums = str.Split(',');
                for (int i = 0; i < CommCount; i++)
                    arr[i]=Convert.ToDouble(StrNums[i]);
            }
            return arr;
        }
        public static ValidationResult IsNotArabicInput(object input)
        {
            var result = ValidationResult.Success;
            if (input != null)
            {
                if (input.ToString().Length > 100)
                {
                    result = new ValidationResult("Invalid Input Characters Length (Too Long string)");
                    return result;
                }
                if (input.ToString().ToLower().Contains('a') ||
                    input.ToString().ToLower().Contains('b') ||
                    input.ToString().ToLower().Contains('c') ||
                    input.ToString().ToLower().Contains('d') ||
                    input.ToString().ToLower().Contains('e') ||
                    input.ToString().ToLower().Contains('f') ||
                    input.ToString().ToLower().Contains('g') ||
                    input.ToString().ToLower().Contains('h') ||
                    input.ToString().ToLower().Contains('j') ||
                    input.ToString().ToLower().Contains('k') ||
                    input.ToString().ToLower().Contains('l') ||
                    input.ToString().ToLower().Contains('m') ||
                    input.ToString().ToLower().Contains('n') ||
                    input.ToString().ToLower().Contains('o') ||
                    input.ToString().ToLower().Contains('q') ||
                    input.ToString().ToLower().Contains('w') ||
                    input.ToString().ToLower().Contains('x') ||
                    input.ToString().ToLower().Contains('y') ||
                    input.ToString().ToLower().Contains('z') ||
                    input.ToString().ToLower().Contains('r') ||
                    input.ToString().ToLower().Contains('t') ||
                    input.ToString().ToLower().Contains('s') ||
                    input.ToString().ToLower().Contains('u') ||
                    input.ToString().ToLower().Contains('v') ||
                    input.ToString().ToLower().Contains('i') ||
                    input.ToString().ToLower().Contains('p')
                    )
                    result = new ValidationResult("Invalid Input Characters (Not Arabic Language)");
                return result;
            }
            return result;
        }
    
        public static ValidationResult IsContainsNumbersOrSpecialCharsOnly(object input)
        {
            var result = ValidationResult.Success;
            if (input != null)
            {
                if (input.ToString().Length > 100)
                {
                    result = new ValidationResult("3022");
                    return result;
                }
                if (input.ToString().ToLower().Contains('0') ||
                    input.ToString().ToLower().Contains('1') ||
                    input.ToString().ToLower().Contains('2') ||
                    input.ToString().ToLower().Contains('3') ||
                    input.ToString().ToLower().Contains('4') ||
                    input.ToString().ToLower().Contains('5') ||
                    input.ToString().ToLower().Contains('6') ||
                    input.ToString().ToLower().Contains('7') ||
                    input.ToString().ToLower().Contains('8') ||
                    input.ToString().ToLower().Contains('.') || 
                    input.ToString().ToLower().Contains('*') || 
                    input.ToString().ToLower().Contains('+') || 
                    input.ToString().ToLower().Contains('/') || 
                    input.ToString().ToLower().Contains(',') || 
                    input.ToString().ToLower().Contains('<') || 
                    input.ToString().ToLower().Contains('>') || 
                    input.ToString().ToLower().Contains('@') || 
                    input.ToString().ToLower().Contains('!') || 
                    input.ToString().ToLower().Contains('$') ||
                    input.ToString().ToLower().Contains('^') ||
                    input.ToString().ToLower().Contains('%') ||
                    input.ToString().ToLower().Contains(')') ||
                    input.ToString().ToLower().Contains('-') ||
                    input.ToString().ToLower().Contains('_') ||
                    input.ToString().ToLower().Contains('=') ||
                    input.ToString().ToLower().Contains('#') ||
                    input.ToString().ToLower().Contains(':') ||
                    input.ToString().ToLower().Contains(';') ||
                    input.ToString().ToLower().Contains(';') ||
                    input.ToString().ToLower().Contains(']') ||
                    input.ToString().ToLower().Contains('[') ||
                    input.ToString().ToLower().Contains('{') ||
                    input.ToString().ToLower().Contains('}') ||
                    input.ToString().ToLower().Contains('?') ||
                    input.ToString().ToLower().Contains('|') ||
                    input.ToString().ToLower().Contains('&')

                    )
                    result = new ValidationResult("3061");
                return result;
            }
            return result;
        
}

        public static ValidationResult AddressContainsSpecialCharsOnly(object input)
        {
            var result = ValidationResult.Success;
            if (input != null)
            {
                if (input.ToString().Length > 300 || input.ToString().Length < 10)
                {
                    result = new ValidationResult("3062");
                    return result;
                }
                if (
                    input.ToString().ToLower().Contains('.') ||
                    input.ToString().ToLower().Contains('*') ||
                    input.ToString().ToLower().Contains('+') ||
                    input.ToString().ToLower().Contains('/') ||
                    input.ToString().ToLower().Contains(',') ||
                    input.ToString().ToLower().Contains('<') ||
                    input.ToString().ToLower().Contains('>') ||
                    input.ToString().ToLower().Contains('@') ||
                    input.ToString().ToLower().Contains('!') ||
                    input.ToString().ToLower().Contains('$') ||
                    input.ToString().ToLower().Contains('^') ||
                    input.ToString().ToLower().Contains('%') ||
                    input.ToString().ToLower().Contains(')') ||
                    input.ToString().ToLower().Contains('-') ||
                    input.ToString().ToLower().Contains('_') ||
                    input.ToString().ToLower().Contains('=') ||
                    input.ToString().ToLower().Contains('#') ||
                    input.ToString().ToLower().Contains(':') ||
                    input.ToString().ToLower().Contains(';') ||
                    input.ToString().ToLower().Contains(';') ||
                    input.ToString().ToLower().Contains(']') ||
                    input.ToString().ToLower().Contains('[') ||
                    input.ToString().ToLower().Contains('{') ||
                    input.ToString().ToLower().Contains('}') ||
                    input.ToString().ToLower().Contains('?') ||
                    input.ToString().ToLower().Contains('|') ||
                    input.ToString().ToLower().Contains('&')

                    )
                    result = new ValidationResult("3062");
                return result;
            }
            return result;
        }


        public static ValidationResult ContainsNumbersOrPlusOnly(object input)
        {
            var result = ValidationResult.Success;
            if (input != null)
            {
                if (input.ToString().Length > 4 || input.ToString().Length < 3)
                {
                    result = new ValidationResult("Invalid Country Code Lenght");
                    return result;
                }
                string Permitted = "0123456789+";


                for (int i = 0; i < input.ToString().ToLower().Length; i++)
                {

                    if (!Permitted.Contains(input.ToString()[i]))
                    {
                        result = new ValidationResult("Please enter valid country code");
                        break;
                    }

                }

                return result;
            }
            return result;
        }
        public static string GetRoleStrObject(int[] Role) {
            string RoleString = null;
            if (Role.Length > 0)
                Role = Role.Where(v => v != 0).ToArray();
            if (Role.Length > 0)
            {
                for (int i = 0; i < Role.Length; i++) {
                    if(Role[i]!=0)
                    RoleString = RoleString + ',' + Role[i].ToString();
                }
                RoleString = RoleString.Remove(0, 1);
            }
            return RoleString;
        }
        public static string GetSpecialityStr(int[] SepcialityIds)
        {
            string SpecString = null;
            if (SepcialityIds.Length > 0)
                SepcialityIds = SepcialityIds.Where(v => v != 0).ToArray();
            if (SepcialityIds.Length > 0)
            {
                for (int i = 0; i < SepcialityIds.Length; i++)
                {
                    if (SepcialityIds[i] != 0)
                        SpecString = SpecString + ',' + SepcialityIds[i].ToString();
                }
                SpecString = SpecString.Remove(0, 1);
            }
            return SpecString;
        }
        public static double GetBase64Size(string Base64Str) {
            double size = 0;
            if (!String.IsNullOrEmpty(Base64Str))
            {
                double FileLenght = Convert.ToDouble(Base64Str.Length);
                string latestchars = Base64Str.Substring(Base64Str.Length - 2);
                if (latestchars.Equals("=="))
                {
                    size = (FileLenght * 0.75) - 2;
                    return size / 1000000;
                }
                else if (latestchars[1].Equals("="))
                {
                    size = (FileLenght * 0.75) - 1;
                    return size / 1000000;
                }
                else {
                    size = (FileLenght * 0.75);
                    return size / 1000000;
                }
            }
            return size / 1000000;
        }
        public static ValidationResult CheckFileExtention(object input)
        {
            var result = ValidationResult.Success;
            if (input.ToString() != null)
            {
                string[] Permited = new string[] {".jpg",".jpeg", ".png", ".doc", ".docx", ".pdf" };
                string inp = input.ToString().ToLower();
                if (String.IsNullOrEmpty(inp))
                    result = new ValidationResult("fileextention is required");
                if (Permited.Where(v => v.Equals(inp)).Count() == 0)
                    result = new ValidationResult("Invalid file extention(valid extentions {.pdf,.png,.doc,.docx})");
                return result;
            }
            return result;
        }

        public static Uri GetFtpLink(string FileUrl) {
            Uri ftpUrl = null;
            if (!String.IsNullOrEmpty(FileUrl))
            {
                FileUrl = FileUrl.Remove(4, 5);
                FileUrl = FileUrl.Split(':')[1];
                FileUrl = FileUrl.Remove(0, 4);
                FileUrl = "ftp://176.9.155.102:91/school/" + FileUrl;
                ftpUrl = new Uri(FileUrl, UriKind.Absolute);
                return ftpUrl;
            }
            else
                return ftpUrl;
        }
        public static Uri GetFtpLink(string FileUrl , string ftpUriRoot)
        {
            Uri ftpUrl = null;
            if (!String.IsNullOrEmpty(FileUrl))
            {
                FileUrl = FileUrl.Remove(4, 5);
                FileUrl = FileUrl.Split(':')[1];
                FileUrl = FileUrl.Remove(0, 4);
                FileUrl = ftpUriRoot+"/" + FileUrl;
                ftpUrl = new Uri(FileUrl, UriKind.Absolute);
                return ftpUrl;
            }
            else
                return ftpUrl;
        }
        public static Uri GetFtpLinkAssigned(string FileUrl , string ftpServer)
        {
            Uri ftpUrl = null;
            if (!String.IsNullOrEmpty(FileUrl))
            {
                FileUrl = FileUrl.Remove(4, 5);
                FileUrl = FileUrl.Split(':')[1];
                FileUrl = FileUrl.Remove(0, 4);
                FileUrl = ftpServer + FileUrl;
                ftpUrl = new Uri(FileUrl, UriKind.Absolute);
                return ftpUrl;
            }
            else
                return ftpUrl;
        }
        public static System.Drawing.Image image(string base64file) {
            System.Drawing.Image image;
            if (base64file.Contains(','))
            {
                byte[] bytes = Convert.FromBase64String(base64file.Split(',')[1].ToString());
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    image = System.Drawing.Image.FromStream(ms);
                }
                return image;
            }
            else
            {
                byte[] bytes = Convert.FromBase64String(base64file.ToString());
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    image = System.Drawing.Image.FromStream(ms);
                }
                return image;
            }
        }
        public static byte[] ImgByteArr(string base64file)
        {
            if (base64file.Contains(','))
            {
                byte[] bytes = Convert.FromBase64String(base64file.Split(',')[1].ToString());
                return bytes;
            }
            else
            {
                byte[] bytes = Convert.FromBase64String(base64file.ToString());
                return bytes;
            }
        }
        public static string FileName(string fileExtention)
        {
            Guid g = new Guid();
            string TodDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            string target = TodDate + g.ToString() + fileExtention;
            return target;
        }
        public static bool IsImage(string input)
        {

            if (input.ToString().ToLower().Equals(".png") || input.ToString().ToLower().Equals(".jpg")|| input.ToString().ToLower().Equals(".jpeg"))
                return true;
            else if (input.ToString().ToLower().Equals(".pdf") ||
                input.ToString().ToLower().Equals(".docx") ||
                input.ToString().ToLower().Equals(".doc")
                )
                return false;
            else
                return false;
        }
        public static ValidationResult PasswordLenght(object input)
        {
            var result = ValidationResult.Success;
            if (input!=null) { 
            if (!String.IsNullOrEmpty(input.ToString()))
            {
                if (input.ToString().Length < 6)
                {
                    result = new ValidationResult("Password field must be at least 6 characters");
                    return result;
                }
            }
        }
            return result;
        }
       
      
       
        public static string Get_Lang(string Lang)
        {
            if (!String.IsNullOrEmpty(Lang)) {
                if(Lang.ToLower().Equals("en")) Lang = "en";
                else if (Lang.ToLower().Equals("ar")) Lang = "ar";
                else Lang = "en";
            }
            else Lang = "en";
            return Lang;
        }
        public static bool IsExpiredAccount(DateTime? EndDate)
               {
            bool isExpired = false;
            if (EndDate!=null)
            {
                if (EndDate > DateTime.Now) isExpired = false;
                else isExpired = true;
            }
            else isExpired = true;
            return isExpired;
        }
   
  
        public static List<ItemStatus> GetItemsStatuses()
        {
            List<ItemStatus> Statuses = new List<ItemStatus>();
            Statuses.Add(new ItemStatus { itemStatusId = "new", itemStatusName = "New Item" });
            Statuses.Add(new ItemStatus { itemStatusId = "gone", itemStatusName = "Used Item" });
            Statuses.Add(new ItemStatus { itemStatusId = "used", itemStatusName = "Gone Item" });
            return Statuses;
        }
        public static List<ItemDescription> GetItemsDescritions()
        {
            List<ItemDescription> ItemDescriptions = new List<ItemDescription>();
            ItemDescriptions.Add(new ItemDescription { itemDescriptionId = "Sustinable", itemDescriptionName = "Sustinable" });
            ItemDescriptions.Add(new ItemDescription { itemDescriptionId = "Consumed", itemDescriptionName = "Consumed" });
            return ItemDescriptions;
        }
        public static ValidationResult LicenceExpiryDate(object input)
        {
            var result = ValidationResult.Success;
            if (input != null)
            {
                DateTime InDate = Convert.ToDateTime(input).Date;
                DateTime CurrentDate = DateTime.Now.Date;
                DateTime MaxDate = DateTime.Now.AddDays(14);
                if (InDate.Date <= CurrentDate.Date)
                {
                    result = new ValidationResult("Invalid date input for driverLicenceExpires value should be greater than (" + CurrentDate.ToString("MM/dd/yyyy") + ")");
                }
                return result;
            }
            return result;
        }
        public static ValidationResult FineDate(object input)
        {
            var result = ValidationResult.Success;
            if (input != null)
            {
                DateTime InDate = Convert.ToDateTime(input);
                DateTime MinDate = DateTime.Now.AddDays(-30).Date;
                DateTime MaxDate = DateTime.Now.Date;
                if (InDate.Date < MinDate || InDate.Date > MaxDate.Date)
                {
                    result = new ValidationResult("Invalid date input for validfrom value should be between (" + MinDate.ToString("MM/dd/yyyy HH:mm") + ") and (" + MaxDate.ToString("MM/dd/yyyy HH:mm") + ").");
                }
                return result;
            }
            return result;
        }
        public static List<string> GetSourceDestinationAliasList()
        {
            List<string> SourceDestinationAliasList = new List<string>();
            SourceDestinationAliasList.Add("Source");
            SourceDestinationAliasList.Add("Destination");
            SourceDestinationAliasList.Add("Source-Destination");
            return SourceDestinationAliasList;
        }
        public static bool IsValidTransactionType(string source, string destination)
        {
            bool IsValid = true;
            if (source == destination && source.Equals("cus")) IsValid = false;
            else if (source == destination && source.Equals("supp")) IsValid = false;
            else if (source == destination && source.Equals("vech")) IsValid = false;

            else if (source.Equals("vech") && destination.Equals("cus")) IsValid = false;
            else if (source.Equals("vech") && destination.Equals("supp")) IsValid = false;

            else if (source.Equals("supp") && destination.Equals("vech")) IsValid = false;
            else if (source.Equals("supp") && destination.Equals("cus")) IsValid = false;

            else if (source.Equals("cus") && destination.Equals("vech")) IsValid = false;
            else if (source.Equals("cus") && destination.Equals("supp")) IsValid = false;
            return IsValid;
        }
   
        public static ValidationResult ValidateInvoiceType(object input)
        {
            var result = ValidationResult.Success;
            if (input != null)
            {
                string InvTypeId = input.ToString();
                if (GetInvoiceTypes().Where(b=>b.invoiceTypeName.Equals(InvTypeId)).FirstOrDefault()==null)
                {
                    result = new ValidationResult("Invalid value for property invoiceTypeId (not found invoice type)");
                }
                return result;
            }
            return result;
        }
       
        public static List<Item_Units> GetItemsUnits()
        {
            List<Item_Units> units = new List<Item_Units>();
            units.Add(new Item_Units {  name = "Box" });
            units.Add(new Item_Units { name = "CM" });
            units.Add(new Item_Units { name = "DZ" });
            units.Add(new Item_Units { name = "FT" });
            units.Add(new Item_Units { name = "IN" });
            units.Add(new Item_Units { name = "G" });
            units.Add(new Item_Units {  name = "KG" });

            return units;
        }
        public static ValidationResult ValidateISBN(object input)
        {
            var result = ValidationResult.Success;
            if (!String.IsNullOrEmpty(input.ToString()))
            {
                string ISBN = input.ToString();
                if (ISBN.Length !=17 || ISBN.Count(f => f == '-')!=4 )
                {
                    result = new ValidationResult("3044");
                }
                string Permitted = "0123456789-";


                for (int i = 0; i < ISBN.Length; i++)
                {

                    if (!Permitted.Contains(input.ToString()[i]))
                    {
                        result = new ValidationResult("3044");
                        break;
                    }

                }
                return result;
            }
            return result;
        }
        public static ValidationResult ValidateItemPackageName(object input)
        {
            var result = ValidationResult.Success;
            if (input != null)
            {
                if (input.ToString().ToLower().Contains('0') ||
                    input.ToString().ToLower().Contains('1') ||
                    input.ToString().ToLower().Contains('2') ||
                    input.ToString().ToLower().Contains('3') ||
                    input.ToString().ToLower().Contains('4') ||
                    input.ToString().ToLower().Contains('5') ||
                    input.ToString().ToLower().Contains('6') ||
                    input.ToString().ToLower().Contains('7') ||
                    input.ToString().ToLower().Contains('8') ||
                    input.ToString().ToLower().Contains('.') ||
                    input.ToString().ToLower().Contains('*') ||
                    input.ToString().ToLower().Contains('+') ||
                    input.ToString().ToLower().Contains('/') ||
                    input.ToString().ToLower().Contains(',') ||
                    input.ToString().ToLower().Contains('<') ||
                    input.ToString().ToLower().Contains('>') ||
                    input.ToString().ToLower().Contains('@') ||
                    input.ToString().ToLower().Contains('!') ||
                    input.ToString().ToLower().Contains('$') ||
                    input.ToString().ToLower().Contains('^') ||
                    input.ToString().ToLower().Contains('%') ||
                    input.ToString().ToLower().Contains(')') ||
                    input.ToString().ToLower().Contains('-') ||
                    input.ToString().ToLower().Contains('_') ||
                    input.ToString().ToLower().Contains('=') ||
                    input.ToString().ToLower().Contains('#') ||
                    input.ToString().ToLower().Contains(':') ||
                    input.ToString().ToLower().Contains(';') ||
                    input.ToString().ToLower().Contains(';') ||
                    input.ToString().ToLower().Contains(']') ||
                    input.ToString().ToLower().Contains('[') ||
                    input.ToString().ToLower().Contains('{') ||
                    input.ToString().ToLower().Contains('}') ||
                    input.ToString().ToLower().Contains('?') ||
                    input.ToString().ToLower().Contains('|') ||
                    input.ToString().ToLower().Contains('&')
                    )
                    result = new ValidationResult("3066");
                return result;
            }
            return result;

        }

        public static List<Invoice_Type> GetInvoiceTypes()
        {
            List<Invoice_Type> invoiceTypes = new List<Invoice_Type>();
            invoiceTypes.Add(new Invoice_Type { invoiceTypeName = "Cash" });
            invoiceTypes.Add(new Invoice_Type { invoiceTypeName = "Credit" });
            return invoiceTypes;
        }
        public static ValidationResult ValidateinvoiceType(object input)
        {
            var result = ValidationResult.Success;
            if (!String.IsNullOrEmpty(input.ToString()))
            {
                string invType = input.ToString();
                if (!invType.Equals("Cash") && !invType.Equals("Credit"))
                {
                    result = new ValidationResult("3009");
                }
               
                return result;
            }
            return result;
        }

        public static void SendFireBaseNotification(string token,string title )
        {
            try
            {
                string serverKey = "AAAAa0r09_o:APA91bGp4dp2dw6vVGvnp2yXMO-8XLTFcYf9Tvc0MC61j-rC01Y_cbEtI1F_ebZZQdF7s9P4RQjel-oKQKy8hSGeLKA-GeJVNrE3kRLaW4Xb69WbrNMZ4AnocxJ87itb9Eq4dqgxGnaE";
                var result = "-1";
                string image = "";
                var webAddr = "https://fcm.googleapis.com/fcm/send";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json";
                // httpWebRequest.Headers.Add("Authorization:key=" + serverKey);
                httpWebRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAa0r09_o:APA91bGp4dp2dw6vVGvnp2yXMO-8XLTFcYf9Tvc0MC61j-rC01Y_cbEtI1F_ebZZQdF7s9P4RQjel-oKQKy8hSGeLKA-GeJVNrE3kRLaW4Xb69WbrNMZ4AnocxJ87itb9Eq4dqgxGnaE"));
                //httpWebRequest Id - From firebase project setting  
                httpWebRequest.Headers.Add(string.Format("Sender: id={0}", "460819068922"));
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"to\": \"" + token + "\",\"priority\":\"high\",\"data\":{\"id\":\"" + title + "\",\"type\":\"employeeInvoiceEdit\"}}";
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                    //Debug.WriteLine(result.ToString());
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                //Debug.WriteLine(str.ToString());
            }
        }

   

    }
}