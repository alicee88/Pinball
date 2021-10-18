using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameDetector : MonoBehaviour
{
    private SpringTop spring;
    private Flipper[] flippers;
    private bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
        spring = FindObjectOfType<SpringTop>();
        flippers = FindObjectsOfType<Flipper>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(activated)
        {
            Reset();
            activated = false;
        }
    }

    private void Reset()
    {
        spring.Reset();
        flippers[0].Reset();
        flippers[1].Reset();
    }

    public void Activate()
    {
        activated = true;
    }
}
