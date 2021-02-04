using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrSpikeThrower : MonoBehaviour
{
    public float reload = 3.0f;
    public float rotationSpeed = 2.0f;
    public float spikeSpeed = 2.0f;
    float timerLoad, timerShoot;
    public RotationDirection rotationDirection;
    public GameObject spikePrefab;
    public GameObject spikeStart1, spikeStart2, spikeStart3, spikeStart4;
    GameObject spike1, spike2, spike3, spike4;
    bool isLoading = false;
    float rotation = 0.0f;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        timerShoot = reload;
        timerLoad = timerShoot - timerShoot / 2;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource = GetComponent<AudioSource>();
        rotation += rotationSpeed * (float)rotationDirection;
        rotation %= 360f;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);

        timerLoad -= Time.deltaTime;
        if (timerLoad <= 0.0f)
        {
            if (!isLoading)
            {
                CreateSpikes();
                isLoading = true;
            }
            else
            {
                spike1.transform.position = spikeStart1.transform.position;
                spike1.transform.rotation = spikeStart1.transform.rotation;
                spike2.transform.position = spikeStart2.transform.position;
                spike2.transform.rotation = spikeStart2.transform.rotation;
                spike3.transform.position = spikeStart3.transform.position;
                spike3.transform.rotation = spikeStart3.transform.rotation;
                spike4.transform.position = spikeStart4.transform.position;
                spike4.transform.rotation = spikeStart4.transform.rotation;
            }

        }

        timerShoot -= Time.deltaTime;
        if (timerShoot <= 0.0f)
        {
            ShootSpikes();
            timerShoot = reload;
            timerLoad = timerShoot - timerShoot / 2;
            isLoading = false;
        }
    }

    void ShootSpikes()
    {
        PlaySpikeThrowerShotSound();
        Vector3 direction = spikeStart1.transform.position - transform.position;
        spike1.GetComponent<Rigidbody2D>().velocity = direction.normalized * spikeSpeed;
        spike1.GetComponent<Rigidbody2D>().simulated = true;
        direction = spikeStart2.transform.position - transform.position;
        spike2.GetComponent<Rigidbody2D>().velocity = direction.normalized * spikeSpeed;
        spike2.GetComponent<Rigidbody2D>().simulated = true;
        direction = spikeStart3.transform.position - transform.position;
        spike3.GetComponent<Rigidbody2D>().velocity = direction.normalized * spikeSpeed;
        spike3.GetComponent<Rigidbody2D>().simulated = true;
        direction = spikeStart4.transform.position - transform.position;
        spike4.GetComponent<Rigidbody2D>().velocity = direction.normalized * spikeSpeed;
        spike4.GetComponent<Rigidbody2D>().simulated = true;
    }

    void CreateSpikes()
    {
        spike1 = Instantiate(spikePrefab) as GameObject;
        spike1.transform.position = spikeStart1.transform.position;
        spike1.transform.rotation = spikeStart1.transform.rotation;
        spike1.GetComponent<Rigidbody2D>().simulated = false;
        spike2 = Instantiate(spikePrefab) as GameObject;
        spike2.transform.position = spikeStart2.transform.position;
        spike2.transform.rotation = spikeStart2.transform.rotation;
        spike2.GetComponent<Rigidbody2D>().simulated = false;
        spike3 = Instantiate(spikePrefab) as GameObject;
        spike3.transform.position = spikeStart3.transform.position;
        spike3.transform.rotation = spikeStart3.transform.rotation;
        spike3.GetComponent<Rigidbody2D>().simulated = false;
        spike4 = Instantiate(spikePrefab) as GameObject;
        spike4.transform.position = spikeStart4.transform.position;
        spike4.transform.rotation = spikeStart4.transform.rotation;
        spike4.GetComponent<Rigidbody2D>().simulated = false;
    }

    void PlaySpikeThrowerShotSound()
    {
        if (PlayerPrefs.GetInt("SoundIsOn") == 1)
            audioSource.Play();
    }
}
