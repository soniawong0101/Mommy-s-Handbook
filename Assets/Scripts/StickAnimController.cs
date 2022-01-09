using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickAnimController : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    private bool isPlayingAnim = false;
    //private Controls controls;
    private static readonly int hashRomoveMed = Animator.StringToHash("removeMed");
    private static readonly int hashExit = Animator.StringToHash("exit");
    // Start is called before the first frame update
    void Start()
    {
        isPlayingAnim = false;
    }
    public void ExitAnim()
    {
        if (isPlayingAnim)
        {
            return;
        }
        animator.SetTrigger(hashExit);
    }
    public void StickMove()
    {
        if(isPlayingAnim)
        {
            return;
        }
        animator.SetTrigger(hashRomoveMed);
        isPlayingAnim = true;
    }
    public void FinishPlayingAnim()
    {
        isPlayingAnim = false;
    }
}
