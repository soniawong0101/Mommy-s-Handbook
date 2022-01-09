using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//namespace UnityEngine.XR.Interaction.Toolkit
//{

//}

public class PadController : MonoBehaviour
{
    public GameObject pad;
    MeshRenderer meshRenderer;
    public Material cleanMaterial;
    public Material dirtyMaterial;

    
    public void DirtyPad()
    {
        meshRenderer.material = dirtyMaterial;
    }
    public void CleanPad()
    {
        meshRenderer.material = cleanMaterial;
    }
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = pad.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}