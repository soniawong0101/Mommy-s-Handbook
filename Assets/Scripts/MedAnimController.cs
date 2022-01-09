using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedAnimController : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    private bool isPlayingAnim = false;
    //private Controls controls;
    private static readonly int hashAddingMed = Animator.StringToHash("addingMed");
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
    public void MedMove()
    {
        if(isPlayingAnim)
        {
            return;
        }
        animator.SetTrigger(hashAddingMed);
        isPlayingAnim = true;
    }
    public void FinishPlayingAnim()
    {
        isPlayingAnim = false;
    }
}
