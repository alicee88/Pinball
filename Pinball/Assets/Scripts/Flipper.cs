using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] flipperDir flipperDirection;
    private HingeJoint2D hj;
    private JointMotor2D hjm;
    private AudioSource audioSource;
    private bool ballReleased;
    float flipperTimer = 0;
    float maxFlipperTime = 0.3f;

    enum flipperDir : int { LEFT, RIGHT };

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
        if (flipperDirection == flipperDir.RIGHT)
        {
            if (Input.GetMouseButtonDown(1) && ballReleased)
            {
                MoveFlipper(flipperDirection);
                

            }
            else if (Input.GetMouseButtonUp(1) && ballReleased)
            {
                hj.useMotor = false;
                flipperTimer = 0;
            }
        }

        if(flipperDirection == flipperDir.LEFT)
        {
            if (Input.GetMouseButtonDown(0) && ballReleased)
            {
                MoveFlipper(flipperDirection);
            }
            else if (Input.GetMouseButtonUp(0) && ballReleased)
            {
                hj.useMotor = false;
                flipperTimer = 0;
            }
        }

        if(flipperTimer > maxFlipperTime && hj.useMotor == true)
        {
            hj.useMotor = false;
            flipperTimer = 0;
        }
        flipperTimer += Time.deltaTime;
    }

    private void MoveFlipper(flipperDir flipperDirection)
    {
        if(flipperDirection == flipperDir.LEFT)
        {
            hjm.motorSpeed = -10000f;
        }
        else
        {
            hjm.motorSpeed = 10000f;
        }
        
        hj.motor = hjm;
        hj.useMotor = true;

        PlayFlipSound();
        flipperTimer = 0;
    }

    private void PlayFlipSound()
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

