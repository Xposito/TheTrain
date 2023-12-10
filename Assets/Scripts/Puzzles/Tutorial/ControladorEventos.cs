using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class ControladorEventos : MonoBehaviour
{
    public List<Evento> eventosDisponibles = new List<Evento>();

    ControladorEventos controlador;
    private Tutorial primeraMision;
    







    void Start()
    {

        // Iniciar la primera misión después de 5 segundos
        Invoke("IniciarPrimeraMision", 0f);


        // Encontrar la primera misión en la lista de eventos
        foreach (Evento evento in eventosDisponibles)
        {
            if (evento.nombre == "Mision1" && evento is Tutorial)
            {
                primeraMision = (Tutorial)evento;
                break;
            }

            //else if (evento.nombre == "Mision2" && evento is Mision2)
            //{
            //    segundaMision = (Mision2)evento;
            //    break;
            //}


            //if (evento.nombre == "Mision2" && evento is Mision2)
            //{
            //    segundaMision = (Mision2)evento;
            //}
            //else if (evento.nombre == "Mision3" && evento is Mision3)
            //{
            //    terceraMision = (Mision3)evento;
            //}

        }


    }

    void IniciarPrimeraMision()
    {
        if (primeraMision != null)
        {
            primeraMision.Iniciar();
        }

        foreach (Evento evento in eventosDisponibles)
        {
            if (evento.nombre == "Mision1")
            {
                evento.Iniciar();
                break;
            }
        }
    }

    //// Ejemplo de cómo iniciar y completar eventos
    //Mision1 mision = new Mision1();
    //controlador.CompletarEvento(mision);


    // Método para completar un evento específico
    public void CompletarEvento(Evento evento)
    {

        // Otras acciones que desees tomar al completar un evento


        // Aquí puedes realizar otras acciones cuando se complete un evento
        if (evento.nombre == "Mision1")
        {
            //Busca la segunda misión y la inicia
            //foreach (Evento e in eventosDisponibles)
            //{

            //    if (e.nombre == "Mision2")
            //    {
            //        e.Iniciar();
            //        break;
            //    }
            //}
        }


    }


    //public void CompletarSegundaMision()
    //{
    //    // Aquí podrías iniciar la tercera misión después de completar la segunda
    //    if (terceraMision != null)
    //    {
    //        terceraMision.Iniciar();
    //    }
    //}

}
