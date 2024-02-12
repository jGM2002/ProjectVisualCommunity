using System;
using System.Windows;

namespace proyecto
{
    public partial class AgregarVisitaWindow : Window
    {
        public Visita VisitaNueva { get; private set; }

        public AgregarVisitaWindow()
        {
            InitializeComponent();
        }

        private void AfegirVisita_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtPacient.Text) || string.IsNullOrWhiteSpace(txtDataVisita.Text) || string.IsNullOrWhiteSpace(txtMotiu.Text))
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }

            VisitaNueva = new Visita
            {
                Pacient = txtPacient.Text,
                DataVisita = txtDataVisita.Text,
                Motiu = txtMotiu.Text,
            };

            Close();
        }
        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
