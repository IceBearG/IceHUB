using System;

namespace MyApp.BO.Business
{
    public class CoreRules
    {
        public static int getBonus(int characValue)
        {
            return (int)Math.Floor((double)((characValue - 10) / 2));
        }
    }
}