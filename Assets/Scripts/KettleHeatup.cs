using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KettleHeatup : MonoBehaviour
{
    private Animator anim;
    private bool heating;

    bool count = false;
    float decimaldegree;
    public GameObject hint;

    //public static bool rightTemperature = false;
    //public static bool TemperatureTooCold = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        heating = false;
        decimaldegree = (float)DegreeController.degree;
    }

    // Update is called once per frame
    void Update()
    {

        if (count == true && DegreeController.degree <= 100)
        {
            decimaldegree += 2f * Time.deltaTime;
            DegreeController.degree = Mathf.RoundToInt(decimaldegree);

        }
        if(DegreeController.degree >= 70 && DegreeController.degree < 75)
        {
            gameConditions.rightTemperature = true;
            gameConditions.TemperatureTooCold = false;
            Debug.Log("perfect temperature");
        }
        else if(DegreeController.degree > 75)
        {
            gameConditions.rightTemperature = false;
            gameConditions.TemperatureTooHot = true;
            Debug.Log("too hot");
        }
        else if(DegreeController.degree < 75)
        {
            gameConditions.TemperatureTooCold = true;
            //Debug.Log("too cold");

        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "rHand")
        {
            anim.enabled = true;
            //Debug.Log("heatup");
            if (!heating)
            {
                anim.Play("KettleHeatup");
                count = true;
                decimaldegree = (float)DegreeController.degree;
                hint.SetActive(false);
            }
            else
            {
                anim.Play("Heated");
                count = false;
            }
        }
    }
    public void AlertObservers(string message)
    {
        if (message.Equals("AnimationEnded"))
        {
            //Debug.Log("finish");
            heating = !heating;
        }
    }
}
