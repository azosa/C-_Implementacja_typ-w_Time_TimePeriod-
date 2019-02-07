using System;
namespace Zadanie_TIME
{   /// <summary>
    /// Klasa TimePeriod
    /// Implementuje metody równości, porównywania, dodawania, odejmowania i
    /// </summary>
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
      
        private readonly long seconds;
        public long Seconds { get { return seconds; } }


        /// <summary>
        /// Konstruktor trzyargumentowy
        /// </summary>
        public TimePeriod(long hh, long mm, long ss)
        {
     
            this.seconds = ss + (mm * 60) + ((hh * 60) * 60);
        
        }
        /// <summary>
        /// Konstruktor dwuargumentowy
        /// </summary>
        public TimePeriod(long mm,long ss) : this(default(long), mm, ss) { }
        /// <summary>
        /// Konstruktor jednoargumentowy
        /// </summary>
        public TimePeriod(long ss) : this(default(long), default(long), ss) { }
        /// <summary>
        /// Konstruktor jednoargumentowy - String w formacie "hh:mm:ss"
        /// </summary>
        ///
        public TimePeriod(string ss)
        {
            string h = Convert.ToString(ss[0]) + Convert.ToString(ss[1]);
            string m = Convert.ToString(ss[3]) + Convert.ToString(ss[4]);
            string s = Convert.ToString(ss[6]) + Convert.ToString(ss[7]);

       
            this.seconds = Convert.ToInt32(s) + (Convert.ToInt32(m) * 60) + ((Convert.ToInt32(h) * 60) * 60);
        }

        /// <summary>
        /// Przeciążona metoda ToString()       
        /// </summary>

        public override string ToString()
        {
               
            return $"{Seconds / 60 / 60}:" +
                $"{((Seconds / 60) - (((Seconds / 60) / 60) * 60))}:" +
                $"{Seconds - (((Seconds / 60) * 60 - (Seconds / 60 / 60) * 60 * 60)) - (Seconds / 60 / 60) * 60 * 60}";
        }
        /// <summary>
        /// Metoda Equals
        /// Porównuje dwa obiekty typu TimePeriod i zwraca true lub false.
        /// </summary>   
        public override bool Equals(Object obj)
        {
            if (obj is TimePeriod)
            {
                return (this.Seconds == ((TimePeriod)obj).Seconds);
            }
            else return false;
        }
        public bool Equals(TimePeriod other)
        {
            return (this.Seconds.Equals(other.Seconds));
        }


        public static bool operator ==(TimePeriod t1, TimePeriod t2)
        {
            return t1.Equals(t2);
        }
        public static bool operator !=(TimePeriod t1, TimePeriod t2)
        {
            return !t1.Equals(t2);
        }



        /// <summary>
        /// Metoda CompareTo
        /// Porównuje dwa obiekty typu TimePeriod i zwraca 1, 0 lub -1
        /// </summary> 
        public int CompareTo(TimePeriod other)
        {
    
                    if (this.Seconds.CompareTo(other.Seconds) == 1)
                        return 1;
                    else if (this.Seconds.CompareTo(other.Seconds) == 0)
                        return 0;
                    else return -1;
              
          
        }

        public int CompareTo(TimePeriod t1, TimePeriod t2)
        {
            return t1.CompareTo(t2);
        }

        public static int Compare(TimePeriod t1, TimePeriod t2)
        {
            return t1.CompareTo(t2);
        }

        public static bool operator >(TimePeriod t1, TimePeriod t2)
        {
            return t1.CompareTo(t2) == 1;
        }

        public static bool operator <(TimePeriod t1, TimePeriod t2)
        {
            return t1.CompareTo(t2) == -1;
        }

        public static bool operator >=(TimePeriod t1, TimePeriod t2)
        {
            return t1.CompareTo(t2) == 0;
        }

        public static bool operator <=(TimePeriod t1, TimePeriod t2)
        {
            return t1.CompareTo(t2) == 0;
        }

        public TimePeriod Plus(TimePeriod t)
        {
          
            long s = 0;

            s += this.Seconds + t.Seconds;

            TimePeriod time = new TimePeriod(s);
            return time;
        }
        /// <summary>
        /// Metoda Plus
        /// Dodaje dwa obiekty typu TimePeriod
        /// </summary>  
        public static TimePeriod Plus(TimePeriod t1, TimePeriod t2)
        {
            return t1.Plus(t2);
        }

        public static TimePeriod operator +(TimePeriod n, TimePeriod m)
        {
            return n.Plus(m);
        }
        /// <summary>
        /// Metoda Minus
        /// Odejmuje dwa obiekty typu TimePeriod
        /// </summary>  
        public TimePeriod Minus(TimePeriod t)
        {

            long s = 0;

            s +=Math.Abs(this.Seconds - t.Seconds);

            TimePeriod time = new TimePeriod(s);
            return time;
        }

        public static TimePeriod Minus(TimePeriod t1, TimePeriod t2)
        {
            return t1.Minus(t2);
        }

        public static TimePeriod operator -(TimePeriod n, TimePeriod m)
        {
            return n.Minus(m);
        }
    }
}
