using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PutOnBottle : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject objectToDeactivate;
    public GameObject text;
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
        if (other.gameObject.tag == "pacifier")
        {
            //Debug.Log("touched");
            objectToDeactivate.SetActive(false);
            objectToActivate.SetActive(true);
            text.SetActive(true);
            StartCoroutine(Example());
            Debug.Log("number of spoons added " + gameConditions.count);
            gameConditions.isPouring = false;

        }
    }
    IEnumerator Example()
    {
        yield return new WaitForSecondsRealtime(4);
        text.SetActive(false);
        yield return new WaitForSecondsRealtime(1);
        MovementRecognizer.shake = true;
    }
}
