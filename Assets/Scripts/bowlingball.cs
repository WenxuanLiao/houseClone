using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowlingball : MonoBehaviour
{

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("test");
            GetComponent<Camerashake>().ShakeCamera(20f, 1f);
        }
    }
}
