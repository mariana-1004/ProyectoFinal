using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json; 

public class Tablero : MonoBehaviour
{
    public GridData gridData;  // Asegúrate de que este esté asignado en el Inspector de Unity
    public List<GameObject> celdasExistentes;  // Lista de celdas que ya están en la escena
    public GameObject fantasmaBlancoPrefab; // Asigna el prefab del fantasma blanco en el Inspector
    public GameObject fantasmaRojoPrefab; // Asigna el prefab del fantasma rojo en el Inspector
    
    void Start()
    {
        Debug.Log("Inicio de la función Start.");
        

        if (gridData == null)
        {
            Debug.LogWarning("GridData no está asignado. Se creará una nueva instancia de GridData.");
            gridData = new GridData(); 
        }
        else
        {
            Debug.Log("GridData está asignado correctamente.");
        }

        // Imprimir las llaves y sus tipos de dato
        foreach (var key in gridData.Grid.Keys)
        {
            Debug.Log($"Llave en GridData: {key} (Tipo: {key.GetType()})");
        }
        
        string turno = "0";  // Usar el turno como cadena directamente
        Debug.Log($"Turno seleccionado: {turno}");

        if (gridData != null && celdasExistentes != null && celdasExistentes.Count > 0)
        {
            Debug.Log("GridData y celdasExistentes están asignados y la lista de celdas tiene elementos.");

            // Verificar si la llave es una cadena y está en GridData
            if (gridData.Grid.ContainsKey(turno))
            {
                Debug.Log($"El turno {turno} existe en GridData. Actualizando celdas.");
                ActualizarCeldas(gridData.Grid[turno]);  // Usar la llave como cadena
            }
            else
            {
                Debug.LogError($"El turno especificado {turno} no existe en GridData. Las llaves disponibles son:");

                foreach (var key in gridData.Grid.Keys)
                {
                    Debug.Log($"Turno disponible en GridData: {key}");
                }
            }
        }
        else
        {
            Debug.LogError("GridData no está asignado o la lista de celdas existentes está vacía o es nula.");
        }
    }


    void ActualizarCeldas(List<List<float>> gridMatrix)
    {
        Debug.Log("Iniciando la actualización de celdas.");

        if (gridMatrix.Count * gridMatrix[0].Count != celdasExistentes.Count)
        {
            Debug.LogError($"El número de celdas existentes ({celdasExistentes.Count}) no coincide con el tamaño de la matriz ({gridMatrix.Count * gridMatrix[0].Count}).");
            return;
        }

        int index = 0;
        for (int i = 0; i < gridMatrix.Count; i++)
        {
            for (int j = 0; j < gridMatrix[i].Count; j++)
            {
                float valor = gridMatrix[i][j];
                Debug.Log($"Actualizando celda en índice {index} con valor {valor}.");
                
                GameObject celda = celdasExistentes[index];
                ActualizarCelda(celda, valor);
                index++;
            }
        }

        Debug.Log("Celdas actualizadas correctamente.");
    }

    void ActualizarCelda(GameObject celda, float valor)
    {
        Debug.Log($"Actualizando celda en posición {celda.transform.position} con valor {valor}.");

        // Elimina cualquier objeto hijo existente en la celda
        foreach (Transform child in celda.transform)
        {
            Debug.Log($"Eliminando objeto hijo: {child.gameObject.name}");
            Destroy(child.gameObject);
        }

        // Dependiendo del valor, instancia el fantasma correspondiente
        if (valor == 1)
        {
            Debug.Log("Instanciando fantasma blanco.");
            Instantiate(fantasmaBlancoPrefab, celda.transform.position, Quaternion.identity, celda.transform);
        }
        else if (valor == 2)
        {
            Debug.Log("Instanciando fantasma rojo.");
            Instantiate(fantasmaRojoPrefab, celda.transform.position, Quaternion.identity, celda.transform);
        }
        else
        {
            Debug.Log("Valor no corresponde a ningún fantasma. No se instancia nada.");
        }
    }
}
