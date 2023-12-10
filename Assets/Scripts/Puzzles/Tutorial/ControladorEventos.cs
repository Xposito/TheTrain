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

        // Iniciar la primera misi�n despu�s de 5 segundos
        Invoke("IniciarPrimeraMision", 0f);


        // Encontrar la primera misi�n en la lista de eventos
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

    //// Ejemplo de c�mo iniciar y completar eventos
    //Mision1 mision = new Mision1();
    //controlador.CompletarEvento(mision);


    // M�todo para completar un evento espec�fico
    public void CompletarEvento(Evento evento)
    {

        // Otras acciones que desees tomar al completar un evento


        // Aqu� puedes realizar otras acciones cuando se complete un evento
        if (evento.nombre == "Mision1")
        {
            //Busca la segunda misi�n y la inicia
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
    //    // Aqu� podr�as iniciar la tercera misi�n despu�s de completar la segunda
    //    if (terceraMision != null)
    //    {
    //        terceraMision.Iniciar();
    //    }
    //}

}
