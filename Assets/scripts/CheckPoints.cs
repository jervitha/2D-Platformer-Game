using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    
    [SerializeField]private bool isActive;
    public Animator anim;
    [HideInInspector]
    public CheckpointManager cpMan;
    private const string CHECKPOINTACTIVE = "checkpointActive";



    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.GetComponent<CharcterController>() != null && isActive==false)
        {
          if (cpMan != null)
            {
                cpMan.SetActiveCheckPoint(this);
                anim.SetBool(CHECKPOINTACTIVE, true);
                isActive = true;
            }
          
        }
    }
    public void DeactivateCheckpoint()
    {
        anim.SetBool(CHECKPOINTACTIVE, false);
        isActive = false;
    }
}

