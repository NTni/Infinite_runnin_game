using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;

    [SerializeField]
    float Speed;

    [SerializeField]
    float jumpForce;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        rb.velocity = Vector3.forward * Speed;
    }

    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("idle");    
        }*/

        if (Input.GetMouseButtonDown(1))
        {
            anim.SetTrigger("jump");
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        }
    }
}
