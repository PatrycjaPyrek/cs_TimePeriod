using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace TimePeriodTime

{
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        private readonly byte hour;
        private readonly byte minute;
        private readonly byte second;
        public byte Hours => hour;
        public byte Minutes => minute;
        public byte Seconds => second;

        public Time(byte hour = 0, byte minute = 0, byte second = 0)
        {
          
            if (hour >= 24 || minute >= 60 || second >= 60)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
        public Time(string tekst)
        {
            string[] tabelka = tekst.Split(':');

            byte a = Convert.ToByte(tabelka[0]);
            byte b = Convert.ToByte(tabelka[1]);
            byte c = Convert.ToByte(tabelka[2]);
            if (a >= 24 || b >= 60 || c >= 60)
            {
                throw new ArgumentOutOfRangeException();
            }
          
            hour = a;
            minute = b;
            second = c;

        }

        public override string ToString()
        {
            return $"{Hours:00}:{Minutes:00}:{Seconds:00}";
        }
        public static Time Parse(string tekst)
        {
            try
            {
               /* string[] tabelka = tekst.Split(':');
                byte a = Convert.ToByte(tabelka[0]);
                byte b = Convert.ToByte(tabelka[1]);
                byte c = Convert.ToByte(tabelka[2]);
               */
                Time p = new Time(tekst);
                return p;
            }

            catch
            {
                throw new FormatException();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Time)
                return Equals((Time)obj);
            else
                return false;
        }
        public bool Equals(Time other)
        {

            return ((Hours == other.Hours && Minutes == other.Minutes
                && Seconds == other.Seconds));


        }
        public static bool Equals(Time p1, Time p2)
        {
            return p1.Equals(p2);

        }
        public int CompareTo(Time other)
        {
           // if (this.Equals(other)) return 0;
            if ((this.Hours < other.Hours)||((this.Hours==other.Hours)&&(this.Minutes<other.Minutes)&&(this.Seconds<other.Seconds))
                ||(this.Hours==other.Hours)&& (this.Minutes == other.Minutes) && (this.Seconds < other.Seconds))
                return -1;
            else if ((this.Hours > other.Hours) || ((this.Hours == other.Hours) && (this.Minutes > other.Minutes))
                || (this.Hours == other.Hours) && (this.Minutes == other.Minutes) && (this.Seconds > other.Seconds))
                return 1;
            return 0;
           
            
        }
        public override int GetHashCode() => (Hours, Minutes, Seconds).GetHashCode();

        public static bool operator ==(Time p1, Time p2) => Equals(p1, p2);

        public static bool operator !=(Time p1, Time p2) => !(p1 == p2);

        public static bool operator >(Time p1, Time p2)
        {

            //if ((p1.Hours >= p2.Hours)||((p1.Hours == p2.Hours) && (p1.Minutes >= p2.Minutes))||
            //    ((p1.Hours==p2.Hours)&&(p1.Minutes==p2.Minutes)&&(p1.Seconds>=p2.Seconds)))
            //{
            if (p1.CompareTo(p2) == 1)
                return true;
            return false;
        
        }
        public static bool operator <(Time p1, Time p2)
        {
            if (p1.CompareTo(p2) < 0)
            {
                return true;
            }
            return false;
        }
        public static bool operator >=(Time p1, Time p2)
        {

            if (p1.CompareTo(p2) > 0  || p1.Equals(p2))
                return true;
            return false;

        }
        public static bool operator <=(Time p1, Time p2)
        {
            if (p1.CompareTo(p2) < 0 || p1.Equals(p2))
            {
                return true;
            }
           
                return false;
            
        }
        public static Time operator +(Time p1, TimePeriod p2)
        {
            var c3 = p1.Seconds + p2.Seconds;
            var b3 = p1.Minutes + p2.Minutes;
            var a3 = p1.Hours + p2.Hours;
            if (a3 > 24)
            {
                a3 %= 24;
            }
            Time t = new Time((byte)a3,(byte)b3,(byte)c3);
            return t;



        }




    }
    public struct TimePeriod :IEquatable<TimePeriod>,IComparable<TimePeriod>
    {
        public long DlugoscOdcinka => dlugoscOdcinka;
        private readonly long dlugoscOdcinka;
        private readonly long hour;
        private readonly long minute;
        private readonly long second;
        public long Hours => hour;
        public long Minutes => minute;
        public long Seconds => second;
        public TimePeriod(long hour, long minute, long second)
        {
            if (hour < 0 || minute < 0 || second < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (second > 59)
            {
                
                long ile=second/60;
                long noweSek = second%60;
                second = noweSek;
                minute += ile;
            }
            if (minute > 59)
            {
                long ile = minute / 60;
                long nowemMin = minute % 60;
                minute = nowemMin;
                hour += ile;
            }

            this.hour = hour;
            this.minute = minute;
            this.second = second;
            hour *= 3600;
            minute *= 60;
            this.dlugoscOdcinka = hour + minute + second;
        }
        public TimePeriod(string tekst)
        {
            string[] tabelka = tekst.Split(':');

            byte a = Convert.ToByte(tabelka[0]);
            byte b = Convert.ToByte(tabelka[1]);
            byte c = Convert.ToByte(tabelka[2]);
            if (a < 0 || b < 0 || c < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.hour = a*3600;
            this.minute = b*60;
            this.second = c;
            this.dlugoscOdcinka = hour + minute + second;
        }

        public override string ToString()
        {
            return $"{hour:0}:{minute:00}:{second:00} => {dlugoscOdcinka}";
        }

        public override bool Equals(object obj)
        {
            if (obj is TimePeriod)
                return Equals((TimePeriod)obj);
            else
                return false;
        }
        public bool Equals(TimePeriod other)
        {
            return DlugoscOdcinka == other.DlugoscOdcinka;
        }
        public static bool Equals(Time p1, Time p2)
        {
            return p1.Equals(p2);

        }
        public int CompareTo(TimePeriod other)
        {
           // if (this.Equals(other)) return 0;
            if(this.DlugoscOdcinka>other.DlugoscOdcinka)
                return 1;
            else if (this.DlugoscOdcinka < other.DlugoscOdcinka)
                return -1;
            return 0;


        }
        public override int GetHashCode() => DlugoscOdcinka.GetHashCode();

        public static bool operator ==(TimePeriod p1, TimePeriod p2) => Equals(p1, p2);

        public static bool operator !=(TimePeriod p1, TimePeriod p2) => !(p1 == p2);

        public static bool operator >(TimePeriod p1, TimePeriod p2)
        {

            if (p1.CompareTo(p2) == 1)
                return true;
            return false;

        }
        public static bool operator <(TimePeriod p1, TimePeriod p2)
        {
            if (p1.CompareTo(p2) < 0)
            {
                return true;
            }
            return false;
        }
        public static bool operator >=(TimePeriod p1, TimePeriod p2)
        {

            if (p1.CompareTo(p2) > 0 || p1.Equals(p2))
                return true;
            return false;

        }
        public static bool operator <=(TimePeriod p1, TimePeriod p2)
        {
            if (p1.CompareTo(p2) < 0 || p1.Equals(p2))
            {
                return true;
            }

            return false;

        }

        public static TimePeriod Plus(TimePeriod t,TimePeriod t2)
        {
            long Seconds = t.Seconds + t2.Seconds;
            long Minutes = t.Minutes + t2.Minutes;
            long Hours = t.Hours + t2.Hours;
         
            TimePeriod t3 = new TimePeriod(Hours, Minutes, Seconds);
            return t3;
        }
        public static TimePeriod Minus(TimePeriod t, TimePeriod t2)
        {
            long Seconds = t.Seconds - t2.Seconds;
            long Minutes = t.Minutes - t2.Minutes;
            long Hours = t.Hours - t2.Hours;

            TimePeriod t3 = new TimePeriod(Hours, Minutes, Seconds);
            return t3;
        }


    }


}
