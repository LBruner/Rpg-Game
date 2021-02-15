using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Script : MonoBehaviour
{
    private bool isGameOver = false;
    public bool IsGameOver
    {
        get
        {
            return isGameOver;
        }
        set
        {
            isGameOver = value;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(IsGameOver);
            Debug.Log(isGameOver);
            IsGameOver = !isGameOver;
        }
    }

}
