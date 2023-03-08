using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShipInputController : MonoBehaviour
{
    private ShipMovement movement;
    private SliderManager slider;
    private Vector2 movementInput;
    private Vector2 rotationInput;
    private ShipShooting fireLaser;
    [SerializeField]
    public float timeBetweenShots;
    private float lastFireTime;
    private int flightMode;
    private bool firing;
    private bool mouseMove;
    private bool combatMode;
    private bool zoomMode;
    private bool startZoom = true;
    private float zoomStartTime;

    void Awake()
    {
        movement = GetComponent<ShipMovement>();
        slider = GetComponent<SliderManager>();
        fireLaser = GetComponent<ShipShooting>();
    }

    void Update()
    {
        if(combatMode)
        {
            flightMode = 1;
            startZoom= false;
        }
        else if(zoomMode)
        {
            flightMode = 2;
            //slider.useBoost(1);

        }
        else
        {
            flightMode = 0;
            startZoom= false;
        }

        Debug.Log(zoomMode);

        movement.Move(movementInput);
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            mouseMove = true;
        }
        else
        {
            mouseMove= false;
        }

            movement.modeManager(rotationInput, movementInput, flightMode, mouseMove);


        if (firing)
        {
            float timeSinceLastFire = Time.time - lastFireTime;

            if (timeSinceLastFire >= timeBetweenShots)
            {
                fireLaser.Fire();
                lastFireTime = Time.time;
            }
        }
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    private void OnFire(InputValue inputValue)
    {
        firing = inputValue.isPressed;
    }

    private void OnLook(InputValue inputValue)
    {
        rotationInput = inputValue.Get<Vector2>();
    }

    private void OnChangeMode(InputValue inputValue)
    {
        if (flightMode == 1)
        {
            combatMode = false;
        }
        else
        {
            combatMode= true;
        }
    }

    private void OnZoomEngine(InputValue inputValue)
    {
        zoomMode = inputValue.isPressed;
        /*
        if (startZoom)
        {
            zoomStartTime = Time.time;
            startZoom= false;
        }
        */
    }

}
