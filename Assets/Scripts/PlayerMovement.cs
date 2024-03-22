using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    private Vector3 move; //vector to hold direction of movement
    private CharacterController controller;  //character controller componenet
    private Vector3 playerVelocity; //player gravity
    private float playerSpeed = 10.0f;  //player speed
    private float gravityValue = -9.81f; //gravity
    public Vector3 spawn; //spawnpoint

    void Start()
    {   
        controller = GetComponent<CharacterController>();
        GameObject.Find("PlayerCount").GetComponent<Players>().newSpawn = true;
    }
    void Awake()
    {

    }
    void OnMove(InputValue value)
    {
        move = new Vector3(value.Get<Vector2>().x,0,value.Get<Vector2>().y);
    }


    void FixedUpdate()
    {

    }
    void Update()
    {
        controller.Move(move * Time.deltaTime * playerSpeed); //move player

        playerVelocity.y += gravityValue * Time.deltaTime;  //appply gravity to player
        controller.Move(playerVelocity * Time.deltaTime);  //
    }
    public void resetPosition()
    {
        if (IsServer) { transform.position = spawn; }
    }
}
