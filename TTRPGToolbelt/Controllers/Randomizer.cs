using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIToolbelt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Randomizer : ControllerBase
    {

        public int[] GetAttributeArray(string system, string type)
        {
            int[] attributes = new int[6];
            Random rnd = new Random();
            
            switch(system)
            {
                case "5e":
                    if (type == "Random")
                    {
                        attributes[0] = GetDiceRolls(6, 4).OrderByDescending(x => x).Take(3).Sum();  
                        attributes[1] = GetDiceRolls(6, 4).OrderByDescending(x => x).Take(3).Sum();  
                        attributes[2] = GetDiceRolls(6, 4).OrderByDescending(x => x).Take(3).Sum();  
                        attributes[3] = GetDiceRolls(6, 4).OrderByDescending(x => x).Take(3).Sum();  
                        attributes[4] = GetDiceRolls(6, 4).OrderByDescending(x => x).Take(3).Sum();  
                        attributes[5] = GetDiceRolls(6, 4).OrderByDescending(x => x).Take(3).Sum();
                    }
                    else if(type == "Point Buy")
                    {
                        attributes[0] = 0;
                        attributes[1] = 0;
                        attributes[2] = 0;
                        attributes[3] = 0;
                        attributes[4] = 0;
                        attributes[5] = 0;
                    }
                    else
                    {
                        attributes[0] = 15;
                        attributes[1] = 14;
                        attributes[2] = 13;
                        attributes[3] = 12;
                        attributes[4] = 10;
                        attributes[5] = 8;
                    }
                    break;
                case "SWN":
                    if(type == "Random")
                    {
                        attributes[0] = GetDiceRolls(6, 3).Sum();
                        attributes[1] = GetDiceRolls(6, 3).Sum();
                        attributes[2] = GetDiceRolls(6, 3).Sum();
                        attributes[3] = GetDiceRolls(6, 3).Sum();
                        attributes[4] = GetDiceRolls(6, 3).Sum();
                        attributes[5] = GetDiceRolls(6, 3).Sum();
                    }
                    else
                    {
                        attributes[0] = 14;
                        attributes[1] = 12;
                        attributes[2] = 11;
                        attributes[3] = 10;
                        attributes[4] =  9;
                        attributes[5] =  7;
                    }
                    break;
                default:
                    break;
            }
            return attributes;
        }

        private List<int> GetDiceRolls(int faces, int count)
        {
            var rolls = new List<int>();
            Random rnd = new Random();

            for (int i = count; i > 0; i--)
            {
                rolls.Add(rnd.Next(1, faces + 1));
            }
            return rolls;
        }

    }
}
