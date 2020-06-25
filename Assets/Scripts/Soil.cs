using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{
    public TurnManager turnManager;

    //public string name;
    public int growth;

    private GameObject plantObject;
    private GameObject currentStageObject;
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
        plantObject = null;
        plant = null;
    }

    public int Use(GameObject toBeUsed)
    {
        if (plantObject == null && toBeUsed.GetComponent<Flora>() != null)
        {
            Debug.Log("Planted");
            //name = item;
            growth = 0;
            plantObject = Instantiate(toBeUsed);
            plant = plantObject.GetComponent<Flora>();
            currentStageObject = Instantiate(plant.stages[plant.currStage].model, transform);
            toBeUsed.GetComponent<Item>().energyRequired = plant.currStage;
        }
        else if(toBeUsed.GetComponent<Tool>() != null)
        {
            if (toBeUsed.name == "Shovel" && plantObject != null)
            {
                Debug.Log("Ripped up");
                toBeUsed.GetComponent<Item>().energyRequired = plant.currStage;
                Destroy(plantObject);
                Destroy(currentStageObject);
                plantObject = null;
                plant = null;
            }
            else
            {
                Debug.Log(toBeUsed.name + " cannot be used here.");
                return 0;
            }
        }
        else
        {
            Debug.Log("Not a valid item to use");
            return 0;
        }

        return toBeUsed.GetComponent<Item>().energyRequired;
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
                Destroy(currentStageObject);
                currentStageObject = Instantiate(plant.stages[plant.currStage].model, transform);
                growth = 0;
            }
        }
    }
}
