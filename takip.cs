using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takip : MonoBehaviour
{
    public float distance;
    public float follow_distance;
    public Transform player;
    Vector3 velocity;
    private CharacterController controller;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);

        if(distance<=follow_distance)
        {
            transform.LookAt(player.position);
            velocity.z += 5f;
            velocity.y = 0f;
        }

        else
        {
            transform.LookAt(player.position);
            velocity.z += 0f;
            velocity.y = 0f;

        }

        controller.Move(velocity);


    }
}
