using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento : MonoBehaviour
{
    public string nombre;
    public bool completado;

    public virtual void Iniciar()
    {
        // L�gica para iniciar el evento/misi�n
    }

    public virtual void Completar()
    {
        // L�gica para marcar el evento/misi�n como completado
    }
}
