using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivayeAndDeactivate : MonoBehaviour
{

    public GameObject objectToActivate;
    //public bool spoonFlatten = false;

    //public GameObject objectToDeactivate;
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
        if (other.gameObject.tag == "milk")
        {
            Debug.Log("get_milk");
            //objectToDeactivate.SetActive(false);
            objectToActivate.SetActive(true);
            gameConditions.spoonFlatten = false;

        }
    }
}