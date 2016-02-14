using System;

namespace MyApp.BO.Business
{
    public class Arme: Equipement
    {
        public int BonusAttaque { get; set; }
        public int BonusDegat { get; set; }
        public Tuple<int,int> xDy { get; set; } // exemple : 1D6
    }
}