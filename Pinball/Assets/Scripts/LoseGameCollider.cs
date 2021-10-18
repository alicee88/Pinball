using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGameCollider : MonoBehaviour
{
    Ball ball;
    SpringTop spring;
    Flipper[] flippers;

    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        spring = FindObjectOfType<SpringTop>();
        flippers = FindObjectsOfType<Flipper>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ball.Reset();
        spring.Reset();
        flippers[0].Reset();
        flippers[1].Reset();
    }
}
