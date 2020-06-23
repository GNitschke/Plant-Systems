using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int boardWidth = 5;
    public int boardLength = 5;

    public GameObject field;

    public Soil[,] board;

    public int turn;

    public GameObject currentPlant;
    // Start is called before the first frame update
    void Start()
    {
        turn = 0;
        board = new Soil[boardWidth, boardLength];
        GenerateBoard();
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
            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardLength; j++)
                {
                    board[i,j].Grow();
                }
            }
        }
    }

    private void GenerateBoard()
    {
        for(int i = 0; i < boardWidth; i++)
        {
            for(int j = 0; j < boardLength; j++)
            {
                board[i, j] = GameObject.Find("Field"+ i + "" + j).GetComponent<Soil>();
            }
        }
    }
}
