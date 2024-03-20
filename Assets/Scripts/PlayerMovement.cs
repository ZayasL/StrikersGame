using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 move;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private float playerSpeed = 10.0f;
    private float gravityValue = -9.81f;
    public Transform spawn;

    public Material RED;
    public Material BLUE;

    private void Start()
    {
        int bluePlayers = GameObject.Find("PlayerCount").GetComponent<Players>().blue.Count;
        int redPlayers = GameObject.Find("PlayerCount").GetComponent<Players>().red.Count;
        if(redPlayers >= bluePlayers)
        {
            spawn = GameObject.Find("BlueSpawn").transform;
            gameObject.tag = "blue";
            GameObject.Find("PlayerCount").GetComponent<Players>().blue.Add(gameObject);
            GetComponent<Renderer>().material = BLUE;
        }
        else{
            spawn = GameObject.Find("RedSpawn").transform;
            gameObject.tag = "red";
            GameObject.Find("PlayerCount").GetComponent<Players>().red.Add(gameObject);
            GetComponent<Renderer>().material = RED;
        }
        controller = GetComponent<CharacterController>();
        transform.position = spawn.position;
        
    }
    void OnMove(InputValue value)
    {
        move = new Vector3(value.Get<Vector2>().x,0,value.Get<Vector2>().y);
    }

    void Update()
    {
        controller.Move(move * Time.deltaTime * playerSpeed);

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
