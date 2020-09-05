using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Flora : Item
{
    [System.Serializable]
    public struct growthStage
    {
        public int nextStage;
        public GameObject model;
        public float sunNeeded;
        public float waterUsage;
    };
 
    //public string name;

    public growthStage[] stages;

    public int currStage = 0;
}
