using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsLander
{
    class MarsLanderHistory
    {
        RoundInfo[] rounds = new RoundInfo[10];
        int numRounds = 0;

        // Clone is provided to you; it'll create a copy of the current history
        // Look for opportunities to use it elsewhere.
        public MarsLanderHistory Clone()
        {
            MarsLanderHistory copy = new MarsLanderHistory();

            copy.rounds = new RoundInfo[this.rounds.Length];
            copy.numRounds = this.numRounds;
            for (int i = 0; i < copy.numRounds; i++)
                copy.rounds[i] = this.rounds[i];

            return copy;
        }


        public void AddRound(int h, int s)
        {

            if (numRounds == rounds.Length)
            {
                RoundInfo[] diffRounds = new RoundInfo[numRounds+10];
                for (int i = 0; i < rounds.Length; i++)
                {
                    
                    diffRounds[i] = rounds[i];
                }
                rounds =diffRounds ;
               
            }
            rounds[numRounds] = new RoundInfo(h,s);
            numRounds++;
           }

        public int NumberOfRounds()
        {
            return numRounds;
        }
        public int GetHeight(int x)
        {
          return rounds[x].GetHeight();
        }
        public int GetSpeed(int x)
        {
            return rounds[x].GetSpeed();
        } 
    }

    // This is provided to you; you shouldn't need to add anything to it, but
    // if you want to you are welcome to do so
    class RoundInfo
    {
        private int height;
        private int speed;

        #region Accessors
        public int GetHeight()
        {
            return height;
        }
        public void SetHeight(int newValue)
        {
            height = newValue;
        }

        public int GetSpeed()
        {
            return speed;
        }
        public void SetSpeed(int newValue)
        {
            speed = newValue;
        }
        #endregion Accessors

        public RoundInfo(int h, int s)
        {
            height = h;
            speed = s;
        }
    }
}
