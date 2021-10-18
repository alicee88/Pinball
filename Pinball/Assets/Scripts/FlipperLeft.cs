using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperLeft : MonoBehaviour

{
    private HingeJoint2D hj;
    private JointMotor2D hjm;
    private AudioSource audioSource;
    private bool ballReleased;

    // Start is called before the first frame update
    void Start()
    {
        hj = gameObject.GetComponent<HingeJoint2D>();
        hjm = hj.motor;
        audioSource = GetComponent<AudioSource>();
        ballReleased = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && ballReleased)
        {
            MoveFlipper(-10000f);
            PlayFlipSound();
        }
        else if(Input.GetMouseButtonUp(0) && ballReleased)
        {
            hj.useMotor = false;
        }
     
    }

    void MoveFlipper(float speed)
    {
        hjm.motorSpeed = speed;
        hj.motor = hjm;
        hj.useMotor = true;
    }

    void PlayFlipSound()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void BallReleased()
    {
        ballReleased = true;
    }

    public void Reset()
    {
        ballReleased = false;
        hj.useMotor = false;
    }
}
