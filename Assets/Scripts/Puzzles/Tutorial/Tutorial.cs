using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : Evento
{
    public bool animacion1;
    public bool primeraCampana;
    public bool fotoElefante;
    public bool segundaCampana;
    public bool campanaColocada;
    public bool terceraCampana;

    public GameObject camara1;
    public GameObject player;

    [Header("ObjetosParte1")]
    public Animator animator1;
    public GameObject elefante;
    [Header("ObjetosParte2")]
    public Animator animator2;
    public GameObject campanaNo;
    public GameObject campanaYes;

    [Header("ObjetosParte3")]
    public GameObject campanaInteractuable;
    public GameObject campanaHolder;

    [Header("TrigeerFinal")]
    public GameObject cambioEscena;
    

    public Tutorial()
    {
        nombre = "Mision1";
    }

    public override void Iniciar()
    {
        base.Iniciar();
        // L�gica para iniciar la primera misi�n
        Invoke("MostrarDialogo", 5f); // Iniciar el di�logo despu�s de 5 segundos
    }


    // L�gica para mostrar el di�logo en un canvas
    private void MostrarDialogo()
    {
       
        player.SetActive(true);
        animacion1 = true;


    }
   


    // L�gica para interactuar con el NPC
    public void CambioDeEstado()
    {
        if (animacion1 && !primeraCampana)
        {
            elefante.SetActive(true);
            animator1.SetBool("AbrirPuerta", true);
            primeraCampana = true;

        }
        else if (primeraCampana && !fotoElefante)
        {
            campanaNo.SetActive(false);
            campanaYes.SetActive(true);
            fotoElefante = true;
        }
        else if (fotoElefante && !segundaCampana)
        {
            animator2.SetBool("NoAbre", true);
            elefante.SetActive(false) ;
            animator1.SetBool("AbrirPuerta", false);
            campanaInteractuable.SetActive(true);
            campanaHolder.SetActive(true);
            segundaCampana = true;
            
        }
        else if (segundaCampana && !campanaColocada)
        {
            
            campanaColocada = true;

        }
        else if(campanaColocada && !terceraCampana)
        {
            animator1.SetBool("AbrirPuerta", true);
            cambioEscena.SetActive(true);

            Completar();
        }
    }

    public override void Completar()
    {
        // Verificar si se han completado todos los pasos de la misi�n
        if (animacion1 && primeraCampana && fotoElefante)
        {
            
            completado = true;
            Debug.Log("Primera misi�n completada");
            
        }
        else
        {
            Debug.Log("Primera misi�n a�n no completada. Aseg�rate de seguir los pasos.");
        }


        //base.Completar();
        // L�gica adicional si es necesaria
        // Luego, se llama al controlador de eventos para indicar que esta misi�n se ha completado
        GameObject.FindGameObjectWithTag("GameController").GetComponent<ControladorEventos>().CompletarEvento(this);

    }
}
