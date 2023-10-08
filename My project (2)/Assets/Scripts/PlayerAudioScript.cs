using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioScript : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] Movement movement;
    public AudioSource jumpAudio, runAudio;

    // Update is called once per frame
    void Update()
    {
        if (rb2d.velocity.x != 0 && movement.IsGrounded())
        {
            runAudio.Play();
        }
    }
}
