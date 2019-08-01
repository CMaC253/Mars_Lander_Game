using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsLander
{
    class MarsLander
    {
        // positive speed == speed towards Mars (DOWNWARD)

        private MarsLanderHistory mlh = new MarsLanderHistory();
        #region Accessors
        // you'll need to add data fields & methods so that the rest of the program
        // can use the various properties of the lander (such as height, speed, etc)
        private int height, speed, fuel;
        public void SetHeight(int newH)
        {
            if (newH <= 0)
                newH = 0;

            height = newH;
        }
        public void SetSpeed(int newS){ speed = newS; }
        public void SetFuel(int newF) { fuel = newF; }
        public int GetHeight() { return height; }
        public int GetSpeed() { return speed; }
        public int GetFuel() { return fuel; }
        #endregion
        public MarsLanderHistory GetHistory(int maxSpeed)
        {
            return mlh.Clone();
        }
        public void CalculateNewSpeed(int fuel)
        {
            SetSpeed(GetSpeed() + 50 - fuel );
            SetFuel(GetFuel() - fuel);
            SetHeight(GetHeight() - speed);
            mlh.AddRound(GetHeight(), GetSpeed());
        }

        public MarsLander()
        {
            height = 1000;
            fuel = 500;
            speed = 100;
        }

    }
}
