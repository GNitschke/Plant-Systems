using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{
    public int[] index;

    public float sun; //0-1
    public float water; //0-1
    public bool fertilized;
    public bool weeds;

    public Flora flora;

    public Soil[] neighbors;

    void Start()
    {
        flora = null;
    }

    public void Plant(Flora plant)
    {
        if (flora == null)
        {
            flora = Instantiate(plant.gameObject, transform).GetComponent<Flora>();
        }
    }

    public void RemovePlant()
    {
        Destroy(flora.gameObject);
        flora = null;
    }
}
