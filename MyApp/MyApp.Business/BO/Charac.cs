namespace MyApp.BO.Business
{
    public class Charac
    {


        public string name { get; set; }
        public int value { get; set; }
        public int tempValue { get; set; }
        public int modificateur { get; set; }
        public int tempModificateur { get; set; }

        public Charac(string name, int value, int tempValue, int modificateur, int tempModificateur)
        {
            this.name = name;
            this.value = value;
            this.tempValue = tempValue;
            this.modificateur = modificateur;
            this.tempModificateur = tempModificateur;
        }
    }
}