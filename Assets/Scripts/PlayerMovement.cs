using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 move; //vector to hold direction of movement
    private CharacterController controller;  //character controller componenet
    private Vector3 playerVelocity; //player gravity
    private float playerSpeed = 10.0f;  //player speed
    private float gravityValue = -9.81f; //gravity
    public Transform spawn; //spawnpoint

    public Material RED;  //red team color
    public Material BLUE; //blue team color

    private void Start()
    {
        int bluePlayers = GameObject.Find("PlayerCount").GetComponent<Players>().blue.Count;
        int redPlayers = GameObject.Find("PlayerCount").GetComponent<Players>().red.Count;

        //if more red players than blue, place player into red
        if(redPlayers >= bluePlayers)
        {
            spawn = GameObject.Find("BlueSpawn").transform;
            gameObject.tag = "blue";
            GameObject.Find("PlayerCount").GetComponent<Players>().blue.Add(gameObject);
            GetComponent<Renderer>().material = BLUE;
        }
        //else place player into blue team
        else{
            spawn = GameObject.Find("RedSpawn").transform;
            gameObject.tag = "red";
            GameObject.Find("PlayerCount").GetComponent<Players>().red.Add(gameObject);
            GetComponent<Renderer>().material = RED;
        }
        controller = GetComponent<CharacterController>();
        transform.position = spawn.position; //teleport player to spawnpoint
        
    }
    void OnMove(InputValue value)
    {
        move = new Vector3(value.Get<Vector2>().x,0,value.Get<Vector2>().y);
    }

    void Update()
    {
        controller.Move(move * Time.deltaTime * playerSpeed); //move player

        playerVelocity.y += gravityValue * Time.deltaTime;  //appply gravity to player
        controller.Move(playerVelocity * Time.deltaTime);  //
    }
}
