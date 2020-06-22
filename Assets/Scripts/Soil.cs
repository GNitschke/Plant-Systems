using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{
    public TurnManager turnManager;

    public string name;
    public int growth;

    private GameObject plantObject;
    public Flora plant;

    public struct neighbors
    {
        public Soil up;
        public Soil left;
        public Soil right;
        public Soil down;
    };

    void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }

    public void Plant(string seed)
    {
        name = seed;
        growth = 0;
        plantObject = Instantiate(turnManager.currentPlant);
        plant = plantObject.GetComponent<Flora>();
    }

    public void Grow()
    {
        if(plantObject != null)
        {
            growth++;
            Flora.growthStage current = plant.stages[plant.currStage];
            if (plant.currStage < plant.stages.Length - 1 && growth >= current.nextStage && Random.Range(0, current.variation) > 0.5)
            {
                plant.currStage++;
                growth = 0;
            }
        }
    }
}
