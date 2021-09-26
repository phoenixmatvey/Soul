using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
public class Chage_pos : MonoBehaviour
{
    public Vector2 Start_Point, End_Point;
    public float step;
    private float progress;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Start_Point;
        
    }

    // Update is called once per frame
    void FixUpdate()
    {
        transform.position = Vector2.Lerp(Start_Point, End_Point, progress);
        progress += step;
    }
}
