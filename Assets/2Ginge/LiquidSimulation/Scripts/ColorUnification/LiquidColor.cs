using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidColor : ColorBase {

	// Use this for initialization
    private LiquidVolumeAnimator lva;
    /*
    public bool UpdateSurfaceColor = true;
    public bool UpdateColor = true;
    public bool UpdateSurfaceEmission = true;
    public bool UpdateEmission = true;
    */
    public GameObject objectToDeactivate;
    //public bool rightAmount = false;

    void Start ()
	{
	    //mat = GetComponent<MeshRenderer>();
	    lva = GetComponent<LiquidVolumeAnimator>();
        /*
        if(bottleSmash == null)
        {
            bottleSmash = GetComponentInParent<BottleSmash>();
        }
        RegisterWithController();
        */
	}
    private void Update()
    {
        if (MovementRecognizer.shake)
        {
            lva.mats[0].SetColor("_Color", Color.white);
            lva.mats[0].SetColor("_EmissionColor", Color.white);
            objectToDeactivate.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
    /*
    protected override void RegisterWithController()
    {
        bottleSmash.RegisterColorBase(this);
    }*/
    /*
    // Update is called once per frame
    public override void Unify()
	{
        if (UpdateColor)
        {
            lva.mats[0].SetColor("_Color", bottleSmash.color);
        }
        if (UpdateEmission)
        {
            lva.mats[0].SetColor("_EmissionColor", bottleSmash.color);
        }
        if (UpdateSurfaceColor)
        {
            lva.mats[0].SetColor("_SColor", bottleSmash.color);
        }
        if (UpdateSurfaceEmission)
        {
            lva.mats[0].SetColor("_SEmissionColor", bottleSmash.color);
            //ahh these need to be registered.
        }

    }*/
}
