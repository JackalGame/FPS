using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningVillage : MonoBehaviour
{
    [SerializeField] Transform enemyTranform;

    int numberOfEnemiesRemaining;

    private void Start()
    {
        numberOfEnemiesRemaining = 0;
        for(int i = 0; i < enemyTranform.childCount; i++)
        {
            numberOfEnemiesRemaining++;
        }
    }

    public void DecreaseEnemiesRemaining()
    {
        numberOfEnemiesRemaining--;
        if(numberOfEnemiesRemaining <= 0)
        {
            Debug.Log("LEVEL COMPLETE... No enemies remaining");
        }
    }
}
