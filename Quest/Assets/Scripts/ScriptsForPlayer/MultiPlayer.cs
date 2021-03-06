﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MultiPlayer : GenericSingletonClass<MultiPlayer>
{
    public CharacterController controller;
    [SerializeField] private float ver, hor;
    [SerializeField] private float speed = 10;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private float rayDistance = 10;
    [SerializeField] public LayerMask Ground;
    [SerializeField] public GameObject screenKey;
    //[SerializeField] GameObject light;
    [SerializeField] GameObject cameraMain;
  
    [SerializeField] private LayerMask Things;
    Interactible interactible;
    IDestructible destructible;
    RaycastHit hit;
    public bool isGround;
    Vector3 velocity;
    private PhotonView photonView;
    

    public void Start()
    {
        photonView = GetComponent<PhotonView>();
        cameraMain.gameObject.SetActive(true);
        InputManager.Instance.Activate += InteractiveThing;
        InputManager.Instance.Deactivate += DestroyThing;

    }

    void Update()
    {
        if (!photonView.IsMine) return;
        MovePlayer();
        FindOutWhatisObject();
    }

    void MovePlayer()
    {
       

        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, Ground);
        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        ver = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");


        Vector3 move = transform.right * hor + transform.forward * ver;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }


    public void FindOutWhatisObject()
    {
        Ray MyRay;
        MyRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(MyRay.origin, MyRay.direction, Color.yellow);

        if (Physics.Raycast(MyRay, out hit, rayDistance, Things))
        {
            var hitObj = hit.collider.gameObject;
            if (hitObj)
            {
                destructible = hitObj.GetComponent<IDestructible>();
                interactible = hitObj.GetComponent<Interactible>();
                Hint();
            }
        }
        else if(interactible!= null)
        {
            interactible.ClearHint();
            interactible = null;
        }

    }
    public void Hint()
    {
        if (interactible != null)
        {
            interactible.ShowHint();
        }

    }
    public void InteractiveThing()
    {
        if (interactible != null)
        {
            interactible.DoActivate();
        }
    }

    public void DestroyThing()
    {

        if (destructible != null)
        {
            destructible.DestroyObjects();

        }
    }
}
