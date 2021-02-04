using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrBounceSquare : MonoBehaviour
{
    float rotationSpeed = 0.0f;
    Vector2 startForce;
    AudioSource audioSource;
    Rigidbody2D rigidbody2d;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        rotationSpeed = Random.Range(-100.0f, 100.0f);
        float x = Random.Range(-500.0f, 500.0f);
        float y = Random.Range(-500.0f, 500.0f);
        startForce = new Vector2(x, y);
        rigidbody2d.AddForce(startForce);
        rigidbody2d.AddTorque(rotationSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayBounceSound();
        rigidbody2d.velocity *= new Vector2(-1.0f, -1.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayBounceSound();
    }

    public void PlayBounceSound()
    {
        if (PlayerPrefs.GetInt("SoundIsOn") == 1)
            audioSource.Play();
    }
}
