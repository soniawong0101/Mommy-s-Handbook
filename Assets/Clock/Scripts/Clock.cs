using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {

	//-- set start time 00:00
    public int minutes = 0;
    public int hour = 0;
	public int seconds = 0;
	public bool realTime=true;
    float rotationSeconds = 0;


    public GameObject pointerSeconds;

    public GameObject clock;
    
    //-- time speed factor
    public float clockSpeed = 10.0f;     // 1.0f = realtime, < 1.0f = slower, > 1.0f = faster

    //-- internal vars
    float msecs=0;

void Start() 
{
        //-- set real time
        /*if (realTime)
        {
            hour=System.DateTime.Now.Hour;
            minutes=System.DateTime.Now.Minute;
            seconds=System.DateTime.Now.Second;
        }*/
        seconds = 0;
        //clock.SetActive(false);
}

void Update() 
{

        /*
        msecs += Time.deltaTime * clockSpeed;
        if(msecs >= 1.0f)
        {
            msecs -= 1.0f;
            seconds++;
            if(seconds >= 60)
            {
                seconds = 0;
                minutes++;
                if(minutes > 60)
                {
                    minutes = 0;
                    hour++;
                    if(hour >= 24)
                        hour = 0;
                }
            }
        }*/


        //-- calculate pointer angles
        if(rotationSeconds <= 360)
        {
            msecs += Time.deltaTime * clockSpeed;
            seconds += (int)msecs;
            rotationSeconds = (360.0f / 60.0f) * seconds / 6;
            //Debug.Log(rotationSeconds);
            pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
        }
        else
        {
            rotationSeconds = 0;
            seconds = 0;
            pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            msecs = 0;
            clockSpeed = 0;
            
        }

        /*
    float rotationMinutes = (360.0f / 60.0f)  * minutes;
    float rotationHours   = ((360.0f / 12.0f) * hour) + ((360.0f / (60.0f * 12.0f)) * minutes);
        */

    //-- draw pointers
    //pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
    //pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
    //pointerHours.transform.localEulerAngles   = new Vector3(0.0f, 0.0f, rotationHours);

}
}
