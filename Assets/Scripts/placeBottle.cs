using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeBottle : MonoBehaviour
{
    public GameObject hand;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //clock.SetActive(false);
        anim = hand.GetComponent<Animator>();
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.B))
        {
            anim.enabled = true;
            anim.Play("ClockAnimation");

        }*/
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "bottle")
        {
            Debug.Log("placed");
            clock.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "bottle")
        {
            clock.SetActive(false);
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bottle")
        {
            Debug.Log("placed");
            //clock.SetActive(true);
            anim.enabled = true;
            anim.Play("ClockAnimation");
            gameConditions.coolDown = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "bottle")
        {
            //clock.SetActive(false);
        }
    }
}
