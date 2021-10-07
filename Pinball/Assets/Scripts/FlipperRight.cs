using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperRight : MonoBehaviour
{
    private HingeJoint2D hj;
    private JointMotor2D hjm;
    // Start is called before the first frame update
    void Start()
    {
        hj = gameObject.GetComponent<HingeJoint2D>();
        hjm = hj.motor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Clicked mouse");
            hjm.motorSpeed = 1000f;
            hj.motor = hjm;
            hj.useMotor = true;

        }
        else if (Input.GetMouseButtonUp(1))
        {
            hjm.motorSpeed = -1000f;
            hj.motor = hjm;
            hj.useMotor = true;
            // hj.useMotor = false;

        }
    }
}
