using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrtFixer
{
    public class MyTime
    {
        private int hour_;
        private int minutes_;
        private int seconds_;
      
        public MyTime(int hour, int minutes, int seconds)
        {
            this.hour_ = hour;
            this.minutes_ = minutes;
            this.seconds_ = seconds;
        }

        public void AddSeconds(int seconds)
        {
            seconds_ += seconds;            
            minutes_ += seconds_ / 60;
            hour_ += minutes_ / 60;

            seconds_ = seconds_ % 60;
            minutes_ = minutes_ % 60;
            hour_ = hour_ % 24;
        }

        public override string ToString()
        {
            return String.Format("{0:00}:{1:00}:{2:00}", hour_, minutes_, seconds_);
        }

        public static bool operator ==(MyTime mytime1, MyTime mytime2)
        {
            if (mytime1.hour_ == mytime2.hour_ &&
                mytime1.minutes_ == mytime2.minutes_ &&
                mytime1.seconds_ == mytime2.seconds_)
                return true;
            else
                return false;
        }
        public static bool operator !=(MyTime mytime1, MyTime mytime2)
        {
            return !(mytime1 == mytime2);
        }
    }
}
