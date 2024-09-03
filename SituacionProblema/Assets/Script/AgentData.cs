using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json; 

[System.Serializable]
public class AgentData
{
    public Dictionary<string, int> Agent_ID = new Dictionary<string, int>();
    public Dictionary<string, List<string>> Action_History = new Dictionary<string, List<string>>();

}
