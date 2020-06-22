using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public Soil[] board;

    public int turn;

    public GameObject currentPlant;
    // Start is called before the first frame update
    void Start()
    {
        turn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                hit.transform.GetComponent<Soil>().Plant("flower");
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            foreach(Soil s in board)
            {
                s.Grow();
            }
        }
    }
}
