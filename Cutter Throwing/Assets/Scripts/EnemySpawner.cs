using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] float[] Sizes;

    private Transform outermostLine;
    private Transform midLine;
    private Transform closestLine;

    private Vector3 outermostLinePos;
    private Vector3 midLinePos;
    private Vector3 closestLinePos;

    float spawnIntervalRandomizer;
    float maxInterval = 5f;
    float minInterval = 1f;
    bool spawnAvailable = true;

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
        if (spawnAvailable)
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
        spawnAvailable = false;
        float size = EnemySize();
        yield return new WaitForSeconds(transform.localScale.y);
        GameObject go = Instantiate(Enemy);
        go.transform.position = new Vector3(10, 1, ZPosRandomizer());
        go.transform.localScale = new Vector3(size, .6f, .6f);
        spawnAvailable = true;
    }

    private float EnemySize()
    {
        float randomizerFactor = Random.Range(0f, 100f);
        if(randomizerFactor < longestSpawnProb)
        {
            return Sizes[0];
        }
        if (randomizerFactor < longestSpawnProb + secondLongestSpawnProb)
        {
            return Sizes[1];
        }
        if(randomizerFactor < longestSpawnProb + secondLongestSpawnProb + thirdLongestSpawnProb)
        {
            return Sizes[2];
        }
        if (randomizerFactor < longestSpawnProb + secondLongestSpawnProb + thirdLongestSpawnProb + fourthLongestSpawnProb)
        {
            return Sizes[3];
        }
        if (randomizerFactor < longestSpawnProb + secondLongestSpawnProb + thirdLongestSpawnProb + fourthLongestSpawnProb+fifthLongestSpawnProb)
        {
            return Sizes[4];
        }
        return Sizes[5];
    }

}
