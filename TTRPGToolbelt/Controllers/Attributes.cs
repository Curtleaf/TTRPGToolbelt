using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPIToolbelt.Controllers
{
    public class Attributes : ControllerBase
    {
        public static int[] AttributeArray(string system, string type)
        {
            var attributes = new int[6];

            switch (system)
            {
                case "5e":
                    GetDnD5eAttributeArray(type, attributes);
                    break;
                case "SWN":
                    GetStarsWithoutNumberAttributeArray(type, attributes);
                    break;
                default:
                    break;
            }

            return attributes;
        }

        private static void GetStarsWithoutNumberAttributeArray(string type, int[] attributes)
        {
            if (type == "Random")
            {
                attributes[0] = CommonUtilities.GetDiceRolls(6, 3).Sum();
                attributes[1] = CommonUtilities.GetDiceRolls(6, 3).Sum();
                attributes[2] = CommonUtilities.GetDiceRolls(6, 3).Sum();
                attributes[3] = CommonUtilities.GetDiceRolls(6, 3).Sum();
                attributes[4] = CommonUtilities.GetDiceRolls(6, 3).Sum();
                attributes[5] = CommonUtilities.GetDiceRolls(6, 3).Sum();
            }
            else
            {
                attributes[0] = 14;
                attributes[1] = 12;
                attributes[2] = 11;
                attributes[3] = 10;
                attributes[4] = 9;
                attributes[5] = 7;
            }
        }

        private static void GetDnD5eAttributeArray(string type, int[] attributes)
        {
            switch (type)
            {
                case "Random":
                    attributes[0] = CommonUtilities.GetDiceRolls(6, 4).OrderByDescending(x => x).Take(3).Sum();
                    attributes[1] = CommonUtilities.GetDiceRolls(6, 4).OrderByDescending(x => x).Take(3).Sum();
                    attributes[2] = CommonUtilities.GetDiceRolls(6, 4).OrderByDescending(x => x).Take(3).Sum();
                    attributes[3] = CommonUtilities.GetDiceRolls(6, 4).OrderByDescending(x => x).Take(3).Sum();
                    attributes[4] = CommonUtilities.GetDiceRolls(6, 4).OrderByDescending(x => x).Take(3).Sum();
                    attributes[5] = CommonUtilities.GetDiceRolls(6, 4).OrderByDescending(x => x).Take(3).Sum();
                    break;
                case "Point Buy":
                    attributes[0] = 0;
                    attributes[1] = 0;
                    attributes[2] = 0;
                    attributes[3] = 0;
                    attributes[4] = 0;
                    attributes[5] = 0;
                    break;
                default:
                    attributes[0] = 15;
                    attributes[1] = 14;
                    attributes[2] = 13;
                    attributes[3] = 12;
                    attributes[4] = 10;
                    attributes[5] = 8;
                    break;
            }
        }
    }
}
