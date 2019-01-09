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
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Run");
            rb.velocity = Vector3.forward * Speed;
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetTrigger("jump");
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        }

        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetTrigger("down");
        }
    }
}
