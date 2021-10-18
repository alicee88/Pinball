using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperSuck : MonoBehaviour
{
    PointEffector2D pointEffector;
    float maxTime;
    Ball ball;
    Rigidbody2D ballRB;
    bool ballSucked = false;
    float currTimer = 0;
    ParticleSystem ps;
   

    // Start is called before the first frame update
    void Start()
    {
        pointEffector = GetComponent<PointEffector2D>();
        pointEffector.enabled = false;
        maxTime = 3.0f;
        ball = FindObjectOfType<Ball>();
        ballRB = ball.GetComponent<Rigidbody2D>();
        ps = FindObjectOfType<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pointEffector.enabled == true && ballRB.velocity.magnitude < 0.5 && !ballSucked)
        {
            ballSucked = true;
            ParticleSystem psInstance = Instantiate(ps, transform.position, transform.rotation);
            psInstance.Play();
            Destroy(psInstance.gameObject, maxTime);
        }

        if(ballSucked)
        {
            if(currTimer < maxTime)
            {
                currTimer += Time.deltaTime;
            }
            else
            {
                currTimer = 0;
                pointEffector.enabled = false;
                ballSucked = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        pointEffector.enabled = true;
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pointEffector.enabled = false;
        currTimer = 0;
    }
}
