using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public int boardWidth = 5;
    public int boardLength = 5;

    public GameObject field;

    public Soil[,] board;

    public int turn;
    public Text turnNumber;

    public GameObject currentPlant;
    // Start is called before the first frame update
    void Start()
    {
        turn = 0;
        turnNumber = transform.Find("Canvas").Find("Turn").GetComponent<Text>();
        turnNumber.text = "" + turn;
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

            if (Physics.Raycast(ray, out hit, float.PositiveInfinity, 1 << 9) && hit.transform.GetComponent<Soil>() != null)
            {
                hit.transform.GetComponent<Soil>().Plant("flower");
            }
        }
    }

    public void NextTurn()
    {
        turn++;
        turnNumber.text = "" + turn;
        for (int i = 0; i < boardWidth; i++)
        {
            for (int j = 0; j < boardLength; j++)
            {
                board[i, j].Grow();
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
