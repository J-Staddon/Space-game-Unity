using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    private Rigidbody2D rb;
    private Animator animator;
    private int flightMode = 0;
    private float modeSpeedModifier = 1;
    Quaternion targetRotation;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 change)
    {
        rb.velocity = change * movementSpeed * modeSpeedModifier;


        if (change != Vector2.zero)
        {

            switch (flightMode)
            {
                case 0:
                    animator.SetBool("moving", true);
                    animator.SetBool("zoomMode", false);
                    break;
                 case 1:
                    animator.SetBool("moving", false);
                       break;
                case 2:
                    animator.SetBool("moving", true);
                    animator.SetBool("zoomMode", true);
                    break;
            }
        }
        else
        {
            animator.SetBool("moving", false);
            animator.SetBool("zoomMode", false);
        }
    }

    void rotateShip()
    {
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        rb.MoveRotation(rotation);
    }

    public void modeManager(Vector2 rotationInput, Vector2 change, int mode, bool mouseMove = false)
    {
        flightMode = mode;
            switch (flightMode)
            {
                case 0:
                modeSpeedModifier = 1;
                if (change != Vector2.zero)
                    {
                        targetRotation = Quaternion.LookRotation(transform.forward, change);
                    }
                    break;
                case 1:
                modeSpeedModifier = 0.4f;
                if (rotationInput != Vector2.zero)
                    {
                        targetRotation = Quaternion.LookRotation(transform.forward, rotationInput);
                    }

                else if(mouseMove)
                {
                    var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
                    var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
                    targetRotation = transform.rotation;
                }
                    break;
                case 2:
                    modeSpeedModifier = 2f;
                if (change != Vector2.zero)
                {
                    targetRotation = Quaternion.LookRotation(transform.forward, change);
                }

                break;
        }


        rotateShip();
    }
}
