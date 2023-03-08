using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemy;
    public Camera cam;
    

    // Start is called before the first frame update
    void Start()
    {
        enemySpawn();
        cam = GetComponent<Camera>();
        
    }

    public void enemySpawn()
    {
        float randomXposition = 0;
        float randomYposition = 0;
        int randomSpawnZone = Random.Range(0, 4);
        switch (randomSpawnZone)
        {
            case 0:
                randomXposition = Random.Range(-0.2f, 1.2f);
                randomYposition = Random.Range(1.2f, 1.2f);
                break;
            case 1:
                randomXposition = Random.Range(-0.2f, 1.2f);
                randomYposition = Random.Range(-0.2f, -0.2f);
                break;
            case 2:
                randomXposition = Random.Range(-0.2f, -0.2f);
                randomYposition = Random.Range(-0.2f, 1.2f);
                break;
            case 3:
                randomXposition = Random.Range(1.2f, 1.2f);
                randomYposition = Random.Range(-0.2f, 1.2f);
                break;

        }

        Vector3 position = new Vector3(randomXposition, randomYposition, 10f);
        Vector3 spawnLocation = cam.ViewportToWorldPoint(position);
        Instantiate(enemy, spawnLocation, Quaternion.identity);
    }
}
