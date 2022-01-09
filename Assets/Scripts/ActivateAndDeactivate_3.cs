using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAndDeactivate_3 : MonoBehaviour
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
        if (other.gameObject.tag == "bottle")
        {
            Debug.Log("powder_in");
            objectToDeactivate.SetActive(false);
            objectToActivate.SetActive(true);

        }
    }
}
