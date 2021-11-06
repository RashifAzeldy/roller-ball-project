using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCollector : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public CoinSpawner coinSpawner;

    int currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    void MoveCoin(List<SpawnPoint> spawnPoints, CoinScript coin)
    {
        int randomIndex = Random.Range(0, spawnPoints.Count);

        do
        {
            randomIndex = Random.Range(0, spawnPoints.Count);
        } while (spawnPoints[randomIndex].status == true);

        spawnPoints[coin.positionIndex].status = false;
        spawnPoints[randomIndex].status = true;
        coin.positionIndex = randomIndex;
        coin.transform.position = spawnPoints[randomIndex].point.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        currentScore += other.GetComponentInParent<CoinScript>().score;
        scoreText.text = currentScore.ToString();
        MoveCoin(coinSpawner.spawnPoints, other.GetComponentInParent<CoinScript>());
    }
}
