using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    public GridData gridData;
    private List<List<float>> matrizActual; // Variable para almacenar la matriz actual
    // Start is called before the first frame update
    void Start()
    {
        // Llama al método para almacenar una matriz específica
        almacenarMatriz(0); // Por ejemplo, guarda la matriz correspondiente al turno 2
    }
    
    void almacenarMatriz(int turno)
    {
        if (gridData.Grid.ContainsKey(turno))
        {

            // Almacena la matriz correspondiente al turno especificado
            matrizActual = gridData.Grid[turno];

            // Imprime la matriz completa para verificar (opcional)
            for (int i = 0; i < matrizActual.Count; i++)
            {
                string row = "";
                for (int j = 0; j < matrizActual[i].Count; j++)
                {
                    row += matrizActual[i][j] + " ";
                }
                Debug.Log(row); // Muestra cada fila de la matriz en la consola
            }
        }
        else
        {
            Debug.Log("No se pudo, suerte para la proxima");
        }
    }
    
}
