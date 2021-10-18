using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector2 startPos;
    BumperSuck bumperSuck;
    Vector3 bumperSuckPos;
    Rigidbody2D rigidBody;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        bumperSuck = FindObjectOfType<BumperSuck>();
        bumperSuckPos = bumperSuck.transform.position;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Reset()
    {
        transform.position = startPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bumper")
        {
            collision.gameObject.GetComponent<Bumper>().PlayHitSound();
        }
    }

}
