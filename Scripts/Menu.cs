﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{


  public void StartGame()
    {
        SceneManager.LoadScene("Scene1");

    }

    public void QuitGame()
    {

        Application.Quit();

    }

}
