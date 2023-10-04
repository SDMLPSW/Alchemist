using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Close_panel : MonoBehaviour
{
    public GameObject active_panel;

    public void close_panel()
    {
        active_panel.SetActive(false);
    }
}
