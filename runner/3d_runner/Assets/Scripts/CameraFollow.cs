using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float smoothRate;

    Vector3 offset;
    void Start()
    {
        offset = player.position - transform.position;   
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 currentpos = transform.position;
        Vector3 newpos = player.position - offset;

        transform.position = Vector3.Lerp(currentpos, newpos, smoothRate);
    }
}
