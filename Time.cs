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
            if (hour >= 24 && minute > 0 && second > 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (hour >= 24 || minute >= 60 || second >= 60)
            {
                throw new ArgumentOutOfRangeException();
            }
            if(hour<0 || minute<0 || second < 0)
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
            if (a >= 24 && b > 0 && c > 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (a >= 24 || b >= 60 || c >= 60)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (a < 0 || b < 0 || c < 0)
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
                string[] tabelka = tekst.Split(':');
                byte a = Convert.ToByte(tabelka[0]);
                byte b = Convert.ToByte(tabelka[1]);
                byte c = Convert.ToByte(tabelka[2]);
                if (a < 0 || b < 0 || c < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                Time p = new Time(a, b, c);
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
            if (this.Equals(other)) return 0;
            if ((this.Hours < other.Hours)||((this.Hours==other.Hours)&&(this.Minutes<other.Minutes)&&(this.Seconds<other.Seconds))
                ||(this.Hours==other.Hours)&& (this.Minutes == other.Minutes) && (this.Seconds < other.Seconds))
                return -1;
            else if ((this.Hours > other.Hours) || ((this.Hours == other.Hours) && (this.Minutes > other.Minutes))
                || (this.Hours == other.Hours) && (this.Minutes == other.Minutes) && (this.Seconds > other.Seconds))
                return 1;
            return 2;
           
            
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
            if (p1.CompareTo(p2) == -1)
            {
                return true;
            }
            return false;
        }
        public static bool operator >=(Time p1, Time p2)
        {

            if (p1.CompareTo(p2) == 1  || p1.Equals(p2))
                return true;
            return false;

        }
        public static bool operator <=(Time p1, Time p2)
        {
            if (p1.CompareTo(p2) == -1 || p1.Equals(p2))
            {
                return true;
            }
           
                return false;
            
        }


    

    }
    public struct TimePeriod
    {
        public long DlugoscOdcinka => dlugoscOdcinka;
        private readonly long dlugoscOdcinka;
        private readonly long hour;
        private readonly long minute;
        private readonly long second;
        public TimePeriod(long hour, long minute, long second)
        {
            if (hour < 0 || minute < 0 || second < 0)
            {
                throw new ArgumentOutOfRangeException();
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
    }


}
