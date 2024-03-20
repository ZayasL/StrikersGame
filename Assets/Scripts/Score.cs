using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Netcode;

public class Score : NetworkBehaviour
{
    public TextMeshProUGUI leftDisplay;
    public TextMeshProUGUI rightDisplay;
    public TextMeshProUGUI winDisplay;
    public bool GameEnd = false;
    public NetworkVariable<int> left = new NetworkVariable<int>(0);
    public NetworkVariable<int> right = new NetworkVariable<int>(0);

    private AudioSource[] sound;
    private bool playOnce = true;
    private float delay = 0f;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameEnd)
        {
            delay = Time.time + 5f;
        }
        if(GameEnd && Time.time >= delay)
        {
            restartRound();
        }
        if(left.Value >= 3)
        {
            winDisplay.text = "blue wins!!!!";
            GameEnd = true;
            if (playOnce) {
                sound[1].Play(0);
                playOnce = false;
            }
            
        }
        else if (right.Value >= 3)
        {
            winDisplay.text = "red wins!!!!";
            GameEnd = true;
            if (playOnce)
            {
                sound[1].Play(0);
                playOnce = false;
            }
        }
        else
        {
            winDisplay.text = "";
        }
        leftDisplay.text = left.Value.ToString()+"/3";
        rightDisplay.text = right.Value.ToString() + "/3";
    }
    private void restartRound()
    {
        GameEnd = false;
        left.Value = 0;
        right.Value = 0;
        playOnce = true;
    }
}
