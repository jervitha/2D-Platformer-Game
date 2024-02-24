using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public float offsetsmoothing;
    private Vector3 playerposition;
   
    void LateUpdate()
    {
        playerposition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        if(player.transform.localScale.x>0f)
        {
            playerposition = new Vector3(playerposition.x + offset, playerposition.y,playerposition.z);

        }
        else
        {
            playerposition = new Vector3(playerposition.x - offset, playerposition.y, playerposition.z);
        }

        transform.position = Vector3.Lerp(transform.position, playerposition, offsetsmoothing * Time.deltaTime);
    }
}
