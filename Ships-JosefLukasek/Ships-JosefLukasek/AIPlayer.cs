using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships_JosefLukasek
{
    /// <summary>
    /// This class is responsible for AI player.
    /// </summary>
    public class AIPlayer
    {
        // Predefined plans for AI player ship placement
        string[] predefinedPlans = new string[]
        {
            "SWWSWWWWWWWSWWWSSWWWWSWSSWWWWWWWWWWSSSWWWWSWSWWWSWWWSWWWWWWWWWSWWWWWWWWWWWWSSSSWWWWWWWWWWWWWWWWWWWWW",
            "SWWWSWWWWSWWWWWWSSWSWWSWSWWWWSWWSWSWWWWSSWWWSWSSWWWWWWWWWWWWWWSSSWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWSWWWW",
            "WWWWWWWWWWWWSSWWSWWWWWWWSWSWSWWWWSWSWWSWWWSWSWWWSWWWSWWSSSWWWWWSWWWWWWWWWSWWWWWWWWWSWWWWWWWWWSWWWWWW",
        };
        
        List<(int, int)> possibleShots = new List<(int, int)>();
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AIPlayer"/> class and generates all possible shots.
        /// </summary>
        public AIPlayer()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    possibleShots.Add((i, j));
                }
            }
        }

        /// <summary>
        /// Upon call generates a plan for ship placement
        /// </summary>
        /// <returns> The plan. </returns>
        public string GetPlan()
        {
            return predefinedPlans[new Random().Next(0, predefinedPlans.Length)];
        }

        /// <summary>
        /// Upon call generates a random coordinate for shot that has not been shot yet
        /// </summary>
        /// <returns> The shot. </returns>
        public (int, int) GetShot()
        {
            int index = new Random().Next(0, possibleShots.Count);
            (int, int) shot = possibleShots[index];
            possibleShots.RemoveAt(index);
            return shot;
        }
    }
}
