using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{

    bool visible = true;
    public float destroyTime = 5;
    float leftSightTime = 0;


    void Update()
    {
        if (!visible)
        {
            DespawnLaser();
        }
    }

    void DespawnLaser()
    {
        float timeSinceOutOfSight = Time.time - leftSightTime;
        
        if (timeSinceOutOfSight >= destroyTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        visible = false;
        leftSightTime = Time.time;
    }
}
