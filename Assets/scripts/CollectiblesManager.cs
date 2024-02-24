using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesManager : MonoBehaviour
{
    public static CollectiblesManager instance;
    private void Awake()
    {
        instance = this;
    }

    public int CollectiblesCount;

    public int extraLifeThreshold;



    public void GetCollelctibles(int amount)
    {
        CollectiblesCount += amount;
        if(CollectiblesCount>=extraLifeThreshold)
        {
            CollectiblesCount -= extraLifeThreshold;
            if(LifeController.instance!=null)
            {
                LifeController.instance.AddLife();
            }

        }
        if(UIController.instance!=null)
        {
            UIController.instance.UpdateCollectibles(CollectiblesCount);
        }

    }
}
