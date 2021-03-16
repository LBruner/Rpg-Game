using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Script : MonoBehaviour
{
    //public Dictionary<int, int> numbers = new Dictionary<int,int>();

    //private void Start()
    //{
    //    /*numbers.Add(0, 0);
    //    Debug.Log(numbers[0]);
    //    numbers.Add(500, 240);
    //    Debug.Log(numbers[500]);
    //    */
    //    foreach  (var number in numbers)
    //    {
    //        Debug.Log(number);
    //    }
    //}

    [SerializeField] List<string> names;


    [SerializeField] List<int> numbers = new List<int>();


    [SerializeField] List<float> seconds = new List<float> {1f, 5f, 68f};


    private void Start()
    {
        Debug.Log(numbers.Count);

        Debug.Log(numbers.Remove(5));

        Debug.Log(numbers.Remove(numbers[1]));

    }

    void ForLoop()
    {
        List<int> numbers = new List<int>();
        numbers.Add(1);
        numbers.Add(2);

        for (int i = 0; i < numbers.Count; i++)
        {
            Debug.Log("Hello!");
        }
    }

    void ForLoop2()
    {
        for (int i = 0; i < 100; i++)
        {
            if (i == 50)
                break;
        }
    }
}
