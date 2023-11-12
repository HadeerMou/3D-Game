using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderMovement : MonoBehaviour
{
    public float moveSpeed = 5;

    private Animator soliderAnimator;
    private float vertical;
    private PlayerMovement solider;
    private bool startMove;

    private void Awake()
    {
        solider = FindObjectOfType<PlayerMovement>();

        soliderAnimator = GetComponent<Animator>();
    }

    private IEnumerator Start()
    {
        yield return (new WaitForSeconds(3));
        startMove = true;
    }
    private void Update()
    {
        if (!startMove)
            return;
        vertical = Input.GetAxisRaw("Vertical");

        Move();
        Turn();
    }

    private void Move()
    {
        //Running
        if(vertical != 0)
        {
            soliderAnimator.SetBool("Running", true);
            soliderAnimator.SetFloat("Direction", vertical);

            transform.position += transform.forward * vertical * moveSpeed * Time.deltaTime;
        }
        else
        {
            soliderAnimator.SetBool("Running", false);
        }
    }

    private void Turn()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit groundHit;

        if(Physics.Raycast(cameraRay, out groundHit, Mathf.Infinity)) 
        { 
            Vector2 playerToMouse = groundHit.point - transform.position;
            playerToMouse.y = 0;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);  //rotation to mouse
            transform.rotation = newRotation; 
        }
    }
}
