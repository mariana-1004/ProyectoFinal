using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // El transform del personaje
    public Vector3 offset = new Vector3(0, 2, -5); // La posici�n de la c�mara relativa al personaje

    void Update()
    {
        // Actualizar la posici�n de la c�mara en cada frame
        transform.position = target.position + offset;
        // Hacer que la c�mara mire hacia el personaje
        transform.LookAt(target);
    }
}
