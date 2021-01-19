using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    [SerializeField]
    private Sprite sad;
    [SerializeField]
    private Sprite happy;
    public int value = -2; // to exclude calculating issues in WinTracker
    public bool canBeInteracted = true; 

    public void ChangeValueAndImage(int playerNumber)
    {
        if (value == -2)
        {
            transform.gameObject.GetComponent<SpriteRenderer>().sprite = playerNumber == 1? happy:sad;
            value = playerNumber;
        }
    }
}
