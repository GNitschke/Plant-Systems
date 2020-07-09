using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{
    public TurnManager turnManager;
    public int[] index;

    //public string name;
    public int growth;

    public float shade;
    public bool fertilized;
    public float water;


    private GameObject plantObject;
    private GameObject currentStageObject;
    public Flora plant;

    /*
    [System.Serializable]
    public struct neighbors
    {
        public Soil up;
        public Soil left;
        public Soil right;
        public Soil down;
    };
    */
    //neighbors[left, right, up, down]
    public Soil[] neighbors;

    void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        plantObject = null;
        plant = null;
    }

    public int Use(GameObject toBeUsed, bool check)
    {
        if (toBeUsed != null)
        {
            if (plantObject == null && toBeUsed.GetComponent<Flora>() != null)
            {
                if (!check)
                {
                    Debug.Log("Planted");
                    growth = 0;
                    plantObject = Instantiate(toBeUsed, transform);
                    plant = plantObject.GetComponent<Flora>();
                    currentStageObject = Instantiate(plant.stages[plant.currStage].model, transform.position, Quaternion.Euler(0, Random.Range(0.0f, 360.0f), 0));
                }
                toBeUsed.GetComponent<Item>().energyRequired = toBeUsed.GetComponent<Flora>().currStage + 1;
            }
            else if (toBeUsed.GetComponent<Tool>() != null)
            {
                if (toBeUsed.name == "Gloves" && plantObject != null)
                {
                    toBeUsed.GetComponent<Item>().energyRequired = (int)Mathf.Floor((plant.currStage) * 0.5f) + 1;
                    if (!check)
                    {
                        Debug.Log("Ripped up");
                        Destroy(plantObject);
                        Destroy(currentStageObject);
                        plantObject = null;
                        plant = null;
                    }
                }
                else
                {
                    //Debug.Log(toBeUsed.name + " cannot be used here.");
                    return 101;
                }
            }
            else
            {
                //Debug.Log("Not a valid item to use");
                return 101;
            }
        }
        else
        {
            return 101;
        }

        return toBeUsed.GetComponent<Item>().energyRequired;
    }

    //TODO
    public int getEnergyRequired(GameObject toBeUsed)
    {
        /*
        Item item = toBeUsed.GetComponent<Item>();
        if (item.energyRequired >= 0)
        {
            return item.energyRequired;
        }
        else
        {
            return 1;
        }
        */
        return Use(toBeUsed, true);
    }

    public void OnMouseEnter()
    {
        turnManager.DisplayEnergy(getEnergyRequired(turnManager.currentItem));
    }

    public void OnMouseExit()
    {
        turnManager.ClearEnergy();
    }

    public void OnMouseUpAsButton()
    {
        if(!turnManager.picking && turnManager.currentItem != null)
        {
            int e = Use(turnManager.currentItem, true);
            if(e <= turnManager.energy)
            {
                turnManager.SetEnergy(Use(turnManager.currentItem, false));
            }
        }
    }

    public void Grow()
    {
        if(plantObject != null)
        {
            growth++;
            Flora.growthStage current = plant.stages[plant.currStage];
            if (growth >= current.nextStage && Random.Range(0, current.variation) > 0.5)
            {
                if (plant.currStage == plant.stages.Length - 1)
                {
                    Spread();
                }
                else
                {
                    plant.currStage++;
                }
                Quaternion offsetRotation = currentStageObject.transform.rotation;
                Destroy(currentStageObject);
                currentStageObject = Instantiate(plant.stages[plant.currStage].model, transform.position, offsetRotation);
                growth = 0;
            }
        }
    }

    public void Spread()
    {
        plant.currStage = 0;
        foreach (Soil s in neighbors)
        {
            if (s != null && s.plantObject == null) // && Random.Range(0.0f, 1.0f) < 0.2)
            {
                s.Use(plantObject, false);
            }
        }
        plant.currStage = plant.stages.Length - 2;
    }
}
