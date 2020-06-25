using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flora : Item
{
    [System.Serializable]
    public struct growthStage
    {
        public int nextStage;
        public float variation;
        public GameObject model;
    };

    //public string name;

    public growthStage[] stages;

    public int currStage = 0;
}
