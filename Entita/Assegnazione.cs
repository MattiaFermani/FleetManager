using System;
using System.Collections.Generic;
using System.Text;

namespace FleetManager.Entita
{
    public class Assegnazione
    {
        public DateTime DataInizio { get; set; }
        public DateTime? DataFine { get; set; }
        public string Targa { get; set; }
        public string Marca { get; set; }
        public string NomeModello { get; set; }

        public Assegnazione(DateTime dataInizio, DateTime? dataFine, string targa, string marca, string nomeModello)
        {
            DataInizio = dataInizio;
            DataFine = dataFine;
            Targa = targa;
            Marca = marca;
            NomeModello = nomeModello;
        }
    }
}
