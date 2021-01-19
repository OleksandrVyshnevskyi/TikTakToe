using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class WinTracker : MonoBehaviour
{
    public CellSpawner cellSpawner;
    public UIController uiController;
    public bool matchEnded = false;

    void OnEnable()
    {
        CellValueChanger.OnStateChanged += CellsChecker;
    }
    void OnDisable()
    {
        CellValueChanger.OnStateChanged -= CellsChecker;
    }

    void CellsChecker()
    {
        if (cellSpawner == null)
        {
            return;
        }

        //Colomns checking
        for (int i = 0; i < cellSpawner.fieldSize; i++)
        {
            var sumColomn = cellSpawner.cellsArray[i, 0].value +
            cellSpawner.cellsArray[i, 1].value +
            cellSpawner.cellsArray[i, 2].value;

            if (sumColomn == 3)
            {
                uiController.resetButton.SetActive(true);
                uiController.playerOneWinText.SetActive(true);
                matchEnded = true;
            }
            else if (sumColomn == 6)
            {
                uiController.resetButton.SetActive(true);
                uiController.playerTwoWinText.SetActive(true);
                matchEnded = true;
            }
        }

        // Rows checking
        for (int j = 0; j < cellSpawner.fieldSize; j++)
        {
            var sumColomn = cellSpawner.cellsArray[0,j].value +
            cellSpawner.cellsArray[1,j].value +
            cellSpawner.cellsArray[2,j].value;

            if (sumColomn == 3)
            {
                uiController.resetButton.SetActive(true);
                uiController.playerOneWinText.SetActive(true);
                matchEnded = true;
            }
            else if (sumColomn == 6)
            {
                uiController.resetButton.SetActive(true);
                uiController.playerTwoWinText.SetActive(true);
                matchEnded = true;
            }
        }

        // Diagonals declaration and checking
        var d1 = cellSpawner.cellsArray[0, 0].value +
            cellSpawner.cellsArray[1, 1].value +
            cellSpawner.cellsArray[2, 2].value;
        var d2 = cellSpawner.cellsArray[2, 0].value +
            cellSpawner.cellsArray[1, 1].value +
            cellSpawner.cellsArray[0, 2].value;

        if (d1 == 3 || d2 == 3)
        {
            uiController.resetButton.SetActive(true);
            uiController.playerOneWinText.SetActive(true);
            matchEnded = true;
        }
        else if (d1 == 6 || d2 == 6)
        {
            uiController.resetButton.SetActive(true);
            uiController.playerTwoWinText.SetActive(true);
            matchEnded = true;
        }

        //Possible "Tie" checking
        var sumForTie = 0;
        foreach (var cell in cellSpawner.cellsArray)
        {
            var v = cell.GetComponent<CellController>().value;
            if (v != 0)
            {
                sumForTie+=v;
            }
        }
        
        if (sumForTie>10)
        {
            uiController.resetButton.SetActive(true);
            uiController.tieText.SetActive(true);
            matchEnded = true;
        }
    }
}
