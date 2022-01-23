using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HourSystem : MonoBehaviour
{
    public GameObject displayHour;
    public int hour;
    public string hour2;
    public int min;
    public string min2;
    public int sec;
    public string sec2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hour = System.DateTime.Now.Hour;
        min  = System.DateTime.Now.Minute;
        sec = System.DateTime.Now.Second;

        if (sec <= 9)
            sec2 = "0";
        else
            sec2 = "";

        if (min <= 9)
            min2 = "0";
        else
            min2 = "";

        if (hour <= 9)
            hour2 = "0";
        else
            hour2 = "";

        displayHour.GetComponent<Text>().text = "" + hour2 + hour + ":" + min2 + min + ":" + sec2 + sec;
    }
}
