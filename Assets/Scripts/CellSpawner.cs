using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CellSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject defaultCell;
    public int fieldSize = 3;
    public CellController[,] cellsArray;

    void Awake()
    {
        cellsArray = new CellController[fieldSize,fieldSize];
        CreateGrid(defaultCell);
    }

    private void CreateGrid(GameObject cell)
    {
        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j++)
            {
                var cellInstance = Instantiate(cell, transform);
                cellInstance.transform.position += new Vector3(1-i, j, 0);
                cellsArray[i,j] = cellInstance.GetComponent<CellController>();
            }  
        }
    }
}
