using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalMovement : MonoBehaviour
{
    Transform origin;  //original position of object
    // Start is called before the first frame update
    void Start()
    {
        origin = transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, 100f * Time.deltaTime); //rotate object
        transform.localPosition = new Vector3(origin.localPosition.x, origin.localPosition.y + 0.001f*Mathf.Sin(Time.time), origin.localPosition.z); //move the object up and down with a sine function
    }
}
