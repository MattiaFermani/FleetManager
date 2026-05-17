using FleetManager.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace FleetManager.Entita
{
    public class Veicolo
    {
        public int ID_Veicolo { get; set; }
        public string Targa { get; set; }
        public int FK_Modello { get; set; }
        public int AnnoProduzione { get; set; }
        public int Chilometraggio { get; set; }
        private string _stato;
        public string Stato {
            get
            {
                if(Assegnazioni.Exists(x => x.DataFine == null))
                {
                    MethodsDB.AggiornaVeicolo(ID_Veicolo, stato: "In Uso");
                    return "In Uso";
                }
                else 
                { 
                    MethodsDB.AggiornaVeicolo(ID_Veicolo, stato: "Disponibile");
                    return "Disponibile";
                }
            }
            set { _stato = value; }
        }
        private List<Assegnazione> Assegnazioni
        {
            get { return MethodsDB.GetAssegnazioniByVeicolo(ID_Veicolo); }
        }

        public Veicolo(string Targa, int FK_Modello, int AnnoProduzione, int Chilometraggio, string Stato)
        {
            this.Targa = Targa;
            this.FK_Modello = FK_Modello;
            this.AnnoProduzione = AnnoProduzione;
            this.Chilometraggio = Chilometraggio;
            this.Stato = Stato;
        }

        public string Marca { get; set;  }
        public string NomeModello { get; set; }


        public Veicolo(int ID_Veicolo, string Targa, string Marca, string NomeModello, int AnnoProduzione, int Chilometraggio, string Stato)
        {
            this.ID_Veicolo = ID_Veicolo;
            this.Targa = Targa;
            this.Marca = Marca;
            this.NomeModello = NomeModello;
            this.AnnoProduzione = AnnoProduzione;
            this.Chilometraggio = Chilometraggio;
            this.Stato = Stato;
        }
    }
}
