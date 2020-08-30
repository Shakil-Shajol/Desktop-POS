using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSales
{
    public class DateTimeConverter
    {
        public int Da { get; set; }
        public int Hou { get; set; }
        public string Minu { get; set; }
        public int Yea { get; set; }
        public int Mont { get; set; }
        public string Stmonth { get; set; }
        public string AmPm { get; set; }

        DateTime dt = DateTime.Now;

        public string hhmmttddmmmmyyyy() 
        {
            if (dt.Hour>11)
            {
                AmPm = "PM";
            }
            else
            {
                AmPm = "AM";
            }
            if (dt.Hour==0)
            {
                Hou = 12;
                
            }
            else if (dt.Hour>12)
            {
                Hou = dt.Hour - 12;
            }

            if (dt.Month==1)
            {
                Stmonth = "January";
            }
            else if (dt.Month == 2)
            {
                Stmonth = "February";
            }
            else if (dt.Month == 3)
            {
                Stmonth = "March";
            }
            else if (dt.Month == 4)
            {
                Stmonth = "April";
            }
            else if (dt.Month == 5)
            {
                Stmonth = "May";
            }
            else if (dt.Month == 6)
            {
                Stmonth = "June";
            }
            else if (dt.Month == 7)
            {
                Stmonth = "July";
            }
            else if (dt.Month == 8)
            {
                Stmonth = "August";
            }
            else if (dt.Month == 9)
            {
                Stmonth = "September";
            }
            else if (dt.Month == 10)
            {
                Stmonth = "October";
            }
            else if (dt.Month == 11)
            {
                Stmonth = "November";
            }
            else
            {
                Stmonth = "December";
            }

            if (dt.Minute<10)
            {
                Minu = "0" + dt.Minute;
            }
            else
            {
                Minu = dt.Minute.ToString();
            }

            string format = Hou + ":" + Minu + " " + AmPm +Environment.NewLine + dt.Day + "-" + Stmonth + "-" + dt.Year;
            return format;
        }
    }
}
