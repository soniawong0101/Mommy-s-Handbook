using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using PDollarGestureRecognizer;

public class MovementRecognizer : MonoBehaviour
{
    public XRNode inputSource;
    public InputHelpers.Button inputButton;
    public float inputThreshold = 0.1f;
    private bool isMoving = false;
    public Transform movementSource;
    private List<Vector3> positionList = new List<Vector3>();
    public float newPositionThresholdDistance = 0.05f;
    private List<Gesture> trainingSet = new List<Gesture>();

    public static bool shake = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, inputThreshold);
        if(!isPressed){
            //Debug.Log("not pressed");
        }
        //Start the movement
        if (!isMoving && isPressed)
        {
            isMoving = true;
            Debug.Log("pressed");
            //StartMovement();
        }
        //Ending the movement
        else if (isMoving && !isPressed)
        {
            isMoving = false;
            shake = true;
            //EndMovement();
        }
        //Updating the movement
        else if (isMoving && isPressed)
        {
            //UpdateMovement();
        }
        /*
        if (!isMoving && Input.GetMouseButtonDown(0))
        {
            StartMovement();
        }
        //Ending the movement
        else if (isMoving && !Input.GetMouseButtonDown(0))
        {
            EndMovement();
        }
        //Updating the movement
        else if (isMoving && Input.GetMouseButtonDown(0))
        {
            UpdateMovement();
        }*/
    }

    void StartMovement()
    {
        Debug.Log("Start Movement");
        isMoving = true;
        positionList.Clear();
        positionList.Add(movementSource.position);
    }

    void EndMovement()
    {
        Debug.Log("End Movement");
        isMoving = false;
        Point[] pointArray = new Point[positionList.Count];

        for (int i = 0; i < positionList.Count; i++)
        {
            Vector2 screenPoint = Camera.main.WorldToScreenPoint(positionList[i]);
            pointArray[i] = new Point(screenPoint.x, screenPoint.y, 0);
        }
        Gesture newGesture = new Gesture(pointArray);

        Result result = PointCloudRecognizer.Classify(newGesture, trainingSet.ToArray());
        Debug.Log(result.GestureClass);
        /*if(result.GestureClass == "line")
        {
            shake = true;
        }*/
        shake = true;

    }

    void UpdateMovement()
    {
        Debug.Log("Update Movement");
        Vector3 lastPosition = positionList[positionList.Count - 1];
        if(Vector3.Distance(movementSource.position, lastPosition) > newPositionThresholdDistance)
            positionList.Add(movementSource.position);
    }
}