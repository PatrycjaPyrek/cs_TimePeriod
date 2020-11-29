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
            if (this.Hours == other.Hours)
            {
                if (this.Minutes == other.Minutes)
                {
                    return this.Seconds.CompareTo(other.Seconds);
                }
                else
                {
                    this.Minutes.CompareTo(other.Minutes);
                }
            }
                return this.Hours.CompareTo(other.Hours);
        }
        public override int GetHashCode() => (Hours, Minutes, Seconds).GetHashCode();

        public static bool operator ==(Time p1, Time p2) => Equals(p1, p2);

        public static bool operator !=(Time p1, Time p2) => !(p1 == p2);

        public static bool operator >(Time p1, Time p2)=> p1.CompareTo(p2) > 0;
      
        public static bool operator <(Time p1, Time p2)=> p1.CompareTo(p2) < 0;
      
     
        public static bool operator >=(Time p1, Time p2)=> p1.CompareTo(p2) >= 0;
      
        public static bool operator <=(Time p1, Time p2)=>  p1.CompareTo(p2) <= 0;
      
        public static Time operator +(Time p1, TimePeriod p2)
        {
           return Time.Plus(p1, p2);
        }

        public static Time Plus(Time p1, TimePeriod p2)
        {
            var seconds = p1.Seconds + p2.Seconds;
            var minutes = p1.Minutes + p2.Minutes;
            var hours = p1.Hours + p2.Hours;

            if (seconds > 59)
            {

                byte ile = (byte)(seconds / 60);
                byte noweSek = (byte)(seconds % 60);
                seconds = noweSek;
                minutes += ile;
            }
            if (minutes > 59)
            {
                byte ile = (byte)(minutes / 60);
                byte nowemMin = (byte)(minutes % 60);
                minutes = nowemMin;
                hours += ile;
            }
            hours %= 24;

            Time t = new Time((byte)hours, (byte)minutes, (byte)seconds);
            return t;
        }

        public static TimePeriod operator -(Time t, Time t2)
        {
            /*var seconds = p1.Seconds - p2.Seconds;
            var minutes = p1.Minutes - p2.Minutes;
            var hours = p1.Hours - p2.Hours;
       
            TimePeriod t = new TimePeriod(hours, minutes, seconds);
            return t;*/
            
            long tHours = t.Hours;
            long t2Hours = t2.Hours;
           



            long Hours = tHours - t2Hours;
            long Seconds = t.Seconds - t2.Seconds;
            long Minutes = t.Minutes - t2.Minutes;
       

            if (Hours < 0)
            {
                Hours = 23;
                Hours -= (t2Hours - tHours - 1);
                Console.WriteLine(Hours);
            }
            if (Minutes < 0)
            {

                Minutes = 60 + Minutes;
                Hours -= 1;

            }
            if (Seconds < 0)
            {
                Seconds = 60 + Seconds;
                Minutes -= 1;

            }


            TimePeriod t3 = new TimePeriod(Hours, Minutes, Seconds);
            return t3;
        }
        public static TimePeriod Minus(Time t, Time t2)
        {
            return (t - t2);
        }
        public static Time Minus(Time t, TimePeriod t2)
        {
            byte tHours = t.Hours;
            long t2Hours = t2.Hours;
         
          
            
            long Hours = tHours - t2Hours;
            long Seconds = t.Seconds - t2.Seconds;
            long Minutes = t.Minutes - t2.Minutes;
            Console.WriteLine( Minutes);
            Console.WriteLine(Hours);
            Console.WriteLine(Seconds);

            if (Hours < 0)
            {
                Hours = 23; 
                Hours-=(byte)(t2Hours-tHours-1);
                Console.WriteLine(Hours);
            }
            if (Minutes < 0)
            {
                
                Minutes = 60+Minutes;
                Hours -= 1;
                
            }
            if (Seconds < 0)
            {
                Seconds = 60 + Seconds;
                Minutes -= 1;
             
            }
           

            Time t3 = new Time((byte)Hours, (byte)Minutes, (byte)Seconds);
            return t3;
        }
        public static Time operator -(Time t, TimePeriod t2)
        {
            return Time.Minus(t, t2);
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
        public TimePeriod(long hour=0, long minute=0, long second=0)
        {
            if (hour < 0)
            {
                hour = 0;
            }
            if (minute < 0)
            {
                minute = 0;
            }
            if (second < 0)
            {
                second = 0;
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
                long noweMin = minute % 60;
                minute = noweMin;
                hour += ile;
            }
            Console.WriteLine(hour);
            Console.WriteLine(minute);
            Console.WriteLine(second);
            this.hour = hour;
            this.minute = minute;
            this.second = second;
            hour *= 3600;
            minute *= 60;
            this.dlugoscOdcinka = hour + minute + second;
        }
        public TimePeriod(string tekst)
        {
            Console.WriteLine(tekst);
            string[] tabelka = tekst.Split(':');
                        
            byte a = Convert.ToByte(tabelka[0]);
            byte b = Convert.ToByte(tabelka[1]);
            byte c = Convert.ToByte(tabelka[2]);
            if (a < 0 )
            {
                a = 0;
            }
            if (b < 0)
            {
                b = 0;
            }

            if (c < 0)
            {
                c = 0;
            }
            this.hour = a;
            this.minute = b;
            this.second = c;

            hour = a*3600;
            minute = b*60;
            second = c;
            this.dlugoscOdcinka = hour + minute + second;
          
        }
        public TimePeriod(Time t1, Time t2)
        {
            var t = (t1-t2);
            Console.WriteLine(t.Seconds);
            Console.WriteLine(t.Minutes);
            Console.WriteLine(t.Hours);
            this.hour = t.Hours;
            this.minute = t.Minutes;
            this.second = t.Seconds;
            this.dlugoscOdcinka = (hour * 3600) + (minute * 60) + second;

        }

        public override string ToString()
        {
            return $"{hour:0}:{minute:00}:{second:00}";
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
            if(this.DlugoscOdcinka>other.DlugoscOdcinka)
                return 1;
            else if (this.DlugoscOdcinka < other.DlugoscOdcinka)
                return -1;
            return 0;
        }
        public override int GetHashCode() => DlugoscOdcinka.GetHashCode();

        public static bool operator ==(TimePeriod p1, TimePeriod p2) => Equals(p1, p2);

        public static bool operator !=(TimePeriod p1, TimePeriod p2) => !(p1 == p2);

        public static bool operator >(TimePeriod p1, TimePeriod p2)=> p1.CompareTo(p2) > 0;
     
        public static bool operator <(TimePeriod p1, TimePeriod p2)=> p1.CompareTo(p2) < 0;
      
        public static bool operator >=(TimePeriod p1, TimePeriod p2)=> p1.CompareTo(p2) >= 0;
        
        public static bool operator <=(TimePeriod p1, TimePeriod p2)=> p1.CompareTo(p2) <= 0;
       

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
       /* public static TimePeriod Minus(Time t, Time t2)
        {
            
            long Seconds = t.Seconds - t2.Seconds;
            long Minutes = t.Minutes - t2.Minutes;
            long Hours = t.Hours - t2.Hours;


            TimePeriod t3 = new TimePeriod(Hours, Minutes, Seconds);
            return t3;
        }*/
    }
}
