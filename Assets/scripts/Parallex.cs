using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallex : MonoBehaviour
{
    private Transform theCam;
   [SerializeField]private Transform sky, plants;
    [Range(0f,1f)]
    [SerializeField]private float parallexSpeed;

    private void Start()
    {
        theCam = Camera.main.transform;

    }

    private void LateUpdate()
    {
        sky.position = new Vector3(theCam.position.x, theCam.position.y, sky.position.z);
        plants.position = new Vector3(theCam.position.x * parallexSpeed, theCam.position.y , plants.position.z);
    }

}
