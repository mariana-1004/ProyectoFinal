using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // El transform del personaje
    public Vector3 offset = new Vector3(0, 2, -5); // La posición de la cámara relativa al personaje

    void Update()
    {
        // Actualizar la posición de la cámara en cada frame
        transform.position = target.position + offset;
        // Hacer que la cámara mire hacia el personaje
        transform.LookAt(target);
    }
}
