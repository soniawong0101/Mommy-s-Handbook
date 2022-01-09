using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltKettle : MonoBehaviour
{
    public GameObject kettle;
    public GameObject water;
    // Start is called before the first frame update
    void Start()
    {
        water.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(kettle.transform.rotation.x);
        if (kettle.transform.rotation.x > 0.16f)
        {
            water.SetActive(true);
        }
        else
        {
            water.SetActive(false);
        }

    }
}
