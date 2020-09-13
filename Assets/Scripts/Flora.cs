using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Flora : Item
{
    [System.Serializable]
    public struct Stage
    {
        public int nextStage;
        public GameObject model;
    };
 
    //public string name;

    public Stage[] stages;

    //Growth Factors
    public float idealSun; //0-1
    public float idealWater; //0-1
    public float toughness;

    //Condition
    private int currStage = 0;
    private int stageGrowth;
    private int wilt;

    public void OnEnable()
    {
        Instantiate(stages[currStage].model, transform);
    }

    public void Grow(Soil soil)
    {
        Flora.Stage current = stages[currStage];
        if ((soil.water < idealWater - toughness || soil.sun < idealSun - toughness)) //check if it has enough water and sun
        {
            wilt++; //if not add to the plant's wiltedness
        }
        else //if so it can grow a bit and get a bit less wilted
        {
            if (wilt > 0)
                wilt--;
            stageGrowth++;
        }

        //if it has more wilt than growth need for the next stage plus the current stage number the plant dies
        if (wilt > current.nextStage + currStage) //adding the stage makes it harder for a more advanced plant to wilt despite needing less turns to get to the next stage
        {
            soil.RemovePlant();
        }

        float modifier = 1; //modifier for turns needed to grow
        if (soil.fertilized)
        {
            modifier *= 0.6f; //makes it easier if fertilized
        }
        if (soil.weeds)
        {
            modifier *= 1.5f; //makes it harder if there are weeds
        }

        if (stageGrowth >= current.nextStage * modifier) //if it has enough growth
        {
            if (currStage == stages.Length - 1) //if the plant has seeds then it will spread
            {
                Destroy(transform.GetChild(0).gameObject);
                Instantiate(stages[currStage - 1].model, transform);
                Spread();
            }
            else
            {
                currStage++; //otherwise it will just advance to the next stage
                Destroy(transform.GetChild(0).gameObject);
                Instantiate(stages[currStage].model, transform);
            }
            stageGrowth = 0; //reset growth for the new stage
        }
    }

    public void Spread()
    {
        currStage = 0;
        Collider[] nearby = Physics.OverlapSphere(transform.position, 6.0f);
        foreach (Collider collider in nearby) //in each of the plant's neighboring soil tiles
        {
            if (collider.GetComponent<Soil>() != null)
            {
                Soil s = collider.GetComponent<Soil>();
                if (s.flora == null) // && Random.Range(0.0f, 1.0f) < 0.2)
                {
                    s.Plant(this); //plant a new version of the plant 
                }
            }
        }
        currStage = stages.Length - 2; //set the original plant back to the stage before seeds
    }
}
