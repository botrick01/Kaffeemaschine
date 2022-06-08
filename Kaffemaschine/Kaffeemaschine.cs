using System.ComponentModel.DataAnnotations;

namespace Kaffemaschine
{
    public class Kaffeemaschine
    {
        [Key]
        public int Id { get; set; }
        public double Wasser { get; private set; }
        public double Kaffebohnen { get; private set; }
        public double GesamtMengeKaffeProduziert { get; private set; }

        public double Temperatur { get; private set; }

        private static double maxWasser = 2.5;
        private static double maxKaffebohnen = 2.5;

        public Kaffeemaschine (double Wasser = 0, double Kaffebohnen = 0, double GesamtMengeKaffeProduziert = 0, double Temperatur = 0)
        {
            this.Wasser = Wasser;
            this.Kaffebohnen = Kaffebohnen;
            this.GesamtMengeKaffeProduziert = GesamtMengeKaffeProduziert;
            this.Temperatur = Temperatur;
        }
        public double wasserAuffuellen(double menge)
        {
            if (Wasser + menge > maxWasser)
            {
                return Wasser;
            }
            else
            {
                Wasser += menge;
                return Wasser;
            }
        }

        public double bohnenAuffuellen(double menge)
        {
            if (Kaffebohnen + menge > maxKaffebohnen)
            {
                return Kaffebohnen;
            }
            else
            {
                Kaffebohnen += menge;
                return Kaffebohnen;
            }
        }

        public bool macheKaffee(double menge, double verhaeltnisWasserBohnen)
        {
            double mengeWasser = menge / (verhaeltnisWasserBohnen + 1) * verhaeltnisWasserBohnen;
            double mengeBohnen = menge - mengeWasser;

            if (mengeBohnen <= Kaffebohnen && mengeWasser <= Wasser)
            {
                Kaffebohnen -= mengeBohnen;
                Wasser -= mengeWasser;
                GesamtMengeKaffeProduziert += menge;
                return true;
            }
            return false;
        }
    }
}