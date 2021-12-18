using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject gamePlayHUD;
    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleStartScreen(bool toggle)
    {
        startScreen.SetActive(toggle);
    }

    public void ToggleHUD(bool toggle)
    {
        gamePlayHUD.SetActive(toggle);
    }

    public void ToggleGameOver(bool toggle)
    {
        gameOverScreen.SetActive(toggle);
    }

}

