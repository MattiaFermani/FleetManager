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
    }
}
