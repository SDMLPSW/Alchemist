using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Open_Other_Scene : MonoBehaviour
{
    public string targetSceneName;
    
    public void SwitchScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
