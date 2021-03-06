﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    /*
    public int boardWidth = 5;
    public int boardLength = 5;

    public GameObject field;

    public Soil[,] board;

    private int turn;
    private Text turnUI;

    public int energy;
    private Text energyUI;
    private int maxEnergy = 5;

    private Text mouseInfo;

    //Used by ItemSelection to block item use while selecting
    public bool picking;

    public GameObject currentItem;
    // Start is called before the first frame update
    void Start()
    {
        turn = 0;
        energy = maxEnergy;
        currentItem = null;
        turnUI = transform.Find("Canvas").Find("Turn").GetComponent<Text>();
        turnUI.text = "Turn: " + turn;
        energyUI = transform.Find("Canvas").Find("Energy").GetComponent<Text>();
        mouseInfo = transform.Find("Canvas").Find("MouseInfo").GetComponent<Text>();
        energyUI.text = "Energy: " + energy;
        board = new Soil[boardWidth, boardLength];
        GenerateBoard();
    }

    public void SetEnergy(int e)
    {
        energy -= e;
        energyUI.text = "Energy: " + energy;
    }

    public void DisplayEnergy(int e)
    {
        string mI = "X";
        if (e != 101)
        {
            mI = "E: -" + e;
        }

        if (energy < e || e == 101)
        {
            mouseInfo.color = Color.red;
        }
        else
        {
            mouseInfo.color = Color.white;
        }
        mouseInfo.text = mI;
    }

    public void ClearEnergy()
    {
        mouseInfo.text = "";
    }

    private void GenerateBoard()
    {
        for(int i = 0; i < boardWidth; i++)
        {
            for(int j = 0; j < boardLength; j++)
            {
                GameObject tile = Instantiate(field, new Vector3(i * 11, 0, j * 11), Quaternion.identity);
                board[i, j] = tile.GetComponent<Soil>();
                board[i, j].index = new int[2];
                board[i, j].index[0] = i;
                board[i, j].index[1] = j;
                board[i, j].neighbors = new Soil[4];
            }
        }

        for (int i = 0; i < boardWidth; i++)
        {
            for (int j = 0; j < boardLength; j++)
            {
                if (i != 0)
                    board[i, j].neighbors[0] = board[i - 1, j];
                if(i != boardWidth - 1)
                    board[i, j].neighbors[1] = board[i + 1, j];
                if (j != 0)
                    board[i, j].neighbors[2] = board[i, j - 1];
                if (j != boardLength- 1)
                    board[i, j].neighbors[3] = board[i, j + 1];
            }
        }
    }

    public void NextTurn()
    {
        turn++;
        turnUI.text = "Turn: " + turn;
        if(energy < maxEnergy)
            energy++;
        energyUI.text = "Energy: " + energy;
        for (int i = 0; i < boardWidth; i++)
        {
            for (int j = 0; j < boardLength; j++)
            {
                board[i, j].Grow();
            }
        }
    }

    public void SelectItem(GameObject toBeUsed)
    {
        currentItem = toBeUsed;
        Debug.Log("Selected: " + currentItem.name);
    }
    */
}
