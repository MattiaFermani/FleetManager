using System;
using System.Collections.Generic;
using System.Text;

namespace FleetManager.Entita
{
    public class Assegnazione
    {
        public int ID_Assegnazione { get; set; }
        public int FK_Veicolo { get; set; }
        public int FK_Guidatore { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime? DataFine { get; set; }

        public Assegnazione(int fK_Veicolo, int fK_Guidatore, DateTime dataInizio, DateTime? dataFine = null)
        {
            FK_Veicolo = fK_Veicolo;
            FK_Guidatore = fK_Guidatore;
            DataInizio = dataInizio;
            DataFine = dataFine;
        }
        public Assegnazione(int ID_Assegnazione, int fK_Veicolo, int fK_Guidatore, DateTime dataInizio, DateTime? dataFine = null)
        {
            this.ID_Assegnazione = ID_Assegnazione;
            FK_Veicolo = fK_Veicolo;
            FK_Guidatore = fK_Guidatore;
            DataInizio = dataInizio;
            DataFine = dataFine;
        }
        public Assegnazione()
        {

        }

    }
}
