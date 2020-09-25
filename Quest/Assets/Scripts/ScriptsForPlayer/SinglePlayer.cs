using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class SinglePlayer : SaveObject
{
    [NonSerialized] public CharacterController controller;
    [SerializeField] private float ver, hor;
    [SerializeField] private float speed = 10;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private float rayDistance = 3;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private GameObject screenKey;
    [SerializeField] private LayerMask Things;
    Interactible interactible;
    IDestructible destructible;
    RaycastHit hit;
    public bool isGround;
    Vector3 velocity;


    public Vector3 positinToSave;
    private void OnEnable()
    {
        Load();

        if (positinToSave != Vector3.zero)
        {
            transform.position = positinToSave;
        }
    }

    private void OnDisable()
    {
        positinToSave = transform.position;
        Save();
    }
    private void Awake()
    {
        controller = GetComponent<CharacterController>();

    }
    private void Start()
    {
        InputManager.Instance.Activate += InteractiveThing;
        InputManager.Instance.Deactivate += DestroyThing;

    }

    void Update()
    {

        MovePlayer();
        FindOutWhatisObject();
    }

    void MovePlayer()
    {
        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        ver = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");


        Vector3 move = transform.right * hor + transform.forward * ver;
        controller.Move(speed * Time.deltaTime * move);
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
        else if (interactible != null)
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
