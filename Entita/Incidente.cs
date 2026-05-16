using System;
using System.Collections.Generic;
using System.Text;

namespace FleetManager.Entita
{
    public class Incidente
    {
        public int ID_Incidente { get; set; }
        public int FK_Veicolo { get; set; }
        public int FK_Guidatore { get; set; }
        public DateTime DataIncidente { get; set; }
        public string DescrizioneDanni { get; set; }

        public Incidente(int fK_Veicolo, int fK_Guidatore, DateTime dataIncidente, string descrizioneDanni)
        {
            FK_Veicolo = fK_Veicolo;
            FK_Guidatore = fK_Guidatore;
            DataIncidente = dataIncidente;
            DescrizioneDanni = descrizioneDanni;
        }

        public Incidente(int ID_Incidente, int fK_Veicolo, int fK_Guidatore, DateTime dataIncidente, string descrizioneDanni)
        {
            this.ID_Incidente = ID_Incidente;
            FK_Veicolo = fK_Veicolo;
            FK_Guidatore = fK_Guidatore;
            DataIncidente = dataIncidente;
            DescrizioneDanni = descrizioneDanni;
        }
    }
}
