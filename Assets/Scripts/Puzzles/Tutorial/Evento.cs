using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento : MonoBehaviour
{
    public string nombre;
    public bool completado;

    public virtual void Iniciar()
    {
        // Lógica para iniciar el evento/misión
    }

    public virtual void Completar()
    {
        // Lógica para marcar el evento/misión como completado
    }
}
