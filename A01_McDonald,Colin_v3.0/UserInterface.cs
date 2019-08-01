using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsLander
{
    class UserInterface
    {
 
 
        public void PrintGreeting()
        {
            Console.WriteLine("Welcome to the Mars Lander game!");
        }

        // This should print the 'picture' of hte lander
        // for example:
        //      1000m: *
        //      900m: 
        //      800m:
        // etc, etc
        public void PrintLocation(MarsLander m)
        {
            int i = m.GetHeight() / 100 * 100;

            if ((m.GetHeight() / 100) * 100 < 1000)
                i = 1000;

            for (; i >= 0; i -= 100)
            {
                if (i == (m.GetHeight() / 100) * 100)
                    Console.WriteLine($"{i}m :  *  ");
                else
                    Console.WriteLine($"{i}m :  ");
            }

        }

        // This prints out the info about the lander
        // For example:
        //      Exact height: 1350 meters
        //      Current (downward) speed: -350 meters/second
        //      Fuel points left: 0
        public void PrintLanderInfo(MarsLander m)
        {
            Console.WriteLine($"Exact height : {m.GetHeight()} meters\n" +
                              $"Current (downward) speed: {m.GetSpeed()} meters/second\n" +
                              $"Fuel points left : {m.GetFuel()}");
        }

        // This will ask the user for how much fuel they want to burn,
        // verify that they've type in an acceptable integer,
        //  (repeatedly asking the user for input if needed),
        // and will then return that number back to the main method
        public int GetFuelToBurn(MarsLander m)
        {
            bool looper = false;
            bool endLoop = false;

            while(endLoop==false)
            {
                if(looper ==true)
                {
                    Console.WriteLine("Just as a reminder, here's where the lander is: ");
                    PrintLanderInfo(m);
                }
                looper = true;

                Console.WriteLine("How many points of fuel would you like to burn?");
                string tempString = Console.ReadLine();
                int nFuel;

                if(!Int32.TryParse(tempString, out nFuel))
                     Console.WriteLine("Please enter a valid integer");   
                 else if(nFuel >=0 && m.GetFuel()>=nFuel)
                    return nFuel;
                 else if(nFuel<0)
                        Console.WriteLine("You cannot burn less than 0 points of fuel!");
                 else if(m.GetFuel()<nFuel)
                        Console.WriteLine($"You don't have {nFuel} points of fuel.");
               
            }

            return 0;
          
        }
      


        // This will only be called once the lander is on the surface of Mars, 
        //  and will tell the player if they successly landed or if they crashed
        public void PrintEndOfGameResult(MarsLander ml, int maxSpeed)
        {
            if (ml.GetSpeed() <= maxSpeed && ml.GetHeight() == 0)
                Console.WriteLine("Congratulations!! You've successfully landed your Mars Lander, without crashing!!!");
            else
            {
                Console.WriteLine("The maximum speed for a safe landing is 10; " +
                                    $"your lander's current speed is {ml.GetSpeed()}");
            Console.WriteLine("You have crashed the lander into the surface of Mars, killing everyone on board," +
                              "costing NASA millions of dollars, and setting the space program back by decades!");
             }
         PrintHistory(ml.GetHistory(maxSpeed));
        }

        // This will print out, for example: 
        //      Round # 	Height (in m) 	Speed (downwards, in m/s)
        //      0 		850 		150
        //      1 		650 		200
        //  etc
        //
        // This is provided to you, but you'll need to add stuff elsewhere in order to make it work 
        public void PrintHistory(MarsLanderHistory mlh)
        {
            Console.WriteLine("Round #\t\tHeight (in m)\t\tSpeed (downwards, in m/s)");
            for (int i = 0; i < mlh.NumberOfRounds(); i++)
            {  
                Console.WriteLine($"{i}\t\t{mlh.GetHeight(i)}\t\t{mlh.GetSpeed(i)}");
            }
        }
    }
}
