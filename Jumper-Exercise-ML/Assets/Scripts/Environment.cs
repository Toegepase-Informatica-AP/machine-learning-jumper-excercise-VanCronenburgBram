using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public Car carPrefab;
    public Player playerPrefab;
    private Player player;
    private TextMeshPro scoreBoard;
    private GameObject spawnCar;
    private GameObject spawnPlayer;

    public void OnEnable()
    {
        spawnCar = transform.Find("SpawnCar").gameObject;
        //spawnPlayer = transform.Find("SpawnPlayer").gameObject;
        scoreBoard = transform.GetComponentInChildren<TextMeshPro>();
        player = transform.GetComponentInChildren<Player>();
    }

    private void FixedUpdate()
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
        newCar.transform.localPosition = new Vector3(-18.5f, 0.5f);
    }

    public void SpawnPlayer()
    {
        /*GameObject newPlayer = Instantiate(playerPrefab.gameObject);

        newPlayer.transform.SetParent(spawnPlayer.transform);
        newPlayer.transform.localPosition = new Vector3(22f, 0.5f);*/
        GameObject newPlayer = Instantiate(playerPrefab.gameObject);

        newPlayer.transform.SetParent(spawnPlayer.transform);
        newPlayer.transform.localPosition = new Vector3(22f, 0.5f);
        newPlayer.transform.localRotation = new Quaternion(0f, -90f, 0f, 0f);
    }
}