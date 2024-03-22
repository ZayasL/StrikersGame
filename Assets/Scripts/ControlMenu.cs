using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlMenu : MonoBehaviour
{
    bool menuOn = true;
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {

    }
    void OnMenu(InputValue value)
    {
        image.SetActive(menuOn);
        menuOn = !menuOn;
    }
}
