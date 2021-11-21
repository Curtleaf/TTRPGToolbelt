using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIToolbelt.Controllers
{
    public class CommonUtilities
    {
        #region Random
        /// <summary>
        /// Will roll (count) number of (faces) sidded die and return each result.
        /// </summary>
        /// <param name="faces">How many sides the die has</param>
        /// <param name="count">How many die should be returned</param>
        /// <returns></returns>
        public static IEnumerable<int> GetDiceRolls(int faces, int count)
        {
            var rolls = new List<int>();
            var rnd = new Random();

            for (var i = count; i > 0; i--)
            {
                rolls.Add(rnd.Next(1, faces + 1));
            }
            return rolls;
        }

        #endregion

        #region Calculation

       

        #endregion
    }
}
