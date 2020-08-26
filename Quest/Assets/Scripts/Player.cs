using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] private float ver, hor;
    [SerializeField] private float speed = 10;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private float rayDistance = 100;
    [SerializeField] public LayerMask Ground;

    [SerializeField] GameObject light;
  
    [SerializeField] private LayerMask Things;

    RaycastHit hit;
    public bool isGround;
    Vector3 velocity;
   
    void Update()
    {
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

        Debug.DrawRay(MyRay.origin, MyRay.direction * 10, Color.yellow);
        if (Physics.Raycast(MyRay, out hit, rayDistance))
        {
            InteractiveThing();
            DestroyThing();
        }
    }

    public void InteractiveThing()
    {

        Interactible interactible = hit.collider.GetComponent<Interactible>();
        if (interactible != null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                light.gameObject.SetActive(false);
            }
        }
    }

    public void DestroyThing()
    {
        Destructible destructible = hit.collider.GetComponent<Destructible>();
        if (destructible != null)
        {
            Destroy(hit.collider.gameObject);
        }
    }
}
