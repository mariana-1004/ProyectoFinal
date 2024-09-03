using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    public GridData gridData;  // Asegúrate de que este esté asignado en el Inspector de Unity
    public List<GameObject> celdasExistentes;  // Lista de celdas que ya están en la escena

    public GameObject fantasmaBlancoPrefab; // Asigna el prefab del fantasma blanco en el Inspector
    public GameObject fantasmaRojoPrefab; // Asigna el prefab del fantasma rojo en el Inspector

    void Start()
    {
        string turno = "0"; // Por ejemplo, "0" es el turno que quieres usar. Cambia esto según sea necesario.

        if (gridData != null && celdasExistentes != null && celdasExistentes.Count > 0)
        {
            if (int.TryParse(turno, out int turnoInt) && gridData.Grid.ContainsKey(turnoInt))
            {
                // Interpretar la matriz correspondiente al turno actual
                ActualizarCeldas(gridData.Grid[turnoInt]);
            }
            else
            {
                Debug.LogError("El turno especificado no existe en GridData o no es un número válido.");
            }
        }
        else
        {
            Debug.LogError("GridData no está asignado o no hay celdas en la lista.");
        }
    }

    void ActualizarCeldas(List<List<float>> gridMatrix)
    {
        if (gridMatrix.Count * gridMatrix[0].Count != celdasExistentes.Count)
        {
            Debug.LogError("El número de celdas existentes no coincide con el tamaño de la matriz.");
            return;
        }

        int index = 0;
        for (int i = 0; i < gridMatrix.Count; i++)
        {
            for (int j = 0; j < gridMatrix[i].Count; j++)
            {
                float valor = gridMatrix[i][j];
                GameObject celda = celdasExistentes[index];
                ActualizarCelda(celda, valor);
                index++;
            }
        }
    }

    void ActualizarCelda(GameObject celda, float valor)
    {
        // Elimina cualquier objeto hijo existente en la celda
        foreach (Transform child in celda.transform)
        {
            Destroy(child.gameObject);
        }

        // Dependiendo del valor, instancia el fantasma correspondiente
        if (valor == 1)
        {
            Instantiate(fantasmaBlancoPrefab, celda.transform.position, Quaternion.identity, celda.transform);
        }
        else if (valor == 2)
        {
            Instantiate(fantasmaRojoPrefab, celda.transform.position, Quaternion.identity, celda.transform);
        }
        // Si valor es 3 o 4, no hacer nada (celda vacía)
    }
}




