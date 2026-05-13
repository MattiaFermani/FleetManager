using System;
using System.Collections.Generic;
using System.Text;

namespace FleetManager.Classi
{
    public class AssegnazioneTabellaDTO
    {
        public int ID_Assegnazione { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime? DataFine { get; set; }
        public string Targa { get; set; }
        public string Marca { get; set; }
        public string NomeModello { get; set; }

        public AssegnazioneTabellaDTO() { }
    }
}
