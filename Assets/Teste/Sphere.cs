using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    Script script;

    private void Start()
    {
        script = new Script();
        script.IsGameOver = false;
    }
}
