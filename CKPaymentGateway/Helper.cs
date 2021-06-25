using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CKPaymentGateway
{
    public static class Helper
    {
        public static bool checkLuhn(string card)
        {
            return card.All(char.IsDigit) && card.Reverse()
             .Select(c => c - 48)
             .Select((thisNum, i) => i % 2 == 0
                 ? thisNum
                 : ((thisNum *= 2) > 9 ? thisNum - 9 : thisNum)
             ).Sum() % 10 == 0;
        }
    }
}
