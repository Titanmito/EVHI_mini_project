using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Leave : MonoBehaviour
{
    public Button button;

    void TaskOnClick()
    {
        Application.Quit();
    }
}
