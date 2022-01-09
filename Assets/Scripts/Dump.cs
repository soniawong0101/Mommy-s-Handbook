using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dump : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject objectToActivate2;
    public GameObject objectToDeactivate;
    public GameObject objectToDeactivate2;
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
        if (other.gameObject.tag == "bottle")
        {
            if (objectToDeactivate.activeSelf)
            {
                //Debug.Log("correct");
                objectToDeactivate.SetActive(false);
                gameConditions.spoonFlatten = true;
                gameConditions.count += 1;
                Debug.Log("add count" + gameConditions.count);
            }
            else if (objectToDeactivate2.activeSelf) //no刮平
            {
                //Debug.Log("wrong");
                objectToDeactivate2.SetActive(false);
                gameConditions.spoonFlatten = false;
                //Debug.Log(gameConditions.count);
            }

            objectToActivate.SetActive(true);
            objectToActivate2.SetActive(true);
        }

    }
}
