using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2
{
    class Clock
    {
        private Timer timer;
        private DateTime currentDate = DateTime.Now;
        private static Dictionary<string, TimeSpan> shiftTimeCountries;
        public delegate void TickHander(Clock sender);
        public event TickHander SecondTick;

        static Clock()
        {
            shiftTimeCountries = new Dictionary<string, TimeSpan>();
            shiftTimeCountries.Add("Москва", new TimeSpan(0));
            shiftTimeCountries.Add("Владивосток", new TimeSpan(7, 0, 0));
            shiftTimeCountries.Add("Лондон", new TimeSpan(-3, 0, 0));
        }

        public Clock()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;     
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            currentDate = currentDate.AddSeconds(1);
            if(SecondTick != null)
            {
                SecondTick(this);
            }
        }
        
        public DateTime GetLocalTime(string name)
        {
            if (!shiftTimeCountries.ContainsKey(name))
            {
                throw new ArgumentException("Нет такого города");
            }

            TimeSpan shift = shiftTimeCountries[name];
            DateTime date = currentDate.Add(shift);
            return date;
        }

        public void Start()
        {
            currentDate = DateTime.Now;
            timer.Start();
        }
        public void Stop()
        {
            timer.Stop();
        }
    }
}
