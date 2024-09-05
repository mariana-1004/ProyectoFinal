using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class OtherScript : MonoBehaviour
{

    // Prefab del NPC
    public GameObject espiritu;
    public GameObject fantasma;
    public GameObject cazafantasma;
    public GameObject victima;

    // Posición donde se generará el NPC
    //public Vector3 npcPosition;

    // Rotación del NPC
    public Quaternion npcRotation;

    public float lifeTime = 5.0f;

    //public Vector3 positionOffset = Vector3.zero;

    void Start()
    {
        WebClient.OnGridDataReceived += OnGridDataReceived;
        //WebClient webClient = WebClient.instance;
        //AgentData agentData = webClient.agentData;
        //GridData grid = webClient.Grid;
    }
    // Use the variables as needed
    void OnGridDataReceived(GridData grid)
    {
        foreach (var key in grid.Grid.Keys)
        {
            // Verificar que la clave no sea "0"
            if (key != "100")
            {
                List<List<float>> gridValues = grid.Grid[key];
                for (int rowIndex = 0; rowIndex < gridValues.Count; rowIndex++)
                {
                    List<float> row = gridValues[rowIndex];
                    for (int colIndex = 0; colIndex < row.Count; colIndex++)
                    {
                        float value = row[colIndex];
                        if (value == 1.0f)
                        {
                            Vector3 npcPosition = new Vector3(10.85f + rowIndex * 4, 0f, 14.14f + colIndex *4);
                            GameObject instanceEspiritu = Instantiate(espiritu, npcPosition, npcRotation);
                            //Debug.Log("Espiritu en : (" + rowIndex + ", " + colIndex + ")");
                            Destroy(instanceEspiritu, lifeTime);
                        }
                        else if (value == 2.0f)
                        {
                            Vector3 npcPosition = new Vector3(10.54f + rowIndex * 4, 0f, 14.14f + colIndex * 4);
                            GameObject instanceFantasma = Instantiate(fantasma, npcPosition, npcRotation);
                            //Debug.Log("Fantasma en : (" + rowIndex + ", " + colIndex + ")");
                            Destroy(instanceFantasma, lifeTime);
                        }
                        else if (value == 3.0f)
                        {
                            Vector3 npcPosition = new Vector3(12.59f + rowIndex * 4, 0f, 13.64f + colIndex * 4);
                            Quaternion npcRotation = Quaternion.Euler(0f, -90f, 0f);
                            GameObject instanceCazafantasma = Instantiate(cazafantasma, npcPosition, npcRotation);
                            //Debug.Log("Cazafantasma en : (" + rowIndex + ", " + colIndex + ")");
                            Destroy(instanceCazafantasma, lifeTime);
                        }
                        else if (value == 4.0f)
                        {
                            Vector3 npcPosition = new Vector3(11.58f + rowIndex * 4, 0, 15.08f + colIndex * 4);
                            GameObject instanceVictima = Instantiate(victima, npcPosition, npcRotation);
                            //Debug.Log("Victima en : (" + rowIndex + ", " + colIndex + ")");
                            Destroy(instanceVictima, lifeTime);
                        }
                    }
                }
            }
        }
    }
}