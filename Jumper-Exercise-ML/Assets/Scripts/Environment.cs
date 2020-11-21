using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public Car carPrefab;
    private Player player;
    private TextMeshPro scoreBoard;
    private GameObject spawnCar;

    public void OnEnable()
    {
        spawnCar = transform.Find("SpawnCar").gameObject;
        scoreBoard = transform.GetComponentInChildren<TextMeshPro>();
        player = transform.GetComponentInChildren<Player>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreBoard.text = player.GetCumulativeReward().ToString("f2");
    }

    public void ClearEnvironment()
    {
        foreach (Transform car in spawnCar.transform)
        {
            Destroy(car.gameObject);
        }
    }

    public void SpawnCar()
    {
        GameObject newCar = Instantiate(carPrefab.gameObject);

        newCar.transform.SetParent(spawnCar.transform);
        newCar.transform.localPosition = new Vector3(-18.5f, 1f);
    }
}
