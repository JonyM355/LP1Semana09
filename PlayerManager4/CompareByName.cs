using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManager4
{
    public class CompareByName : IComparer<Player>
    {
        private bool acsending;

        public CompareByName(bool acsending)
        {
            this.acsending = acsending;
        }

        public int Compare(Player x, Player y)
        {
            if (acsending)
            {
                return string.Compare(x.Name, y.Name);
            }
            else
            {
                return string.Compare(y.Name, x.Name);
            }
        }
    }
}