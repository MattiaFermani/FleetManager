using System;
using System.Collections.Generic;
using System.Text;

namespace FleetManager.Entita
{
    public class Manutenzione
    {
        public int ID_Manutenzione { get; set; }
        public int FK_Veicolo { get; set; }
        public DateTime DataIntervento { get; set; }
        public decimal Costo { get; set; }
        public string Descrizione { get; set; }

        public Manutenzione(int fK_Veicolo, DateTime dataIntervento, decimal costo, string descrizione)
        {
            FK_Veicolo = fK_Veicolo;
            DataIntervento = dataIntervento;
            Costo = costo;
            Descrizione = descrizione;
        }
        public Manutenzione(int ID_Manutenzione, int fK_Veicolo, DateTime dataIntervento, decimal costo, string descrizione)
        {
            this.ID_Manutenzione = ID_Manutenzione;
            FK_Veicolo = fK_Veicolo;
            DataIntervento = dataIntervento;
            Costo = costo;
            Descrizione = descrizione;
        }
    }
}
