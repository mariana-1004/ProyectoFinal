using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agente : MonoBehaviour
{
    public WebClient webClient;
    public List<GameObject> personajes;  // Lista de personajes que se moverán
    
    public int agente=0;
   /* public GameObject ghostb;
    public GameObject ghostb2;
    public GameObject ghostb3;
    public GameObject ghostb4;
    public GameObject ghostb5;
    public GameObject ghostb6; */



    void Start()
    {
        // Empezamos la rutina de actualización cada 5 segundos
        StartCoroutine(ActualizarPosiciones());
    }

    // Coroutine para actualizar posiciones cada 5 segundos
    IEnumerator ActualizarPosiciones()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);  // Pausa de 5 segundos
            ActualizarPersonajes();
        }
    }


    void ActualizarPersonajes()
    {
        // Recorremos todos los personajes y aplicamos sus posiciones
        for (int i = 0; i < personajes.Count; i++)
        {
            string key = $"(0, {i})";  // Usamos el turno 0, y el índice representa el personaje
            if (webClient.agentData.Position.ContainsKey(key))  // Usar agentData desde WebClient
            {
                List<int> coordenadas = webClient.agentData.Position[key];
                Vector2 nuevaPosicion = new Vector2(coordenadas[0], coordenadas[1]);
                MoverPersonaje(personajes[i], nuevaPosicion);
            }
        }
    }

    void MoverPersonaje(GameObject personaje, Vector2 posicion)
    {
        // Actualizamos la posición del personaje en el mundo de Unity
        personaje.transform.position = new Vector3(posicion.x, personaje.transform.position.y, posicion.y);
        Debug.Log($"Moviendo personaje a nueva posición: {posicion.x}, {posicion.y}");
    }
}
