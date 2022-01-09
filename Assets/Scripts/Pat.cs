using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pat : MonoBehaviour
{
    private int count1 = 0;
    private int count2 = 0;
    public LiquidVolumeAnimator LVA;
    // Start is called before the first frame update
    void Start()
    {
        if (LVA == null)
            LVA = GetComponent<LiquidVolumeAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(count1 >= 3)
        {
            gameConditions.hasPatted = true;
            //Debug.Log("WONT THROWUP");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "rHand" || other.gameObject.tag == "Hand");
        {
            if(Eating.feeding && LVA.level > 0.1)
            {
                count1 += 1;
                //Debug.Log("pat count: " + count1);
            }

        }

    }
}