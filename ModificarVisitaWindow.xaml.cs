using System;
using System.Windows;
using System.Windows.Controls;

namespace proyecto
{
    public partial class ModificarVisitaWindow : Window
    {
        private LogicClinica logicClinica;
        private int posicion;
        private bool modificar;
        public Visita visita;
        private int numError = 0;

        public ModificarVisitaWindow(LogicClinica logicClinica)
        {
            InitializeComponent();
            this.logicClinica = logicClinica;
            modificar = false;
            DataContext = new Visita();
        }

        public ModificarVisitaWindow(Visita visita, LogicClinica logic, int pos)
        {
            InitializeComponent();
            this.logicClinica = logic;
            this.visita = visita;
            this.posicion = pos;
            DataContext = visita;
            modificar = true;
        }

        private void AplicarCanvis_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtPacient.Text) || string.IsNullOrWhiteSpace(txtDataVisita.Text) || string.IsNullOrWhiteSpace(txtMotiu.Text))
            {
                MessageBox.Show("Completa todos los campos");
                return;
            }

            if(!modificar)
            {
                logicClinica.AfegirVisita((Visita)DataContext);
            }
            else
            {
                logicClinica.ModificarVisita(posicion, (Visita)DataContext);
            }

            Close();
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if(e.Action == ValidationErrorEventAction.Added)
            {
                numError++;
            }
            else if(e.Action == ValidationErrorEventAction.Removed)
            {
                numError--;
            }

            btnAplicarCanvis.IsEnabled = (numError == 0);

            lblErrorPacient.Content = "";
            foreach(var error in visita.ErroresActuales)
            {
                lblErrorPacient.Content += error + "\n";
            }

            lblErrorDataVisita.Content = "";
            foreach(var error in visita.ErroresActuales)
            {
                lblErrorDataVisita.Content += error + "\n";
            }

            lblErrorMotiu.Content = "";
            foreach(var error in visita.ErroresActuales)
            {
                lblErrorMotiu.Content += error + "\n";
            }
        }
    }
}
