using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    void Update()
    {
        int DistanceAway = 10;
        Vector3 PlayerPOS = GameObject.Find("Player").transform.transform.position;
        GameObject.Find("MainCamera").transform.position = new Vector3(PlayerPOS.x, PlayerPOS.y, PlayerPOS.z - DistanceAway);
    }
}
