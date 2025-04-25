using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClipSO clipMenu;
    [SerializeField] private AudioClipSO clipSelection;
    [SerializeField] private AudioClipSO clipGamePlay;

    private void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "MainMenu")
        {
            clipMenu.PlayLoop();
        }
        else if (currentScene == "CharacterSelection")
        {
            clipSelection.PlayLoop();
        }
        else if(currentScene == "MainGameGyroscope" && currentScene == "Results")
        {
            clipGamePlay.PlayLoop();
        }
    }
}