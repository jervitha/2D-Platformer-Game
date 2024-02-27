/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    // public CheckPoints[] allCP;
  [SerializeField] private CheckPoints[] allCP;
    private CheckPoints activeCP;
   // public Vector3 respawnPoint;
   [SerializeField] private Vector3 respawnPoint;
    [SerializeField] private LayerMask checkpointLayer;
    [SerializeField] private int radius;
  
    void Start()
     {
         //allCP = FindObjectsByType<CheckPoints>(FindObjectsSortMode.None);
         if (allCP != null && allCP.Length>0)
         {
             foreach (CheckPoints cp in allCP)
             {
                 cp.cpMan = this;
             }
         }
         CharcterController charcterController =GetComponent<CharcterController>();
         //CharcterController charcterController = FindFirstObjectByType<CharcterController>();
         respawnPoint = charcterController.transform.position;
     }

    /*void Start()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, checkpointLayer);

        allCP = new CheckPoints[colliders.Length];

        for (int i = 0; i < colliders.Length; i++)
        {
            allCP[i] = colliders[i].GetComponent<CheckPoints>();
        }

        // Now 'allCP' contains all the 'CheckPoints' within the specified radius.
    }*/

/*public Vector3 RespawnPoint
{
    get { return respawnPoint; }
}

public void DeactivateAllCheckpoints()
{
    foreach(CheckPoints cp in allCP)
    {
        cp.DeactivateCheckpoint();
    }
}

public void SetActiveCheckPoint(CheckPoints newactiveCP)
{
    DeactivateAllCheckpoints();
    activeCP = newactiveCP;
    respawnPoint = newactiveCP.transform.position;
}
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] private CheckPoints[] allCP;
    private CheckPoints activeCP;
    [SerializeField] private Vector3 respawnPoint;
    [SerializeField] private LayerMask checkpointLayer;
    [SerializeField] private int radius;
    [SerializeField] private CharcterController charcterController;

    void Start()
    {
       

        if (charcterController == null)
        {
            
            return;
        }

        if (allCP != null && allCP.Length > 0)
        {
            foreach (CheckPoints cp in allCP)
            {
                cp.cpMan = this;
            }
        }

        respawnPoint = charcterController.transform.position;
    }

 
public Vector3 RespawnPoint
    {
        get { return respawnPoint; }
    }

    public void DeactivateAllCheckpoints()
    {
        foreach (CheckPoints cp in allCP)
        {
            cp.DeactivateCheckpoint();
        }
    }

    public void SetActiveCheckPoint(CheckPoints newactiveCP)
    {
        DeactivateAllCheckpoints();
        activeCP = newactiveCP;
        respawnPoint = newactiveCP.transform.position;
    }
}
