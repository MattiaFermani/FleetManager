using System;
using System.Collections.Generic;
using System.Text;

namespace FleetManager.Entita
{
    public class Assegnazione
    {
        string FK_Veicolo { get; set; }
        string FK_Guidatore { get; set; }
        DateTime DataInizio { get; set; }
        DateTime? DataFine { get; set; }

        public Assegnazione(string fK_Veicolo, string fK_Guidatore, DateTime dataInizio, DateTime? dataFine)
        {
            FK_Veicolo = fK_Veicolo;
            FK_Guidatore = fK_Guidatore;
            DataInizio = dataInizio;
            DataFine = dataFine;
        }
    }
}
