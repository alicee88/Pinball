using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    private AudioSource audioSource;
    Score score;
    Light flash;
    Color flashColour1 = Color.blue;
    Color flashColour2 = Color.red;
    float flashDuration = 0.3f;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        score = FindObjectOfType<Score>();
        flash = FindObjectOfType<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayHitSound()
    {
        audioSource.PlayOneShot(audioSource.clip);
        score.AddPointsToScore(100);
        PlayFlash();
    }

    private void PlayFlash()
    {
        Light flashInstance = Instantiate(flash, transform.position, transform.rotation);
        flashInstance.enabled = true;
        flashInstance.range = transform.localScale.x + 0.2f;

        float t = Mathf.PingPong(Time.time, flashDuration) / flashDuration;
        flashInstance.color = Color.Lerp(flashColour1, flashColour2, t);


        Destroy(flashInstance.gameObject, 0.3f);


    }
}
