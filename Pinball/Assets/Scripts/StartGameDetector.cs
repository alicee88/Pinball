using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameDetector : MonoBehaviour
{
    private SpringTop spring;
    private Flipper[] flippers;
    private ResetGameDetector resetgd;

    // Start is called before the first frame update
    void Start()
    {
        spring = FindObjectOfType<SpringTop>();
        flippers = FindObjectsOfType<Flipper>();
        resetgd = FindObjectOfType<ResetGameDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spring.BallReleased();
        flippers[0].BallReleased();
        flippers[1].BallReleased();
        resetgd.Activate();
    }
}
