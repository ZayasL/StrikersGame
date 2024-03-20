using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    public Vector3 direction;    //vector 3 to hold hit direction
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnAim(InputValue value)
    {
        if (value.Get<Vector2>() != Vector2.zero)    //only update direction of aiming when the stick is at a non zero vector position
        {
            direction = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
        }
    }
}
