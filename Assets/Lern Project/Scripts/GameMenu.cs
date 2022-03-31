using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _quitGameButton;

    public Slider _sl;
    
    private void Awake()
    {
        _quitGameButton.onClick.AddListener(() => { Application.Quit(); });
        _startGameButton.onClick.AddListener(StartGame);
        
        _sl.onValueChanged.AddListener(value =>
        {
            Debug.Log(value);
        });
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
