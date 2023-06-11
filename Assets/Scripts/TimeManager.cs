using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject canvasCamera;

    public static bool isPaused = false;

    private void Start()
    {
        isPaused = false;
        menu.SetActive(false);
        canvasCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Reasume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
        canvasCamera.SetActive(true);
        isPaused = true;
    }
    public void Reasume()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        canvasCamera.SetActive(false);
        isPaused = false;
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        canvasCamera.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        canvasCamera.SetActive(false);
    }
    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
