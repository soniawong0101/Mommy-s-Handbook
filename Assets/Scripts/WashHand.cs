﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashHand : MonoBehaviour
{
    //public static bool washedHand = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "rHand" )
        {
            Debug.Log("wash");
            gameConditions.washedHand = true;

        }
    }
}