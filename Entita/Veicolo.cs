using System;
using System.Collections.Generic;
using System.Text;

namespace FleetManager.Entita
{
    public class Veicolo
    {
        public string Targa { get; set; }
        public int FK_Modello { get; set; }
        public int AnnoProduzione { get; set; }
        public int Chilometraggio { get; set; }
        public string Stato { get; set; }

        public Veicolo(string Targa, int FK_Modello, int AnnoProduzione, int Chilometraggio, string Stato)
        {
            this.Targa = Targa;
            this.FK_Modello = FK_Modello;
            this.AnnoProduzione = AnnoProduzione;
            this.Chilometraggio = Chilometraggio;
            this.Stato = Stato;
        }
    }
}
