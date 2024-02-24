using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public bool isActive;
    public Animator anim;
    [HideInInspector]
    public CheckpointManager cpMan;
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player" && isActive==false)
        {
            cpMan.SetActiveCheckPoint(this);
            anim.SetBool("checkpointActive", true);
            isActive = true;
          
        }
    }
    public void DeactivateCheckpoint()
    {
        anim.SetBool("checkpointActive", false);
        isActive = false;
    }
}
