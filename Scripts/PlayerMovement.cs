using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;

    private Animator playerAnimator;
    private float vertical;

    private void Awake()
    {
        playerAnimator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        vertical = Input.GetAxis("Vertical");

        Move();
        Turn();
    }

    private void Move()
    {
        //Running
        if (vertical != 0)
        {
            playerAnimator.SetBool("Running", true);
            playerAnimator.SetFloat("Direction", vertical);

            transform.position += transform.forward * vertical * moveSpeed * Time.deltaTime;
        }
        else
        {
            playerAnimator.SetBool("Running", false);
        }
    }

    private void Turn()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit groundHit;

        if (Physics.Raycast(cameraRay, out groundHit, Mathf.Infinity))
        {
            Vector2 playerToMouse = groundHit.point - transform.position;
            playerToMouse.y = 0;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);  //rotation to mouse
            transform.rotation = newRotation;
        }
    }
}

