using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperLeft : MonoBehaviour

{
    private HingeJoint2D hj;
    private JointMotor2D hjm;

    // Start is called before the first frame update
    void Start()
    {
        hj = gameObject.GetComponent<HingeJoint2D>();
        hjm = hj.motor;

        Debug.Log("HINGE JOINT "+hj);
        Debug.Log("HING JOINT MOTOR " + hjm);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked mouse");
            hjm.motorSpeed = -1000f;
            hj.motor = hjm;
            hj.useMotor = true;

        }
        else if(Input.GetMouseButtonUp(0))
        {
            hjm.motorSpeed = 1000f;
            hj.motor = hjm;
            hj.useMotor = true;
           // hj.useMotor = false;
            
        }
    }
}
