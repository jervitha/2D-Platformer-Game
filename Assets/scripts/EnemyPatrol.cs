using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] PatrolPoints;
    private int currentPoint;
   [SerializeField]private float moveSpeed;
   [SerializeField]  private float timeAtPoints;
    private float waitCounter;
    private Animator anim;
    private const string ISMOVING = "ismoving";
    void Start()
    {
        foreach(Transform t in PatrolPoints)
        {
            t.SetParent(null);
        }
        waitCounter = timeAtPoints;
        anim=GetComponent<Animator>();
        anim.SetBool(ISMOVING, true);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, PatrolPoints[currentPoint].position, moveSpeed*Time.deltaTime);
        if(Vector3.Distance(transform.position,PatrolPoints[currentPoint].position)<0.001f)
        {
            waitCounter -= Time.deltaTime;
            anim.SetBool(ISMOVING, false);
            if (waitCounter <= 0)
            {
                currentPoint++;
                if (currentPoint >= PatrolPoints.Length)
                {
                    currentPoint = 0;
                }
                waitCounter = timeAtPoints;
                anim.SetBool(ISMOVING, true);
                if(transform.position.x<PatrolPoints[currentPoint].position.x)
                {
                    transform.localScale = Vector3.one;
                 
                }
                else
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                    
                }
            }
        }
    }
}
