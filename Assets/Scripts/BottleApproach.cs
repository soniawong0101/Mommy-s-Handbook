using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleApproach : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponentInParent<Animator>();
        animator.SetBool("isFeeding", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "bottle")
        {
            Debug.Log("feed");
            animator.SetBool("isFeeding", true);
            
        }else{
            //animator.SetBool("isFeeding", false);
        }
    }
    private void OnTriggerExit(Collider other){
        if (other.gameObject.tag == "bottle")
        {
            Debug.Log("not approach");
            animator.SetBool("isFeeding", false);
            
        }else{
            //animator.SetBool("isFeeding", false);
        }
    }
}
