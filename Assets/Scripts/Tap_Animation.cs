using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap_Animation : MonoBehaviour
{
    public GameObject water;
    public GameObject drop;
    public GameObject handCollider;
    private Animation anim;
    private bool play = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        anim.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "rHand")
        {

            if(!water.activeSelf && !drop.activeSelf && play == false)
            {
                Debug.Log("open_tap");
                anim.enabled = true;
                anim.Play("Up");
                play = true;
                water.SetActive(true);
                drop.SetActive(true);
                handCollider.SetActive(true);
                //anim.enabled = false;
            }
            else if(water.activeSelf && drop.activeSelf && play == false)
            {
                Debug.Log("close_tap");
                anim.enabled = true;
                anim.Play("Down");
                play = true;
                water.SetActive(false);
                drop.SetActive(false);
                handCollider.SetActive(false);
                //anim.enabled = false;

            }

        }

    }
    public void AlertObservers(string message)
    {
        if (message.Equals("AnimationEnd"))
        {
            play = false;
            // Do other things based on an attack ending.
        }
    }
}
