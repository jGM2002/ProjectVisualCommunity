using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace proyecto
{
    public partial class MainWindow : Window
    {
        private LogicClinica logicClinica;

        public MainWindow()
        {
            InitializeComponent();
            logicClinica = new LogicClinica();
            dataGrid.ItemsSource = logicClinica.llistaVis;
        }

        private void AfegirVisita_Click(object sender, RoutedEventArgs e)
        {
            AgregarVisitaWindow agregarVisitaWindow = new AgregarVisitaWindow();
            agregarVisitaWindow.ShowDialog();

            if(agregarVisitaWindow.VisitaNueva != null)
            {
                logicClinica.AfegirVisita(agregarVisitaWindow.VisitaNueva);
            }
        }

        private void ModificarVisita_Click(object sender, RoutedEventArgs e)
        {
            if(dataGrid.SelectedItem != null)
            {
                Visita visitaAMod = (Visita)dataGrid.SelectedItem;
                int posicioAMod = dataGrid.SelectedIndex;

                ModificarVisitaWindow winSec = new ModificarVisitaWindow((Visita)visitaAMod.Clone(), logicClinica, posicioAMod);
                winSec.ShowDialog();

                if(winSec.visita != null)
                {
                    logicClinica.ModificarVisita(posicioAMod, winSec.visita);
                }
                else
                {
                    MessageBox.Show("Selecciona una visita para modificar.");
                }
            }
        }
    }
}
