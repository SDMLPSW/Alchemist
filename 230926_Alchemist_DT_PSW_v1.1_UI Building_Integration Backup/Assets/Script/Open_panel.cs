using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Open_panel : MonoBehaviour
{
    public GameObject panel;

    public void Panel_open()
    {
        if (panel != null)
        {
            panel.SetActive(true);
            Debug.Log("clicked");
        }
    }
    
}
