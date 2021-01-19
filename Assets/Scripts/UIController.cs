using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController: MonoBehaviour
{
    public GameObject resetButton;
    public GameObject playerOneWinText;
    public GameObject playerTwoWinText;
    public GameObject tieText;


    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }
}
