using System.ComponentModel;

namespace proyecto
{
    public class Visita : INotifyPropertyChanged
    {
        private string pacient;
        private string dataVisita;
        private string motiu;

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
    }
}
