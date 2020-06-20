using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{
    public TurnManager turnManager;

    public string plant;
    public int turnplanted;

    public GameObject plantObject;

    public struct neighbors
    {
        public Soil up;
        public Soil left;
        public Soil right;
        public Soil down;
    }

    void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        turnplanted = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Plant(string seed)
    {
        plant = seed;
        turnplanted = turnManager.turn;
        plantObject = turnManager.currentPlant;
    }
}
