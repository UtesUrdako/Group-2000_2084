using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var show = new Show(2);
        show.ShowTime();
    }
}


public class Show
{
    private float _time;
    public Show(float time)
    {
        _time = time;
    }

    public void ShowTime()
    {
        Debug.Log($"Show time {_time}!");
    }
}