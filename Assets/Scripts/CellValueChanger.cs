using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellValueChanger : MonoBehaviour
{
    public delegate void ChangeState();
    public static event ChangeState OnStateChanged;

    public WinTracker winTracker;
    private int currentPlayer;
    private int playerOne = 1;
    private int playerTwo = 2;

    void Start()
    {
        currentPlayer = playerOne;
    }

    private void Update()
    {
        if (winTracker.matchEnded == false)
        {
            CellChanger();
        }
    }

    void CellChanger()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.transform.gameObject.tag == "Cell")
            {
                if (hit.transform.gameObject.GetComponent<CellController>().value == -2)
                {
                    hit.transform.gameObject.GetComponent<CellController>().ChangeValueAndImage(currentPlayer);
                    if (OnStateChanged != null)
                    {
                        OnStateChanged();
                    }
                    if (currentPlayer == 1)
                    {
                        currentPlayer = playerTwo;
                    }
                    else
                    {
                        currentPlayer = playerOne;
                    }
                }
                
            }
        }
    }
}
