using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class gameConditions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
*/
static class gameConditions
{
    public static bool washedHand = false;
    public static bool rightTemperature = false;
    public static bool TemperatureTooCold = false;
    public static bool TemperatureTooHot = false;
    public static bool rightAmount = false;
    public static bool spoonFlatten = false;
    public static int count = 0;
    public static bool coolDown = false;
    public static bool hasPatted = false;
    public static bool isPouring = false;
}