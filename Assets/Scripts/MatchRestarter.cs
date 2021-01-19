using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchRestarter : MonoBehaviour
{
    public GameObject resetButton;

    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }
}
