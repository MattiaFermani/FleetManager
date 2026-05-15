using FleetManager.DB;
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

        private string _stato;
        public string Stato
        {
            get
            {
                string statoCalcolato;

                if (ScadenzaPatente < DateTime.Today)
                    statoCalcolato = "SOSPESO (Scaduta)";
                else if (ScadenzaPatente < DateTime.Today.AddMonths(1))
                    statoCalcolato = $"IN SCADENZA ({(ScadenzaPatente - DateTime.Today).Days} giorni)";
                else
                    statoCalcolato = "ATTIVO";

                if (_stato != statoCalcolato && ID_Guidatore > 0)
                {
                    _stato = statoCalcolato;
                    MethodsDB.AggiornaStatoGuidatore(ID_Guidatore, statoCalcolato);
                }

                return _stato;
            }
            set
            {
                _stato = value;
            }
        }

        public Guidatore(int Id_Guidatore, string Nome, string Cognome, string CodiceFiscale, DateTime ScadenzaPatente, string Stato)
        {
            this.ID_Guidatore = Id_Guidatore;
            this.Nome = Nome;
            this.Cognome = Cognome;
            this.CodiceFiscale = CodiceFiscale;
            this.ScadenzaPatente = ScadenzaPatente;
            this._stato = Stato;
        }
    }
}
