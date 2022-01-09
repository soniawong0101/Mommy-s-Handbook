using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DegreeController : MonoBehaviour
{

    public static int degree = 40;
    Text score;

    void Start()
    {

        score = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        score.text = "" + degree + "°C";
    }



}