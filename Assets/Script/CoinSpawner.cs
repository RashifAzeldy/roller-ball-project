using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

    //public List<GameObject> spawnedCoins = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            int randomIndex = Random.Range(0, spawnPoints.Count);

            do
            {
                randomIndex = Random.Range(0, spawnPoints.Count);
            } while (spawnPoints[randomIndex].status == true);

            Spawn(randomIndex, spawnPoints);
        }
    }

    void Spawn(int index, List<SpawnPoint> points)
    {
        GameObject coin = Instantiate(coinPrefab, points[index].point.position, Quaternion.identity);
        points[index].status = true;
        coin.GetComponent<CoinScript>().positionIndex = index;
        //spawnedCoins.Add(coin);
    }
}

[System.Serializable]
public class SpawnPoint
{
    public Transform point;
    public bool status;
}