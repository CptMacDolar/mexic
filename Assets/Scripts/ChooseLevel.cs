using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour
{
    public Button [] levels;

    void Start()
    {
        levels[0].onClick.AddListener(lvl1);
        levels[1].onClick.AddListener(lvl2);
        levels[2].onClick.AddListener(lvl3);
        //levels[3].onClick.AddListener(lvl4);

    }

    private void lvl1()
    {
        SceneManager.LoadScene("Level1");
    }
    private void lvl2()
    {
        SceneManager.LoadScene("Level2");
    }
    private void lvl3()
    {
        SceneManager.LoadScene("Level3");
    }
    private void lvl4()
    {
        SceneManager.LoadScene("Level4");
    }
}
