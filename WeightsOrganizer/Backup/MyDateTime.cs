using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeightsOrganizer
{
    [Serializable]
    public class MyDateTime
    {
        int _year = 0, _month = 0, _day = 0, _hour = 0, _minute = 0, _second = 0;
        
        System.Globalization.DateTimeFormatInfo dfi = new System.Globalization.DateTimeFormatInfo();
        string _tt = "AM";
        public MyDateTime(int year, int month, int day, int hour, int minute, int second, string tt)
        {
            _year = year;
            _month = month;
            _day = day;
            _hour = hour;
            _minute = minute;
            _second = second;
            _tt = tt;
     
        }
        public static MyDateTime Now
        {
            get
            {
                DateTime dateandtime = DateTime.Now;
                return new MyDateTime(dateandtime);
            }

        }
        public static MyDateTime Parse(string MyDateTime)
        {
            //02/08/1988 03:30:00 م
            int _year = 0, _month = 0, _day = 0, _hour = 0, _minute = 0, _second = 0;
            _day = int.Parse(MyDateTime.Substring(0, 2));//02
            _month = int.Parse(MyDateTime.Substring(3, 2));//08
            _year = int.Parse(MyDateTime.Substring(6,4));///1988
                                                          //space   
            _hour = int.Parse(MyDateTime.Substring(12, 2));//03 houre
            _minute = int.Parse(MyDateTime.Substring(15, 2));//30 mi
            _second = int.Parse(MyDateTime.Substring(18, 2));//00 second
            string _tt = "AM";//the lahqa
             _hour = (_hour > 12 ? _hour - 12 : _hour);
            _hour = (_hour == 0 ? 12 : _hour);
            _tt = MyDateTime.Substring(MyDateTime.Length-1, 1);
            _tt = (_tt == "م" ? _tt = "PM" : _tt = "AM");
            MyDateTime x = new MyDateTime(_year,_month,_day,_hour,_minute,_second,_tt);
            return x;
        }
        public MyDateTime(ref DateTime dateandtime)
        {
            //dfi.MonthDayPattern = "dd/MM/yyyy hh:mm:ss tt";
            dfi = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat;
            _year = dateandtime.Year;
           // if (_year.ToString().Length == 2) _year = int.Parse(DateTime.Now.Year.ToString() + _year.ToString());
            _month = dateandtime.Month;
            _day = dateandtime.Day;
            _hour = dateandtime.Hour;
            _minute = dateandtime.Minute;
            _second = dateandtime.Second;
            _tt = dateandtime.ToString("m", dfi).Substring(dateandtime.ToString("m").Length - 2, 2);

        }
        public MyDateTime( DateTime dateandtime)
        {
            //dfi.MonthDayPattern = "dd/MM/yyyy hh:mm:ss tt";
            dfi = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat;
            _year = dateandtime.Year;
            //if (_year.ToString().Length == 2) _year = int.Parse(DateTime.Now.Year.ToString() + _year.ToString());
            _month = dateandtime.Month;
            _day = dateandtime.Day;
            _hour = dateandtime.Hour;
            _minute = dateandtime.Minute;
            _second = dateandtime.Second;
            _tt = dateandtime.ToString("m").Substring(dateandtime.ToString("m").Length - 2, 2);
 
        }
     /// <summary>
     /// التاريخ مع ااسم اليوم مثل الخميس
     /// </summary>
     /// <param name="WithNameOfDay">بوليان</param>
        /// <returns>bo</returns>
        public  string ToString(bool WithNameOfDay)
        {
            _hour = (_hour > 12 ? _hour - 12 : _hour);
            _hour = (_hour == 0 ? 12 : _hour);
            if (WithNameOfDay)
            {
                return string.Format("{0}/{1}/{2}  {3}:{4}:{5} {6}", (_day.ToString().Length == 1 ? "0" + _day.ToString() : _day.ToString()),
                    (_month.ToString().Length == 1 ? "0" + _month.ToString() : _month.ToString()),
                    (_year.ToString().Length == 1 ? "0" + _year.ToString() : _year.ToString())
                    , (_hour.ToString().Length == 1 ? "0" + _hour.ToString() : _hour.ToString())
                    , (_minute.ToString().Length == 1 ? "0" + _minute.ToString() : _minute.ToString())
                      , (_second.ToString().Length == 1 ? "0" + _second.ToString() : _second.ToString())
                    , ((_tt == "AM") ? "ص" : "م"));
            }
            else
            {
                return string.Format("{0}, {1}/{2}/{3}  {4}:{5}:{6} {7}",this.GetNameOfDay() ,(_day.ToString().Length == 1 ? "0" + _day.ToString() : _day.ToString()),
                    (_month.ToString().Length == 1 ? "0" + _month.ToString() : _month.ToString()),
                    (_year.ToString().Length == 1 ? "0" + _year.ToString() : _year.ToString())
                    , (_hour.ToString().Length == 1 ? "0" + _hour.ToString() : _hour.ToString())
                    , (_minute.ToString().Length == 1 ? "0" + _minute.ToString() : _minute.ToString())
                      , (_second.ToString().Length == 1 ? "0" + _second.ToString() : _second.ToString())
                    , ((_tt == "AM") ? "ص" : "م"));
            }


        }
        public override string ToString()
        {
            return this.ToString(false);
      

        }
        public string ToStringToinsert()
        {
 
            _hour = (_hour > 12 ? _hour - 12 : _hour);
            _hour = (_hour == 0 ? 12 : _hour);
            return string.Format("{0}/{1}/{2}  {3}:{4}:{5} {6}", (_day.ToString().Length == 1 ? "0" + _day.ToString() : _day.ToString()),
                (_month.ToString().Length == 1 ? "0" + _month.ToString() : _month.ToString()),
                (_year.ToString().Length == 1 ? "0" + _year.ToString() : _year.ToString())
                , (_hour.ToString().Length == 1 ? "0" + _hour.ToString() : _hour.ToString())
                , (_minute.ToString().Length == 1 ? "0" + _minute.ToString() : _minute.ToString())
                  , (_second.ToString().Length == 1 ? "0" + _second.ToString() : _second.ToString())
                , ((_tt == "AM") ? "ص" : "م"));

        }
        public   DateTime MyDateTimeasDateTime
        {
            get
            {
                DateTime dateandtime = new DateTime(_year, _month, _day, _hour, _minute, _second);
                return DateTime.Parse(dateandtime.ToString());
 
            }

        }
        public string JustDate
        {
            get { return this.ToString(true).Substring(0, 10); }
        }
        /// <summary>
        /// الوقت العربي
        /// </summary>
        public string Time
        {
            get {     return this.ToString(true).Substring(11, 11); }
        }
        public string GetNameOfDay()
        {
            return Globals.Globals.GetNameOfDay(this.MyDateTimeasDateTime.DayOfWeek);
        }
    }
}
