using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPIToolbelt.Controllers
{
    public class Attributes : ControllerBase
    {
        /// <summary>
        /// Returns an attribute array based on the game system and type of array.
        /// </summary>
        /// <param name="system">Tabletop Game System</param>
        /// <param name="type">Type of array to be returned</param>
        /// <returns></returns>
        public static int[] GetAttributeArray(string system, string type)
        {
            var attributes = new int[6];

            switch (system.ToUpper())
            {
                case "5E":
                    GetDungensandDragons5eAttributeArray(type, attributes);
                    break;
                case "SWN":
                    GetStarsWithoutNumberAttributeArray(type, attributes);
                    break;
                default:
                    break;
            }

            return attributes;
        }

        public static int[] GetAttributeModifiers(string system, IList<int> attributes)
        {
            var modifiers = Array.Empty<int>();

            switch (system.ToUpper())
            {
                case "5E":
                    GetDnD5eAttributeModifiers(attributes, modifiers);
                    break;
                case "SWN":
                    GetStarsWithoutNumberAttributeModifiers(attributes, modifiers);
                    break;
                default:
                    break;
            }

            return modifiers;
        }

        /// <summary>
        /// Returns an attribute array based on the Stars Without Number (SWN) system and type of array.
        /// </summary>
        /// <param name="type">Type of array to be returned</param>
        /// <param name="attributes">Instantiated attributes array</param>
        private static void GetStarsWithoutNumberAttributeArray(string type, IList<int> attributes)
        {
            switch (type.ToUpper())
            {
                case "RANDOM":
                    attributes[0] = CommonUtilities.GetDiceRolls(6, 3).Sum();
                    attributes[1] = CommonUtilities.GetDiceRolls(6, 3).Sum();
                    attributes[2] = CommonUtilities.GetDiceRolls(6, 3).Sum();
                    attributes[3] = CommonUtilities.GetDiceRolls(6, 3).Sum();
                    attributes[4] = CommonUtilities.GetDiceRolls(6, 3).Sum();
                    attributes[5] = CommonUtilities.GetDiceRolls(6, 3).Sum();
                    break;
                case "CUSTOM":
                    attributes[0] = 0;
                    attributes[1] = 0;
                    attributes[2] = 0;
                    attributes[3] = 0;
                    attributes[4] = 0;
                    attributes[5] = 0;
                    break;
                default:
                    attributes[0] = 14;
                    attributes[1] = 12;
                    attributes[2] = 11;
                    attributes[3] = 10;
                    attributes[4] = 9;
                    attributes[5] = 7;
                    break;
            }
        }

        /// <summary>
        /// Returns an attribute array based on the Dungens and Dragons 5th edition (5E) system and type of array.
        /// </summary>
        /// <param name="type">Type of array to be returned</param>
        /// <param name="attributes">Instantiated attributes array</param>
        private static void GetDungensandDragons5eAttributeArray(string type, IList<int> attributes)
        {
            switch (type.ToUpper())
            {
                case "RANDOM":
                    attributes[0] = CommonUtilities.GetDiceRolls(6, 4).OrderByDescending(x => x).Take(3).Sum();
                    attributes[1] = CommonUtilities.GetDiceRolls(6, 4).OrderByDescending(x => x).Take(3).Sum();
                    attributes[2] = CommonUtilities.GetDiceRolls(6, 4).OrderByDescending(x => x).Take(3).Sum();
                    attributes[3] = CommonUtilities.GetDiceRolls(6, 4).OrderByDescending(x => x).Take(3).Sum();
                    attributes[4] = CommonUtilities.GetDiceRolls(6, 4).OrderByDescending(x => x).Take(3).Sum();
                    attributes[5] = CommonUtilities.GetDiceRolls(6, 4).OrderByDescending(x => x).Take(3).Sum();
                    break;
                case "POINT BUY":
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

        /// <summary>
        /// Retuns the StarsWithoutNumber attribute modifiers for each attribute.
        /// </summary>
        /// <param name="attributes">Instantiated attributes array</param>
        /// <param name="modifiers">Instantiated attribute modifiers</param>
        private static void GetStarsWithoutNumberAttributeModifiers(IList<int> attributes, IList<int> modifiers)
        {
            foreach (var attribute in attributes)
            {
                switch (attribute)
                {
                    case int n when (n < 4):
                        modifiers.Add(-2);
                        break;
                    case int n when (n > 3 && n < 8):
                        modifiers.Add(-1);
                        break;
                    case int n when (n > 7 && n < 14):
                        modifiers.Add(0);
                        break;
                    case int n when (n > 13 && n < 18):
                        modifiers.Add(1);
                        break;
                    case int n when (n > 17):
                        modifiers.Add(2);
                        break;
                    default:
                        modifiers.Add(0);
                        break;
                }
            }
        }

        /// <summary>
        /// Returns the Dungens and Dragons 5th edition (5E) attribute modifiers for each attribute.
        /// </summary>
        /// <param name="attributes">Instantiated attributes array</param>
        /// <param name="modifiers">Instantiated attribute modifiers</param>
        private static void GetDnD5eAttributeModifiers(IList<int> attributes, IList<int> modifiers)
        {
            foreach (var attribute in attributes)
            {
                int modifier = (int)Math.Floor((attribute - 10f) / 2f);
                if (modifier < -5)
                {
                    modifiers.Add(-5);
                }
                else if (modifier > 10)
                {
                    modifiers.Add(10);
                }
                else
                {
                    modifiers.Add(modifier);
                }
            }
        }
    }
}
