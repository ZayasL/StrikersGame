using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Netcode;

public class Timer : NetworkBehaviour
{
    //https://www.youtube.com/watch?v=27uKJvOpdYw
    //Used this tutorial as foundation for my timer
    private float duration = 1f*60f+1;  //
    private NetworkVariable<float> timer = new NetworkVariable<float>(0f);
    public TextMeshProUGUI display;
    public NetworkVariable<float> power = new NetworkVariable<float>(0f);
    private Score board;
    private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        board = GetComponent<Score>();
        if (IsServer) { ResetTime(); }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsServer)
        {
            if (timer.Value > 0f)
            {
                timer.Value -= Time.deltaTime;
            }
            else
            {
                UpdateTimerDisplay(0f);
                if (board.GameEnd)
                {
                    
                    power.Value = 0f;
                }
                else { ResetTime(); sound.Play(0); }
                
            }
        }
        UpdateTimerDisplay(timer.Value);

    }

    private void ResetTime()
    {
        if (IsServer)
        {
            timer.Value = duration;
            power.Value += 1f;
        }
    }
    public void UpdateTimerDisplay(float time)
    {
        if (IsServer) { timer.Value = time; }
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        string currentTime = string.Format("{00:00}:{1:00}",minutes,seconds);
        display.text = currentTime;
    }
    private void Flash()
    {

    }
}
