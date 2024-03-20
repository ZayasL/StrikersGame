using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalMovement : MonoBehaviour
{
    Transform origin;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, 100f * Time.deltaTime);
        transform.localPosition = new Vector3(origin.localPosition.x, origin.localPosition.y + 0.002f*Mathf.Sin(Time.time), origin.localPosition.z);
    }
}
