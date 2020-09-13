using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilTB : MonoBehaviour
{
    /*
    public TurnManager turnManager;
    public int[] index;

    //public string name;
    public int growth;
    public int wilt;

    public float sun;
    public bool fertilized;
    public float water;
    public bool weeds;

    public bool infected;

    private GameObject plantObject;
    private GameObject currentStageObject;
    public Flora plant;

    public SoilTB[] neighbors;

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
                        RemovePlant();
                    }
                }
                if (toBeUsed.name == "Watering Can" && plantObject != null)
                {
                    if (!check)
                    {
                        Debug.Log("Watered");
                        water += 2.0f;
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
        
        Item item = toBeUsed.GetComponent<Item>();
        if (item.energyRequired >= 0)
        {
            return item.energyRequired;
        }
        else
        {
            return 1;
        }
        
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
        if(plantObject != null) //make sure there is a plant to grow
        {
            Flora.growthStage current = plant.stages[plant.currStage];
            if ((water < current.waterUsage || sun < current.sunNeeded) && !infected) //check if it has enough water and sun
            {
                wilt++; //if not add to the plant's wiltedness
            }
            else //if so it can grow a bit and get a bit less wilted
            {
                if (wilt > 0)
                    wilt--;
                growth++;
            }

            //if it has more wilt than growth need for the next stage plus the current stage number the plant dies
            if (wilt > current.nextStage + plant.currStage) //adding the stage makes it harder for a more advanced plant to wilt despite needing less turns to get to the next stage
            {
                RemovePlant();
            }

            float modifier = 1; //modifier for turns needed to grow
            if (fertilized)
            {
                modifier *= 0.6f; //makes it easier if fertilized
            }
            if (weeds)
            {
                modifier *= 1.5f; //makes it harder if there are weeds
            }

            if (growth >= current.nextStage * modifier) //if it has enough growth
            {
                if (plant.currStage == plant.stages.Length - 1) //if the plant has seeds then it will spread
                {
                    Spread();
                }
                else
                {
                    plant.currStage++; //otherwise it will just advance to the next stage
                }
                Quaternion offsetRotation = currentStageObject.transform.rotation;
                Destroy(currentStageObject); //get rid of old stage
                currentStageObject = Instantiate(plant.stages[plant.currStage].model, transform.position, offsetRotation); //plant the next stage at an offset rotation so its less grid like
                growth = 0; //reset growth for the new stage
            }
        }
    }

    public void Spread()
    {
        plant.currStage = 0;
        foreach (SoilTB s in neighbors) //in each of the plant's neighboring soil tiles
        {
            if (s != null && s.plantObject == null) // && Random.Range(0.0f, 1.0f) < 0.2)
            {
                s.Use(plantObject, false); //plant a new version of the plant 
            }
        }
        plant.currStage = plant.stages.Length - 2; //set the original plant back to the stage before seeds
    }

    public void RemovePlant()
    {
        Destroy(plantObject);
        Destroy(currentStageObject);
        plantObject = null;
        plant = null;
    }
    */
}
