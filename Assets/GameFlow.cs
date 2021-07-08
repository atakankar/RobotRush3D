using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public Transform wayObj;
    private Vector3 nextWaySpawn;
    public Transform barrierObj;
    private Vector3 nextBarrierSpawn;
    private int randX;

    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        nextWaySpawn.z = 15;
        StartCoroutine(swampWay());
    }

    // Update is called once per frame
    void Update()
    {
        EndGame();
    }

    IEnumerator swampWay()
    {
        PlayerStats.PlayerPoint++;
        yield return new WaitForSeconds( 3/PlayerStats.PlayerSpeed);
        randX = Random.Range(-1, 2);
        nextBarrierSpawn = nextWaySpawn;
        nextBarrierSpawn.x = randX;
        nextBarrierSpawn.y = 0.6f;
        Instantiate(wayObj, nextWaySpawn, wayObj.rotation);
        Instantiate(barrierObj, nextBarrierSpawn, barrierObj.rotation);
        nextWaySpawn.z += 3;
        StartCoroutine(swampWay());
    }

    void EndGame()
    {
        if (PlayerStats.Healt <= 0)
        {
            Time.timeScale = 0;
            gameOverUI.SetActive(true);
        }
    }
}
