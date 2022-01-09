using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidAbsorptionV2 : MonoBehaviour {

    //public int collisionCount = 0;
    public Color currentColor;
    public BottleSmash smashScript;
    public MeshLiquidEmission LiquidEmission;
    public LiquidVolumeAnimator LVA;

    //public bool rightAmount = false;

    // Use this for initialization
    float particleValue = 1;

    void Start () {
        if(LVA == null)
        LVA = GetComponent<LiquidVolumeAnimator>();
	}
    void OnParticleCollision(GameObject other)
    {

        //check if it is the same factory.
        if (other.transform.parent == transform.parent)
            return;
        bool available = true;
        //LiquidEmission.volumeOfParticles
        float finalParticleValue = particleValue * (1.0f / LiquidEmission.volumeOfParticles);
        if (available)
        {
            //Debug.Log("is pouring water");
            //currentColor = smashScript.color;
            if (LVA.level < 0.9f - finalParticleValue)
            {

                //essentially, take the ratio of the bottle that has liquid (0 to 1), then see how much the level will change, then interpolate the color based on the dif.
                Color impactColor = other.GetComponentInParent<BottleSmash>().color;//cant be cached

                if (LVA.level <= float.Epsilon * 10)
                {
                    //currentColor = impactColor;
                }
                else
                {
                    //currentColor = Color.Lerp(currentColor, impactColor, finalParticleValue / LVA.level);
                }
                //collisionCount += 1;
                LVA.level += finalParticleValue;
                //smashScript.color = currentColor;

                gameConditions.isPouring = true;

                ////DETECT IF REACH 180 ML
                if (LVA.level >= 0.50 && LVA.level < 0.6)
                {
                    gameConditions.rightAmount = true;
                    //Debug.Log(gameConditions.rightAmount);
                    Debug.Log("right amount of water");
                }
                else if (LVA.level >= 0.6)
                {
                    gameConditions.rightAmount = false;
                    //Debug.Log(gameConditions.rightAmount);
                    Debug.Log("Too much water");
                }
                else
                {
                    gameConditions.rightAmount = false;
                    //Debug.Log(gameConditions.rightAmount);
                    Debug.Log("Not enough water");
                }
            }
        }
    }

	// Update is called once per frame
	void Update ()
	{
	    //currentColor = smashScript.color;
        //Debug.Log(LVA.level);
        if(gameConditions.isPouring){
            //Debug.Log("Is Pouring");
            if (LVA.level >= 0.50 && LVA.level < 0.6)
            {
                gameConditions.rightAmount = true;
                //Debug.Log(gameConditions.rightAmount);
                Debug.Log("back to right amount of water");
            }
            else{
                gameConditions.rightAmount = false;
                //Debug.Log(gameConditions.rightAmount);
            }
        }
        

    }
}
