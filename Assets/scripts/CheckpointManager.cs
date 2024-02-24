using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public CheckPoints[] allCP;
    private CheckPoints activeCP;
    public Vector3 respawnPoint;
    void Start()
    {
        allCP = FindObjectsByType<CheckPoints>(FindObjectsSortMode.None);
        foreach (CheckPoints cp in allCP)
        {
            cp.cpMan = this;
        }
        respawnPoint = FindFirstObjectByType<CharcterController>().transform.position;
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
