using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        private set 
        {
            if (instance != null)
            {
                Debug.LogWarning("Tried to set a duplicate GM, not possible");
                return;
            }
            else
                instance = value;
        }
        get
        {   
            return instance;
        }

    }

    public bool isRunning = false;

    float timeAlive;

    [SerializeField] UpdateScore scoreUIUpdater;

    public SpawnController spawnController;
    public UIManager uimgr;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitStart();
    }
    // Update is called once per frame
    void Update()
    {
        if(isRunning)
        {
             CalcScore();
        }
    }

    public void StartGame()
    {
        isRunning = true;
        spawnController.StartSpawning();
        uimgr.ToggleStartScreen(false);
        uimgr.ToggleHUD(true);
        uimgr.ToggleGameOver(false);

    }

    public void InitStart()
    {
        uimgr.ToggleStartScreen(true);
        uimgr.ToggleHUD(false);
        uimgr.ToggleGameOver(false);
        CalcScore();
    }
    public void GameOver()
    {
        isRunning = false;
        uimgr.ToggleGameOver(true);
    }

    public void CalcScore()
    {
        timeAlive += Time.deltaTime;
        if (scoreUIUpdater != null)
        {
            scoreUIUpdater.UpdateScoreText((int)timeAlive);
        }
        else
            Debug.Log("UI Updater is null.. did you assign it in the inspector?");
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
