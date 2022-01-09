using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BabyController : MonoBehaviour
{

    public UnityEvent onStartBleed;
    public UnityEvent onStopBleed;
   
    public void StopBleed()
    {
        onStopBleed.Invoke();
    }
    //called after animation: sit_idle end
    public void StartBleed()
    {
        onStartBleed.Invoke();
    }
    void Start()
    {
        onStopBleed.Invoke();
    }
}
