using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrTurret : MonoBehaviour
{
    public enum Behaviour
    { 
        AutoTarget,
        NoTarget
    }
    Transform playerTransform;
    AudioSource audioSource;
    public Behaviour behaviour;
    public GameObject bulletPrefab;
    public GameObject bulletStart;
    Vector3 direction;
    public float bulletSpeed;
    public float reload = 3;

    public float rotationDistance = 30.0f;
    public float rotationSpeed = 1.0f;
    float maxAngleClockwise;
    float maxAngleCounterClockwise;
    float timer;
    float angle = 0.0f;
    
    RotationDirection rotationDirection = RotationDirection.Clockwise;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerTransform = GameObject.Find("Player").transform;
        timer = reload;
        if (behaviour == Behaviour.NoTarget)
        {
            maxAngleClockwise = transform.rotation.eulerAngles.z - rotationDistance;
            maxAngleCounterClockwise = transform.rotation.eulerAngles.z + rotationDistance;
            angle = transform.rotation.eulerAngles.z;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Controller").GetComponent<ScrLevelController>().gameIsPaused)
        {
            if (behaviour == Behaviour.AutoTarget)
            {
                direction = playerTransform.position - transform.position;
                angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f;
            }
            else
            {
                direction = bulletStart.transform.position - transform.position;

                if (rotationDirection == RotationDirection.Clockwise)
                {
                    if (angle >= maxAngleClockwise)
                        angle -= rotationSpeed;
                    else
                        rotationDirection = RotationDirection.CounterClockwise;
                }
                else
                {
                    if (angle <= maxAngleCounterClockwise)
                        angle += rotationSpeed;
                    else
                        rotationDirection = RotationDirection.Clockwise;
                }
            }

            transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
            if (timer <= 0)
            {
                FireBullet(direction, angle);
                timer = reload;
            }
            timer -= Time.deltaTime;
        }
    }

    void FireBullet(Vector2 direction, float rotationZ)
    {
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        bullet.transform.position = bulletStart.transform.position;
        bullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
        PlayTurretShotSound();
    }

    void PlayTurretShotSound()
    {
        if (PlayerPrefs.GetInt("SoundIsOn") == 1)
            audioSource.Play();
    }
}
