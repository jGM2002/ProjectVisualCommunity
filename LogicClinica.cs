using System;
using System.Collections.ObjectModel;

namespace proyecto
{
    public class LogicClinica
    {
        public ObservableCollection<Visita> llistaVis { get; set; }

        public LogicClinica() 
        {
            llistaVis = new ObservableCollection<Visita>();
            llistaVis.Add(new Visita("Mr. Nurgle", DateTime.Now.ToString(), "Sindrome de Nurgle"));
            llistaVis.Add(new Visita("Otro Paciente", DateTime.Now.ToString(), "Otro motivo"));
        }

        public void AfegirVisita(Visita novaVisita)
        {
            llistaVis.Add(novaVisita);
        }

        public void ModificarVisita(int posicio, Visita instanciaVisitaJaModificada)
        {
            if(posicio >= 0 && posicio < llistaVis.Count) 
            {
                llistaVis[posicio] = instanciaVisitaJaModificada;
            }
            else
            {
                Console.WriteLine("Posición no válida para modificar la visita.");
            }
        }
    }
}
