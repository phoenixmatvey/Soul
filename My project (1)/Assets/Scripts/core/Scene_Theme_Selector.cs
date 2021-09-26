using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scene_Theme_Selector : MonoBehaviour
{
    public GameObject[] Number = new GameObject[Scene_Theme.Scene_Theme_total];
    public int Scena_theme_local_number;
    // Start is called before the first frame update
    void Start()
    {
        Scena_theme_local_number = Scene_Theme.Scene_Theme_number;
        Number[Scena_theme_local_number].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Number[Scena_theme_local_number].SetActive(true);
    }
}
