using System;

namespace Zadanie_TIME
{  
    /// <summary>
   /// Klasa Time
   /// Implementuje metody równości, porównywania, dodawania, odejmowania i
   /// </summary>
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        private readonly byte hours;
        private readonly byte minutes;
        private readonly byte seconds;
        public byte Hours { get { return hours; } }
        public byte Minutes { get { return minutes; } }
        public byte Seconds { get { return seconds; } }
        /// <summary>
        /// Konstruktor trzyargumentowy
        /// </summary>
        public Time(byte hh, byte mm, byte ss)
            {

          
                this.hours = Convert.ToByte(hh % 24);
                this.minutes = Convert.ToByte(mm % 60);
                this.seconds = Convert.ToByte(ss % 60);
      
         

        }
        /// <summary>
        /// Konstruktor jednoargumentowy
        /// </summary>
        public Time(byte hh) : this(hh, default(byte), default(byte)) { }
        /// <summary>
        /// Konstruktor dwuargumentowy
        /// </summary>
        public Time(byte hh, byte mm) : this(hh, mm, default(byte)) { }
        /// <summary>
        /// Konstruktor jednoargumentowy - String w formacie "hh:mm:ss"
        /// </summary>
        ///
        public Time(string ss)
        {
            string h= Convert.ToString(ss[0])+ Convert.ToString(ss[1]);
            string m= Convert.ToString(ss[3]) + Convert.ToString(ss[4]);
            string s= Convert.ToString(ss[6])+ Convert.ToString(ss[7]);

            this.hours = Convert.ToByte(Convert.ToInt32(h)%24);
            this.minutes = Convert.ToByte(Convert.ToInt32(m) % 60);
            this.seconds= Convert.ToByte(Convert.ToInt32(s) % 60);
        }
        /// <summary>
        /// Przeciążona metoda ToString()       
        /// </summary>

        public override string ToString() { return $"{Hours}:{Minutes}:{Seconds}";}
        /// <summary>
        /// Metoda Equals
        /// Porównuje dwa obiekty typu Time i zwraca true lub false.
        /// </summary>   
        public override bool Equals(Object obj)
        {
            if (obj is Time) { 
            return (this.Hours == ((Time)obj).Hours &&
                this.Minutes == ((Time)obj).Minutes &&
                this.Seconds == ((Time)obj).Seconds);}
            else return false;
        }
        public bool Equals(Time other)
        { return (this.Hours.Equals(other.Hours)
                && this.Minutes.Equals(other.Minutes)
                && this.Seconds.Equals(other.Seconds));
        }


        public static bool operator ==(Time t1, Time t2)
        {
            return t1.Equals(t2);
        }
        public static bool operator !=(Time t1, Time t2)
        {
            return !t1.Equals(t2);
        }



        /// <summary>
        /// Metoda CompareTo
        /// Porównuje dwa obiekty typu Time i zwraca 1, 0 lub -1
        /// </summary> 
        public int CompareTo(Time other)
        {
            if (this.Hours.CompareTo(other.Hours) == 1) return 1;
            else if (this.Hours.CompareTo(other.Hours) == 0)
            {
                if (this.Minutes.CompareTo(other.Minutes) == 1) return 1;
                else if (this.Minutes.CompareTo(other.Minutes) == 0)
                {
                    if (this.Seconds.CompareTo(other.Seconds) == 1)
                        return 1;
                    else if (this.Seconds.CompareTo(other.Seconds) == 0)
                        return 0;
                    else return -1;
                }
                else return -1;
            }
            else return -1;
        }

        public int CompareTo(Time t1, Time t2)
        {
            return t1.CompareTo(t2);
        }

        public static int Compare(Time t1, Time t2)
        {
            return t1.CompareTo(t2);
        }

        public static bool operator >(Time t1, Time t2)
        {
            return t1.CompareTo(t2) == 1;
        }

        public static bool operator <(Time t1, Time t2)
        {
            return t1.CompareTo(t2) == -1;
        }

        public static bool operator >=(Time t1, Time t2)
        {
            return t1.CompareTo(t2) == 0;
        }

        public static bool operator <=(Time t1, Time t2)
        {
            return t1.CompareTo(t2) == 0;
        }

        /// <summary>
        /// Metoda Plus
        /// Dodaje dwa obiekty typu Time i TimePeriod
        /// </summary>   
        public static Time Plus(Time t, TimePeriod p)
        {
            byte h = Convert.ToByte(t.Hours + (p.Seconds / 60 / 60));
            byte m = Convert.ToByte(t.Minutes + ((p.Seconds / 60) - (((p.Seconds / 60) / 60) * 60)));
            byte s = Convert.ToByte(t.Seconds + (p.Seconds - (((p.Seconds / 60) * 60 - (p.Seconds / 60 / 60) * 60 * 60)) - (p.Seconds / 60 / 60) * 60 * 60));
            if (s >= 60) m++;
            if (m >= 60) h++;
            Time time = new Time(h, m, s);
            return time;
        }

        public static Time operator +(Time t, TimePeriod p)
        {
            return Plus(t, p);
        }

        /// <summary>
        /// Metoda Plus
        /// Dodaje dwa obiekty typu Time
        /// </summary> 
        public Time Plus(Time t)
        {
            byte h = 0;
            byte m = 0;
            byte s = 0;

            
            
            h += Convert.ToByte(this.Hours + t.Hours);            
            m += Convert.ToByte(this.Minutes + t.Minutes);
            s += Convert.ToByte(this.Seconds + t.Seconds);

            if (s >= 60) m++;
            if (m >= 60) h++;
            Time time = new Time(h, m, s);
            return time;
        }

        public static Time Plus(Time t1, Time t2)
        {
            return t1.Plus(t2);
        }

        public static Time operator + (Time n, Time m)
        {
            return n.Plus(m);
        }
        /// <summary>
        /// Metoda Minus
        /// Odejmuje dwa obiekty typu Time i TimePeriod
        /// </summary>  
        public static Time Minus(Time t, TimePeriod p)
        {
            byte h = Convert.ToByte(Math.Abs(t.Hours - (p.Seconds / 60 / 60)));
            byte m = Convert.ToByte(Math.Abs(t.Minutes - ((p.Seconds / 60) - (((p.Seconds / 60) / 60) * 60))));
            byte s = Convert.ToByte(Math.Abs(t.Seconds - (p.Seconds - (((p.Seconds / 60) * 60 - (p.Seconds / 60 / 60) * 60 * 60)) - (p.Seconds / 60 / 60) * 60 * 60)));
          
            Time time = new Time(h, m, s);
            return time;
        }
        public static Time operator -(Time t, TimePeriod p)
        {
            return Minus(t, p);
        }
        /// <summary>
        /// Metoda Minus
        /// Odejmuje dwa obiekty typu Time
        /// </summary>  
        public Time Minus(Time t)
        {
            byte h = 0;
            byte m = 0;
            byte s = 0;

            s += Convert.ToByte(Math.Abs(Convert.ToInt32(this.Seconds - t.Seconds)));
            m += Convert.ToByte(Math.Abs(Convert.ToInt32(this.Minutes - t.Minutes)));
            h += Convert.ToByte(Math.Abs(Convert.ToInt32(this.Hours - t.Hours)));
          

            Time time= new Time(h, m, s);
            return time;
        }

        public static Time Minus(Time t1, Time t2)
        {
            return t1.Minus(t2);
        }

        public static Time operator -(Time n, Time m)
        {
            return n.Minus(m);
        }
    }
}
