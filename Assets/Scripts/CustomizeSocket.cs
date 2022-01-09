using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using System.Linq;
public class CustomizeSocket : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    public UnityEvent onMedAttach;
    public UnityEvent onMedDetach;
    public UnityEvent onPadAttach;
    public UnityEvent onPadDetach;
    public UnityEvent onStickAttach;
    public UnityEvent onStickDetach;

    public string curAttached;
    public string curDetached;
    public bool socketAttached;
    public int medCnt = 0;
    public string state = "";
    private List<string> ignore;
    private float start;
    private float end;
    private bool start_trigger = true;
    private bool time_trigger = true;
    private int max_med_cnt = 1;

    private bool isPlayingAnim = false;
    private static readonly int hashTimesUp = Animator.StringToHash("times_up");
    private static readonly int hashWoundCleansed = Animator.StringToHash("wound_cleansed");
    private static readonly int hashApplyOintment = Animator.StringToHash("applyOintment");
    private static readonly int hashTooMuchOintment = Animator.StringToHash("tooMuchOintment");
    private static readonly int hashRemoveMed = Animator.StringToHash("removeMed");
    private static readonly int hashStopCry = Animator.StringToHash("stopCry");
    private static readonly int hashTouchWound = Animator.StringToHash("touchWound");
    //private void DisplayState(string newState)
    //{
    //    display.text = newState;
    //}   

    void Update()
    {
        //DisplayState(state);
        if (time_trigger)
        {   
           end = Time.time;
           if((state == "dirtyWound"||state == "needMed") && end-start > 5){
               animator.SetTrigger(hashTimesUp);
               time_trigger = false;
           }
           else if(state == "needTape" && end - start > 5)
            {
                animator.SetTrigger(hashTouchWound);
                time_trigger = false;
                state = "tapeTooLate";
            }
        }
            
    }
    void Start()
    {
        ignore = new List<string>();
        curAttached = "";
        ignore.Add("Blood");
        ignore.Add("Player");
        socketAttached = false;
        state = "nothing";
        medCnt = 0;
        start_trigger = true;
        max_med_cnt = 1;
        //bleed, dirtyWound, needMed, tooMuchMed, needTape, tapeTooLate, finish
    }


    private void StopCry()
    {
        animator.SetTrigger(hashStopCry);
    }
    
    private void ApplyOintment()
    {
        if (isPlayingAnim)
        {
            return;
        }
        switch (state)
        {   
            case "needMed":
                animator.SetTrigger(hashApplyOintment);
                break;
            case "needTape":
                animator.SetTrigger(hashTooMuchOintment);
                break;
            case "tapeTooLate":
                animator.SetTrigger(hashTooMuchOintment);
                break;
        }
        isPlayingAnim = true;
    }
    //called by socket
    public void InvokeSocketAttach()
    {   
        socketAttached = true;
        if (curAttached == "Pad" && state == "bleed")
        {
            state = "dirtyWound";
            if(start_trigger){
               start = Time.time;
               time_trigger = true;
               start_trigger = false;
            }
            onPadAttach.Invoke();
        }
        else if (curAttached == "Bandage" && (state == "needTape"||state=="tapeTooLate"))
        {
            StopCry();
            state = "finish";
        }
        else if (curAttached == "Ointment")
        {
            string next_state = state;
            if (state == "needMed" || state == "needTape" || state == "tapeTooLate")
            {
                if (medCnt == max_med_cnt)
                {
                    next_state = "tooMuchMed";
                    time_trigger = false;
                }
                else
                {
                    medCnt += 1;
                    next_state = "needTape";
                    start_trigger = true;

                }
            }
            else if (state != "tooMuchMed")
            {
                return;
            }
            onMedAttach.Invoke();
            ApplyOintment();
            state = next_state;
        }
        else if(curAttached == "CottonSwab" && state == "tooMuchMed")
        {
            state = "needTape";
            start_trigger = true;
            animator.SetTrigger(hashRemoveMed);
            onStickAttach.Invoke();
        }
        //need change
        else if(curAttached == "CottonSwab" && state == "dirtyWound")
        {
            onStickAttach.Invoke();
            CleanWound();
        }
        //if (state == "needTape" && start_trigger)
        //{
        //    start = Time.time;
        //    time_trigger = true;
        //    start_trigger = false;
        //}

    }
    //called by socket
    public void InvokeSocketDetach()
    {
        socketAttached = false;

        if (curDetached == "Pad")
        {
            onPadDetach.Invoke();
        }
        else if(curDetached == "Ointment" && (state == "needTape"||state=="tooMuchMed"|| state == "tapeTooLate"))
        {
            onMedDetach.Invoke();
        }
        //after attach, state change from tooMuchMed to needTape  
        else if(curDetached == "CottonSwab" && (state == "needTape" || state == "tapeTooLate"||state=="needMed"))
        {
            onStickDetach.Invoke();
        }
        else if(curDetached=="Bandage" && state=="finish")
        {
            animator.SetTrigger(hashTouchWound);
            state = "needTape";
            max_med_cnt = 0;
        }
        if (state == "needTape" && start_trigger)
        {
            start = Time.time;
            time_trigger = true;
            start_trigger = false;
        }
    }
    //called ny button
    public void CleanWound()
    {
        if (state != "dirtyWound")
        {
            return;
        }
        animator.SetTrigger(hashWoundCleansed);
        state = "needMed";
        start = Time.time;
        time_trigger = true;
    }

    //called after animation: sit_idle end
    public void setBleedState()
    {
        state = "bleed";
    }
    //called after animation finish playing
    public void FinishPlayingAnim()
    {
        isPlayingAnim = false;
    }
    //called by collider
    private void OnTriggerEnter(Collider other)
    {
        string name = other.gameObject.name;
        string tag = other.gameObject.tag;
        if (ignore.Any(name.Contains) || ignore.Any(tag.Contains) || socketAttached)
        {
            return;
        }
        curAttached = other.name;
    }
    //called by collider
    private void OnTriggerExit(Collider other)
    {
        string name = other.gameObject.name;
        string tag = other.gameObject.tag;
        if (ignore.Any(name.Contains) || ignore.Any(tag.Contains) || !socketAttached)
        {
            return;
        }
        curDetached = other.name;
    }

}
