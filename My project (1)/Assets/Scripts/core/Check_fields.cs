using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;


public class Check_fields : MonoBehaviour
{
    //Set all text fields
    public InputField First_name;
    public InputField Second_name;
    public InputField Third_name;

    public Button Start_button;

    public void Check_Correct()
    {
        if ((First_name.text.Length != 0) &&
            (Second_name.text.Length != 0))
        {
            Start_button.gameObject.SetActive(true);
        }
        else
        {
            if (First_name.text.Length == 0)
            {
                First_name.GetComponent<Text>().color = new Color(255, 0, 0);
            }
            if (Second_name.text.Length == 0)
            {
                Second_name.GetComponent<Text>().color = new Color(255, 0, 0);
            }
        }
    }

}
