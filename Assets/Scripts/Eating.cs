using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour
{
    private Animator animator;
    public static bool feeding = false;
    public static bool feed_finished = false;
    public LiquidVolumeAnimator LVA;
    public GameObject vomit;
    public GameObject vomit2;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponentInParent<Animator>();
        animator.SetBool("isEating", false);
        if (LVA == null)
            LVA = GetComponent<LiquidVolumeAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (feeding)
        {
            //Debug.Log("milk level:" + LVA.level);
        }
        if(LVA.level <= 0.1 && feeding)
        {
            feed_finished = true;
            Debug.Log("feed finished!");
            if (gameConditions.hasPatted)
            {
                animator.SetBool("isClapping", true);
            }
            else if (!gameConditions.hasPatted)
            {
                animator.SetBool("isPuking", true);
                vomit2.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "bottle")
        {
            Debug.Log("eat");
            animator.SetBool("isEating", true);
            //animator.SetBool("isEating", true);
            //feeding = true;
            //animator.SetBool("isCorrect", true);
            //if (gameConditions.washedHand && gameConditions.rightAmount && gameConditions.count == 3 && gameConditions.spoonFlatten && gameConditions.coolDown)
            
            if (gameConditions.rightTemperature && gameConditions.rightAmount && gameConditions.count == 3 && gameConditions.spoonFlatten && gameConditions.coolDown && gameConditions.washedHand)
            {
                feeding = true;
                animator.SetBool("isEating", true);
                animator.SetBool("isCorrect", true);
                Debug.Log("all correct");
            }/*
            if(gameConditions.TemperatureTooCold || !gameConditions.washedHand)
            {
                feeding = true;
                animator.SetBool("isEating", true);
                animator.SetBool("isCorrect", true);
                Debug.Log("all correct");
            }*/
            else if ((!gameConditions.rightAmount|| !gameConditions.rightTemperature || !gameConditions.spoonFlatten || !gameConditions.coolDown || !(gameConditions.count == 3)) && (!gameConditions.TemperatureTooCold && gameConditions.washedHand))
            {
                animator.SetBool("isEating", true);
                animator.SetBool("isAngry", true);
            }
            else if (gameConditions.TemperatureTooCold || !gameConditions.washedHand)
            {
                animator.SetBool("isEating", true);
                animator.SetBool("isPuking", true);
                vomit.SetActive(true);
            }
            else
            {
                ///temp
                //animator.SetBool("isEating", true);
            }

        }
        else{
            ////animator.SetBool("isEating", false);
        }
    }
    private void OnTriggerExit(Collider other){

        if (other.gameObject.tag == "bottle")
        {
            //animator.SetBool("isEating", false);
        }
    }
}
