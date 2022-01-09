using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject objectToFollow;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = objectToFollow.transform.position + offset;
        transform.rotation = objectToFollow.transform.rotation;
        //Debug.Log("bottle pos" + transform.position);
        //Debug.Log("object pos" + objectToFollow.transform.position);
    }
}
