using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{

    public GameObject laserPrefab;

    [SerializeField]
    private float laserSpeed;

    [SerializeField]
    private Transform gunOffset;


    public void Fire()
    {
        GameObject laser = Instantiate(laserPrefab, gunOffset.position, transform.rotation);
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        rb.velocity = laserSpeed * transform.up;
    }
}
