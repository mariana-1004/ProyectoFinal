using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json; 

[System.Serializable]
public class GridData
{
    public Dictionary<int, List<List<float>>> Grid = new Dictionary<int, List<List<float>>>();
    public Dictionary<int, int> Steps = new Dictionary<int, int>();
    public Dictionary<int, Dictionary<string, bool>> Doors = new Dictionary<int, Dictionary<string, bool>>();
    public Dictionary<int, Dictionary<string, bool>> InterestPoints = new Dictionary<int, Dictionary<string, bool>>();
    public Dictionary<int, List<List<int>>> Fire = new Dictionary<int, List<List<int>>>();
    public Dictionary<int, int> Rescued = new Dictionary<int, int>();
    public Dictionary<int, string> Status = new Dictionary<int, string>();
    public Dictionary<int, int> Fatalities = new Dictionary<int, int>();
    public Dictionary<int, int> Damage = new Dictionary<int, int>();
}

