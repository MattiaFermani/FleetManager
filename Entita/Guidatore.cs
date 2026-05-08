using System;
using System.Collections.Generic;
using System.Text;

namespace FleetManager.Entita
{
    public class Guidatore
    {
        public int ID_Guidatore { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public DateTime ScadenzaPatente { get; set; }

        public string Stato
        {
            get
            {
                if (ScadenzaPatente.Date < DateTime.Now.Date)
                    return "SOSPESO (Scaduta)";
                if (ScadenzaPatente.Date <= DateTime.Now.Date.AddDays(30))
                    return "IN SCADENZA";

                return "ATTIVO";
            }
        }
    }
}
