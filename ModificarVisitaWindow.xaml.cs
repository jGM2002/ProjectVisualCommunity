using System;
using System.Windows;

namespace proyecto
{
    public partial class ModificarVisitaWindow : Window
    {
        public Visita VisitaModificada {  get; private set; }

        public ModificarVisitaWindow(Visita visita)
        {
            InitializeComponent();
            txtPacient.Text = visita.Pacient;
            txtDataVisita.Text = visita.DataVisita;
            txtMotiu.Text = visita.Motiu;
        }

        private void AplicarCanvis_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtPacient.Text) || string.IsNullOrWhiteSpace(txtDataVisita.Text) || string.IsNullOrWhiteSpace(txtMotiu.Text))
            {
                MessageBox.Show("Completa todos los campos");
                return;
            }

            VisitaModificada = new Visita
            {
                Pacient = txtPacient.Text,
                DataVisita = txtDataVisita.Text,
                Motiu = txtMotiu.Text
            };

            Close();
        }
    }
}
