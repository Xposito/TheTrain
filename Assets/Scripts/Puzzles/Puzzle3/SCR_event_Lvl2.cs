using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_event_Lvl2 : Evento
{
    public GameObject objetosPuzzle;
    public GameObject objetosModulos;
    public GameObject modulos;
    public GameObject animacionBow;
    public GameObject vagon;
    public GameObject camaraObjeto;
    public GameObject cartel;
    

    public GameObject controladorPuzles;

    bool estado_1;
    bool estado_2 = false;
    bool estado_3 = false;
    bool estado_4 = false;
    int objetosColocados = 0;

    public Animator animator, animatorMirror;

    public SCR_cam_takePhoto takePhoto;

    [Header("Sonidos")]
    public AudioSource doorSource;

    public AudioClip doorCloseSound;
    public AudioClip dooropenSound;


    private void Start()
    {
        objetosPuzzle.SetActive(false);
        modulos.SetActive(false);
        objetosModulos.SetActive(true);
        controladorPuzles.GetComponent<SCR_puz_Puzzle3_Controller_2>().enabled = false;
    }

    public SCR_event_Lvl2()
    {
        nombre = "Mision1";
    }

    public override void Iniciar()
    {
        base.Iniciar();
        // L�gica para iniciar la primera misi�n
        Invoke("MostrarDialogo", 1f); // Iniciar el di�logo despu�s de 5 segundos
    }


    // L�gica para mostrar el di�logo en un canvas
    private void MostrarDialogo()
    {
        

        estado_1 = true;


    }



    // L�gica para interactuar con el NPC
    public void CambioDeEstado()
    {
       
        if (estado_1 && !estado_2)
        {
            animator.SetBool("AbrirPuerta", true);
            doorSource.clip = doorCloseSound;
            doorSource.Play();
            objetosPuzzle.SetActive(true);            
            estado_2 = true;
        }
        else if (estado_2 && !estado_3)
        {
            controladorPuzles.GetComponent<SCR_puz_Puzzle3_Controller>().enabled = false;
            animacionBow.SetActive(true);
            takePhoto.enabled = false;

            StartCoroutine(EsperaAnimaci�n());
            estado_3 = true;
           

        }
        else if (estado_3 && !estado_4)
        {
            Debug.Log("Se acabo");
            modulos.SetActive(false);
            objetosModulos.SetActive(true);
            vagon.transform.position = new Vector3(15.84f, 0, 39.78f);
            takePhoto.enabled = true;
            camaraObjeto.SetActive(false);
            cartel.SetActive(true);

        }
        else if (estado_4)
        {
            animatorMirror.SetBool("AbrirPuerta", true);
            doorSource.clip = dooropenSound;
            doorSource.Play();
        }



    }

    public override void Completar()
    {
        // Verificar si se han completado todos los pasos de la misi�n
        if (estado_1)
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


    IEnumerator EsperaAnimaci�n()
    {
        yield return new WaitForSeconds(8.2f);

        animacionBow.SetActive(false);
        modulos.SetActive(true);
        objetosModulos.SetActive(false);
        controladorPuzles.GetComponent<SCR_puz_Puzzle3_Controller_2>().enabled = true;
    }
}
