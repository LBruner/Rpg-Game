using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Script : MonoBehaviour
{
    public Dictionary<int, int> numbers = new Dictionary<int,int>();

    private void Start()
    {
        /*numbers.Add(0, 0);
        Debug.Log(numbers[0]);
        numbers.Add(500, 240);
        Debug.Log(numbers[500]);
        */
        foreach  (var number in numbers)
        {
            Debug.Log(number);
        }
    }
}
