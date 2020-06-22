using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flora : MonoBehaviour
{
    [System.Serializable]
    public struct growthStage
    {
        public int nextStage;
        public float variation;
        public GameObject model;
    };

    public growthStage[] stages;

    public int currStage;

    void Start()
    {
        currStage = 0;
    }
}
