using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_event_Lvl2 : Evento
{
    GameObject objetosPuzzle;
    GameObject objetosModulos;
    GameObject modulos;

    bool estado_1;
    bool estado_2 = false;
    bool estado_3 = false;
    int objetosColocados = 0;

    public Animator animator, animatorMirror;


    private void Start()
    {
        objetosPuzzle.SetActive(false);
        modulos.SetActive(false);
        objetosModulos.SetActive(true);   
    }

    public SCR_event_Lvl2()
    {
        nombre = "Mision1";
    }

    public override void Iniciar()
    {
        base.Iniciar();
        // Lógica para iniciar la primera misión
        Invoke("MostrarDialogo", 1f); // Iniciar el diálogo después de 5 segundos
    }


    // Lógica para mostrar el diálogo en un canvas
    private void MostrarDialogo()
    {
        

        estado_1 = true;


    }



    // Lógica para interactuar con el NPC
    public void CambioDeEstado()
    {
       
        if (estado_1 && !estado_2)
        {
            objetosPuzzle.SetActive(true) ;
            estado_2 = true;
        }
        else if (estado_2 && !estado_3)
        {
            objetosPuzzle.SetActive(false);
            objetosModulos.SetActive(false);
            modulos.SetActive(true );
        }


    }

    public override void Completar()
    {
        // Verificar si se han completado todos los pasos de la misión
        if (estado_1)
        {

            completado = true;
            Debug.Log("Primera misión completada");

        }
        else
        {
            Debug.Log("Primera misión aún no completada. Asegúrate de seguir los pasos.");
        }


        //base.Completar();
        // Lógica adicional si es necesaria
        // Luego, se llama al controlador de eventos para indicar que esta misión se ha completado
        GameObject.FindGameObjectWithTag("GameController").GetComponent<ControladorEventos>().CompletarEvento(this);

    }
}
