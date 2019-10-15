using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public IMapManager map;

    public BaseGameMode mode;

    public GameObject userInterface;
    public GameObject scorePanel;
    public Text scoreField;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            map = GetComponent<IMapManager>();
            mode.GameOver += OnGameOver;
            userInterface.SetActive(true);
            scorePanel.SetActive(false);
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    public void Launch()
    {
        userInterface.SetActive(false);
        map.Clear();
        map.StartGeneration();
        mode.StartRulesCheck();

    }

    private void OnGameOver(object sender, GameOverEventArgs e)
    {
        map.Pause();
        mode.Stop();
        scoreField.text = "Score: " + e.gameScore;
        userInterface.SetActive(true);
        scorePanel.SetActive(true);
    }
}
