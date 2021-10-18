using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringTop : MonoBehaviour
{

    private Rigidbody2D rb;
    private AudioSource audioSource;

    bool moveSpring = false;
    bool ballReleased = false;

    Vector3 startSpringPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !ballReleased)
        {
            moveSpring = true;
            startSpringPos = transform.position;

        }

        if(Input.GetMouseButtonUp(0) && !ballReleased)
        {
            moveSpring = false;
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    private void FixedUpdate()
    {
        if(moveSpring)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            mousePos.y = Mathf.Clamp(mousePos.y, mousePos.y, startSpringPos.y);
            Vector3 move = mousePos - startSpringPos;

            rb.MovePosition(startSpringPos + move * Time.deltaTime * 150f);
        }
    }

    public void BallReleased()
    {
        ballReleased = true;
        moveSpring = false;
    }

    public void Reset()
    {
        ballReleased = false;
        moveSpring = false;
    }

}
