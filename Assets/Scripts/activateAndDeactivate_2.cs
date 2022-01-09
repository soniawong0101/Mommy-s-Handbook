using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateAndDeactivate_2 : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject objectToDeactivate;
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
        if (other.gameObject.tag == "scrape")
        {
            Debug.Log("collide_can");
            objectToDeactivate.SetActive(false);
            objectToActivate.SetActive(true);
            gameConditions.spoonFlatten = true;

        }
    }
}
