using Android.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyApp.Common;

namespace MyApp.BO.Business
{
    public class CharacterSheet
    {
        public string Nom { get; set; }
        public int Age { get; set; }
        public int NiveauGlobal { get; set; }
        public string Taille { get; set; }
        public string ClasseActuelle { get; set; }
        public string Race { get; set; }
        public string Alignement { get; set; }
        public string Divinité { get; set; }
        public string TailleCategorie { get; set; }
        public Image Portrait { get; set; }

        public int ClasseArmure { get; set; }

        public int PVMax { get; set; }
        public int TempPVMax { get; set; }
        public int PVActuel { get; set; }

        public List<Charac> Characs { get; set; }

        public Dictionary<int,Attaque> Attaques { get; set; }
        public List<Tuple<Arme,Attaque>> AttaqueArme { get; set; }
        public Dictionary<string, int> CompetenceInnee  { get; set; }
        public Dictionary<string, int> CompetenceNonInnee { get; set; }

        public int Reflex { get; set; }
        public int TempReflex { get; set; }

        public int Vigueur { get; set; }
        public int TempVigueur { get; set; }

        public int Volonte { get; set; }
        public int TempVolonte { get; set; }

        public int BonusInit { get; set; }
        public int RM { get; set; }

        public List<Arme> ArmeEquipe { get; set; }
        public List<Equipement> Equipements { get; set; }
        public List<string> Langues { get; set; }

        public List<Don> Dons { get; set; }

        public int simpleAttackRoll(Arme ar, Attaque at , int attaqueBonus=0 )
        {
            int force = Characs.Where(x=>x.name == Constants.characteristics.Force).FirstOrDefault().tempValue;
            int characBonus = CoreRules.getBonus(force);
            return new Random().Next(1, 20) + characBonus + at.BonusBase + ar.BonusAttaque + attaqueBonus;                
        }

        public List<int> fullAttackRoll(int attaqueBonus = 0)
        {
            List<int> res = new List<int>();

            foreach (Tuple<Arme, Attaque> item in AttaqueArme)
            {
                res.Add(simpleAttackRoll(item.Item1, item.Item2, attaqueBonus));
            }

            return res;
        }

        public static bool save()
        {

            return true;
        }

        public static CharacterSheet Load()
        {
            CharacterSheet cs = new CharacterSheet();

            int force = 18;
            int dex = 18;
            int constit = 18;
            int intel = 18;
            int sag = 18;
            int cha = 18;

            cs.Nom = "Bob";
            cs.NiveauGlobal = 1;
            cs.Age = 32;
            cs.Alignement = "Chaotique Bon";
            cs.BonusInit = 3;
            cs.ClasseActuelle = "Guerrier";
            cs.Taille = "1m80";
            cs.TailleCategorie = "M";
            cs.TempPVMax = 0;
            cs.TempReflex = 0;
            cs.TempVigueur = 0;
            cs.TempVolonte = 0;
            cs.Reflex = 1;
            cs.Volonte = 2;
            cs.Vigueur = 3;

            cs.CompetenceInnee = new Dictionary<string, int>();
            cs.CompetenceInnee.Add("Saut",2);
            cs.CompetenceInnee.Add("Natation", 2);

            cs.CompetenceNonInnee = new Dictionary<string, int>();
            cs.CompetenceNonInnee.Add("Intimidation", 3);

            cs.Characs = new List<Charac>();
            cs.Characs.Add(new Charac(Constants.characteristics.Force, force, force, CoreRules.getBonus(force), CoreRules.getBonus(force)));
            cs.Characs.Add(new Charac(Constants.characteristics.Dext, dex, dex, CoreRules.getBonus(dex), CoreRules.getBonus(dex)));
            cs.Characs.Add(new Charac(Constants.characteristics.Const, constit, constit, CoreRules.getBonus(constit), CoreRules.getBonus(constit)));
            cs.Characs.Add(new Charac(Constants.characteristics.Int, intel, intel, CoreRules.getBonus(intel), CoreRules.getBonus(intel)));
            cs.Characs.Add(new Charac(Constants.characteristics.Sag, sag, sag, CoreRules.getBonus(sag), CoreRules.getBonus(sag)));
            cs.Characs.Add(new Charac(Constants.characteristics.Cha, cha, cha, CoreRules.getBonus(cha), CoreRules.getBonus(cha)));

            Arme epee = new Arme();
            epee.BonusAttaque = 0;
            epee.BonusDegat = 0;
            epee.Nom = "Epée a une main";
            epee.Quantite = 1;

            Attaque at1 = new Attaque();
            at1.BonusBase = 6;

            Attaque at2 = new Attaque();
            at2.BonusBase = 2;
            cs.ArmeEquipe = new List<Arme>();
            cs.AttaqueArme = new List<Tuple<Arme, Attaque>>();
            cs.Attaques = new Dictionary<int, Attaque>();
            cs.ArmeEquipe.Add(epee);
            cs.Attaques.Add(1,at1);
            cs.Attaques.Add(2,at2);
            cs.ClasseArmure = 25;
            cs.Divinité = "Heroneous";
            cs.Race = "Humain";
            cs.PVMax = 150;
            cs.PVActuel = 100;
            cs.TempPVMax = 10;
            cs.RM = 20;
            return cs;
        }


    }
}
