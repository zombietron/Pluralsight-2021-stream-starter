using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{

    public void QuitGame()
    {
        #if UNITY_EDITOR
               UnityEditor.EditorApplication.ExitPlaymode();

        #endif

        Application.Quit();
    }

}
