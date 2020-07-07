using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CutableSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] cutables;

    private Transform outermostLine;
    private Transform midLine;
    private Transform closestLine;
    private Vector3 outermostLinePos;
    private Vector3 midLinePos;
    private Vector3 closestLinePos;
    
    
    float spawnIntervalRandomizer;
    float maxInterval = 5f;
    float minInterval = 1f;
    bool availableToBeSent = true;

    public float longestSpawnProb;
    public float secondLongestSpawnProb;
    public float thirdLongestSpawnProb;
    public float fourthLongestSpawnProb;
    public float fifthLongestSpawnProb;
    public float sixthLongestSpawnProb;


    private void Start()
    {
        InitialPositionsForSpawner();
    }

    private void InitialPositionsForSpawner()
    {
        outermostLine = GameObject.FindGameObjectWithTag("OutermostLine").transform;
        midLine = GameObject.FindGameObjectWithTag("MidLine").transform;
        closestLine = GameObject.FindGameObjectWithTag("ClosestLine").transform;
        outermostLinePos = outermostLine.position;
        midLinePos = midLine.position;
        closestLinePos = closestLine.position;
    }

    private void Update()
    {
        if (availableToBeSent)
        {
            StartCoroutine(SpawnCutableCoroutine());
        }
    }
    private float IntervalRandomizer()
    {
        spawnIntervalRandomizer = Random.Range(minInterval, maxInterval);
        return spawnIntervalRandomizer;
    }

    private float ZPosRandomizer()
    {
        float spawnZPosRandomizer= Random.Range(0f,3f);
        if (spawnZPosRandomizer <= 1)
            return closestLinePos.z;
        if (spawnZPosRandomizer <= 2)
        {
            return midLinePos.z;
        }
        return outermostLinePos.z;
    }
    
    private IEnumerator SpawnCutableCoroutine()
    {
        availableToBeSent = false;
        GameObject nextCutable = CutableTypeRandomizer();
        yield return new WaitForSeconds(transform.localScale.y);
        Instantiate(nextCutable, new Vector3(10,1,ZPosRandomizer()),Quaternion.Euler(0f,0f,90f));
        availableToBeSent = true;
        //Invoke("MakeAvailabilitTrue",nextCutable.transform.localScale.y);

    }

    private void MakeAvailabilitTrue()
    {
        availableToBeSent = true;
    }
    
    private GameObject CutableTypeRandomizer()
    {
        float randomizerFactor = Random.Range(0f, 100f);
        if(randomizerFactor < longestSpawnProb)
        {
            return cutables[0];
        } 
        if (randomizerFactor < longestSpawnProb + secondLongestSpawnProb)
        {
            return cutables[1];
        }
        if(randomizerFactor < longestSpawnProb+secondLongestSpawnProb+thirdLongestSpawnProb)
        {
            return cutables[2];
        }
        if (randomizerFactor <
            longestSpawnProb + secondLongestSpawnProb + thirdLongestSpawnProb + fourthLongestSpawnProb)
        {
            return cutables[3];
        }
        if (randomizerFactor <
            longestSpawnProb + secondLongestSpawnProb + thirdLongestSpawnProb + fourthLongestSpawnProb+fifthLongestSpawnProb)
        {
            return cutables[4];
        }
        return cutables[5];
    }
    
}
