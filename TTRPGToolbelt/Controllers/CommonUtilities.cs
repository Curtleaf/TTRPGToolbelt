using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIToolbelt.Controllers
{
    public class CommonUtilities
    {
        #region Random
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

        
    }
}
