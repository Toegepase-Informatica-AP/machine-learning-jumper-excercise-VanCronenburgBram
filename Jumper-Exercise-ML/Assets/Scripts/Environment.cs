using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public Car carPrefab;
    public Reward rewardPrefab;
    private Player player;
    private TextMeshPro scoreBoard;
    private GameObject spawnObject;
    private readonly static System.Random random = new System.Random();

    public void OnEnable()
    {
        spawnObject = transform.Find("SpawnObject").gameObject;
        scoreBoard = transform.GetComponentInChildren<TextMeshPro>();
        player = transform.GetComponentInChildren<Player>();
    }

    private void FixedUpdate()
    {
        scoreBoard.text = player.GetCumulativeReward().ToString("f2");
    }

    public void ClearEnvironment()
    {
        foreach (Transform _object in spawnObject.transform)
        {
            Destroy(_object.gameObject);
        }
    }

    public void SpawnObject()
    {
        float randomObject = random.Next(1, 4);
        if (randomObject <= 2)
        {
            SpawnCar();
        }
        else
        {
            SpawnReward();
        }
    }

    public void SpawnCar()
    {
        GameObject newCar = Instantiate(carPrefab.gameObject);

        newCar.transform.SetParent(spawnObject.transform);
        newCar.transform.localPosition = new Vector3(-18.5f, 0.5f);
    }

    public void SpawnReward()
    {
        GameObject newReward = Instantiate(rewardPrefab.gameObject);

        newReward.transform.SetParent(spawnObject.transform);
        newReward.transform.localPosition = new Vector3(-18.5f, 2.5f);
    }
}