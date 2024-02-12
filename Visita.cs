using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace proyecto
{
    public class Visita : INotifyPropertyChanged, ICloneable
    {
        private string pacient;
        private string dataVisita;
        private string motiu;
        private List<string> erroresPosibles = new List<string>();
        public List<string> ErroresPosibles => erroresPosibles;
        private List<string> erroresActuales = new List<string>();
        public List<string> ErroresActuales => erroresActuales;

        public Visita(string pacient, string dataVisita, string motiu)
        {
            this.pacient = pacient;
            this.dataVisita = dataVisita;
            this.motiu = motiu;
        }

        public Visita()
        {
            this.pacient = "";
            this.dataVisita = DateTime.Now.ToString();
            this.motiu = "";
        }

        public string Pacient
        {
            get { return pacient; }
            set
            {
                if(pacient != value)
                {
                    pacient = value;
                    OnPropertyChanged(nameof(Pacient));
                }
            }
        }

        public string DataVisita
        {
            get { return dataVisita; }
            set
            {
                if(dataVisita != value)
                {
                    dataVisita = value;
                    OnPropertyChanged(nameof (DataVisita));
                }
            }
        }

        public string Motiu
        {
            get { return motiu; }
            set
            {
                if(motiu != value)
                {
                    motiu = value;
                    OnPropertyChanged(nameof(Motiu));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public string Error => null;

        public string this[string columnName]
        {
            get 
            {
                string result = "";

                switch (columnName) 
                {
                    case "Pacient":
                        if (string.IsNullOrWhiteSpace(Pacient))
                        {
                            result = "El campo Paciente es obligatorio.";
                        }
                        break;
                    case "DataVisita":
                        if (string.IsNullOrWhiteSpace(DataVisita))
                        {
                            result = "El campo Fecha Visita es obligatorio.";
                        }
                        break;
                    case "Motiu":
                        if (string.IsNullOrWhiteSpace(Motiu))
                        {
                            result = "El campo Motivo es obligatorio.";
                        }
                        break;
                    default:
                        break;
                }

                erroresPosibles.Clear();
                foreach(var propertyName in new[] {"Pacient", "DataVisita", "Motiu"})
                {
                    erroresPosibles.Add(this[propertyName]);
                }

                erroresActuales.Clear();
                foreach(var error in erroresPosibles)
                {
                    if (string.IsNullOrWhiteSpace(error))
                    {
                        erroresActuales.Add(error);
                    }
                }

                return result;
            }
        }
    }
}
