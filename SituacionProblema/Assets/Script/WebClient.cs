// TC2008B Modelación de Sistemas Multiagentes con gráficas computacionales
// C# client to interact with Python server via POST
// Sergio Ruiz-Loza, Ph.D. March 2021

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;


public class WebClient : MonoBehaviour
{
    public AgentData agentData;
    public GridData Grid;
    // IEnumerator - yield return
    IEnumerator SendData(string data)
    {
        WWWForm form = new WWWForm();
        form.AddField("bundle", "the data");
        string url = "http://localhost:8585";
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(data);
            www.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            //www.SetRequestHeader("Content-Type", "text/html");
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();          // Talk to Python
            if(www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                //Debug.Log(www.downloadHandler.text);    // Answer from Pythn
                string[] jsonParts = responseText.Split('\n');
                //Debug.Log(jsonParts[0]);
                //Debug.Log(jsonParts[1]);

                //agents = JsonConvert.DeserializeObject<AgentData>(jsonParts[0]);
                Grid = JsonConvert.DeserializeObject<GridData>(jsonParts[1]);
                //float firstValue = Grid.Grid[0][0][0];
                //Debug.Log(grid);





                // Imprimir cada parte de la respuesta
                /*for (int i = 0; i < jsonParts.Length; i++)
                {
                    Debug.Log("Part " + i + ": " + jsonParts[i]);
                }
                */

                // Deserializar los datos recibidos y almacenarlos en variables
                // agentData = JsonConvert.DeserializeObject<AgentData>(jsonParts[0]);
                agentData = JsonConvert.DeserializeObject<AgentData>(jsonParts[0]);

                // Imprimir los datos deserializados
                Debug.Log("Grid Data: " + JsonConvert.SerializeObject(Grid, Formatting.Indented));
                Debug.Log("Agent Data: " + JsonConvert.SerializeObject(agentData, Formatting.Indented));

            }

        }

    }


    // Start is called before the first frame update
    void Start()
    {
        // Iniciar la repetición de la función SendDataEveryTenSeconds cada 10 segundos
        InvokeRepeating("SendDataEveryNSeconds", 0f, 5f);
    }

    void SendDataEveryNSeconds()
    {
        Vector3 fakePos = new Vector3(3.44f, 0, -15.707f);
        string json = EditorJsonUtility.ToJson(fakePos);
        StartCoroutine(SendData(json));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}