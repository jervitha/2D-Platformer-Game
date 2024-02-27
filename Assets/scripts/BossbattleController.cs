/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossbattleController : MonoBehaviour
{

    private bool bossActive;
    //public GameObject blockers;
    [SerializeField] private GameObject blockers;
    //public Transform theBoss;
    [SerializeField]private Transform theBoss;
   // public float bossGrowSpeed = 2f;
    [SerializeField]private float bossGrowSpeed = 2f;
   // public Transform projectileLauncher;
   [SerializeField]private Transform projectileLauncher;
    //public float launcherGrowSpeed=2f;
    [SerializeField] private float launcherGrowSpeed = 2f;
    //public float launcherRotateSpeed;
   [SerializeField] public float launcherRotateSpeed;
    private float launcherRotation;
    //public GameObject projectileToFire;
   [SerializeField] private GameObject projectileToFire;
    [SerializeField] private Transform[] projectilePoints;
    //public float waitToStartShooting, timeBetweenShots;
   [SerializeField] public float waitToStartShooting, timeBetweenShots;
    private float shootStartCounter, shotCounter;
    private int currentShot;
    public Animator theBossAnim;
    private bool isWeak;
    private int currentPhase;
   [SerializeField] public GameObject deathEffect;
  //  private GameObject deathEffect;

    void Start()
    {
        shootStartCounter = waitToStartShooting;
        blockers.transform.SetParent(null);

    }

  
    void Update()
    {
        if(bossActive==true)
        {
            if(theBoss.localScale!=Vector3.one)
            {
                theBoss.localScale = Vector3.MoveTowards(
                    theBoss.localScale,
                    Vector3.one,
                    bossGrowSpeed * Time.deltaTime);
            }

            if(projectileLauncher.transform.localScale!=Vector3.one)
            {
               projectileLauncher.localScale = Vector3.MoveTowards(
                  projectileLauncher.localScale,
                   Vector3.one,
                   bossGrowSpeed * Time.deltaTime);
            }
        }

        launcherRotation += launcherRotateSpeed * Time.deltaTime;
        if(launcherRotation>360f)
        {
            launcherRotation -= 360f;
        }
        projectileLauncher.transform.rotation = Quaternion.Euler(0f, 0f, launcherRotation);
        //start shooting
        if(shootStartCounter>0f)
        {
            shootStartCounter -= Time.deltaTime;
            if(shootStartCounter<0f)
            {
                shotCounter = timeBetweenShots;
                FireShot();
               
            }
        }

        if(shotCounter>0f)
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter<=0f)
            {
                shotCounter = timeBetweenShots;
                FireShot();
            }
        }
    }

    public void ActivateBattle()
    {
        bossActive = true;
        blockers.SetActive(true);
        AudioManager.instance.PlayLevelMusic(1);
    }
    void FireShot()
    {
        Instantiate(projectileToFire, projectilePoints[currentShot].position, projectilePoints[currentShot].rotation);
        projectilePoints[currentShot].gameObject.SetActive(false);
        currentShot++;
        if(currentShot>=projectilePoints.Length)
        {
            shotCounter = 0f;
            MakeWeak();
        }
    }

    void MakeWeak()
    {
        theBossAnim.SetTrigger("isweak");
        isWeak = true;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        // if(other.gameObject.CompareTag("Player"))
        if (other.gameObject.GetComponent<CharcterController>() != null)
        {
            if(isWeak==false)
            {
                PlayerHealth.instance.DamagePlayer();
              
            }
            else
            {
                if(other.transform.position.y>theBoss.transform.position.y)
                {
                   FindFirstObjectByType<CharcterController>().Jump();
                   // FindFirstObjectByType<CharcterController>().Jump();
                    MoveToNextPhase();
                    
                    

                }
            }
        }
    }

    private void MoveToNextPhase()
    {
        currentPhase++;
        if(currentPhase<3)
        {
            isWeak = false;
            waitToStartShooting *= 0.5f;
            timeBetweenShots *= 0.75f;
            shootStartCounter = waitToStartShooting;
            projectileLauncher.localScale = Vector3.zero;
            foreach(Transform point in projectilePoints)
            {
                point.gameObject.SetActive(true);
            }
            currentShot = 0;
        }
        else
        {
            gameObject.SetActive(false);
            blockers.SetActive(false);
            Instantiate(deathEffect, theBoss.position, Quaternion.identity);
          
        }
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossbattleController : MonoBehaviour
{
    private bool bossActive;
    [SerializeField] private GameObject blockers;
    [SerializeField] private Transform theBoss;
    [SerializeField] private float bossGrowSpeed = 2f;
    [SerializeField] private Transform projectileLauncher;
    [SerializeField] private float launcherGrowSpeed = 2f;
    [SerializeField] private float launcherRotateSpeed;
    private float launcherRotation;
    [SerializeField] private GameObject projectileToFire;
    [SerializeField] private Transform[] projectilePoints;
    [SerializeField] private float waitToStartShooting, timeBetweenShots;
    private float shootStartCounter, shotCounter;
    private int currentShot;
    public Animator theBossAnim;
    private bool isWeak;
    private int currentPhase;
    [SerializeField] private GameObject deathEffect;
    private const string ISWEAK = "isweak";

    void Start()
    {
        shootStartCounter = waitToStartShooting;
        blockers.transform.SetParent(null);
    }

    void Update()
    {
        if (bossActive == true)
        {
            if (theBoss.localScale != Vector3.one)
            {
                theBoss.localScale = Vector3.MoveTowards(
                    theBoss.localScale,
                    Vector3.one,
                    bossGrowSpeed * Time.deltaTime);
            }

            if (projectileLauncher.transform.localScale != Vector3.one)
            {
                projectileLauncher.localScale = Vector3.MoveTowards(
                  projectileLauncher.localScale,
                   Vector3.one,
                   bossGrowSpeed * Time.deltaTime);
            }
        }

        launcherRotation += launcherRotateSpeed * Time.deltaTime;
        if (launcherRotation > 360f)
        {
            launcherRotation -= 360f;
        }
        projectileLauncher.transform.rotation = Quaternion.Euler(0f, 0f, launcherRotation);

        if (shootStartCounter > 0f)
        {
            shootStartCounter -= Time.deltaTime;
            if (shootStartCounter < 0f)
            {
                shotCounter = timeBetweenShots;
                FireShot();
            }
        }

        if (shotCounter > 0f)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0f)
            {
                shotCounter = timeBetweenShots;
                FireShot();
            }
        }
    }

    public void ActivateBattle()
    {
        bossActive = true;
        blockers.SetActive(true);
     
    }

    void FireShot()
    {
        Instantiate(projectileToFire, projectilePoints[currentShot].position, projectilePoints[currentShot].rotation);
        projectilePoints[currentShot].gameObject.SetActive(false);
        currentShot++;
        if (currentShot >= projectilePoints.Length)
        {
            shotCounter = 0f;
            MakeWeak();
        }
    }

    void MakeWeak()
    {
        theBossAnim.SetTrigger(ISWEAK);
        isWeak = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        CharcterController playerController = other.gameObject.GetComponent<CharcterController>();

        if (playerController != null)
        {
            if (isWeak == false)
            {
                PlayerHealth.instance.DamagePlayer();
            }
            else
            {
                if (other.transform.position.y > theBoss.transform.position.y)
                {
                    playerController.Jump();
                    MoveToNextPhase();
                }
            }
        }
    }

    private void MoveToNextPhase()
    {
        currentPhase++;
        if (currentPhase < 3)
        {
            isWeak = false;
            waitToStartShooting *= 0.5f;
            timeBetweenShots *= 0.75f;
            shootStartCounter = waitToStartShooting;
            projectileLauncher.localScale = Vector3.zero;
            foreach (Transform point in projectilePoints)
            {
                point.gameObject.SetActive(true);
            }
            currentShot = 0;
        }
        else
        {
            gameObject.SetActive(false);
            blockers.SetActive(false);
            Instantiate(deathEffect, theBoss.position, Quaternion.identity);
        }
    }
}
