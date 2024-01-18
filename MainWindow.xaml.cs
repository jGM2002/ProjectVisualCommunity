using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace proyecto
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Visita> visitas;
        public MainWindow()
        {
            InitializeComponent();
            visitas = new ObservableCollection<Visita>();
            visitas.Add(new Visita { Pacient= "Pacient1", DataVisita= "01/01/2022", Motiu = "Motiu confidencial"});
            dataGrid.ItemsSource = visitas;
        }

        private void AfegirVisita_Click(object sender, RoutedEventArgs e)
        {
            AgregarVisitaWindow agregarVisitaWindow = new AgregarVisitaWindow();
            agregarVisitaWindow.ShowDialog();

            if(agregarVisitaWindow.VisitaNueva != null)
            {
                visitas.Add(agregarVisitaWindow.VisitaNueva);
            }
        }

        private void ModificarVisita_Click(object sender, RoutedEventArgs e)
        {
            if(dataGrid.SelectedItem != null)
            {
                Visita visitaSeleccionada = (Visita)dataGrid.SelectedItem;

                ModificarVisitaWindow modificarVisitaWindow = new ModificarVisitaWindow(visitaSeleccionada);
                modificarVisitaWindow.ShowDialog();

                if(modificarVisitaWindow.VisitaModificada != null)
                {
                    int index = visitas.IndexOf(visitaSeleccionada);
                    visitas[index] = modificarVisitaWindow.VisitaModificada;
                }
                else
                {
                    MessageBox.Show("Selecciona una visita para modificar.");
                }
            }
        }
    }
}
