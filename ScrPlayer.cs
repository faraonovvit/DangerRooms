using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScrPlayer : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Vector2 moveDirection;
    public Sprite spritePlayer;
    public float respawnTime = 1.0f;
    public float moveSpeed = 3f;
    float angle;
    float deathTimer;
    bool respawn = false;
    bool invincible = false;
    bool movingToEndPoint = false;
    Transform endPointTransform = null;
    Transform checkPointTransform = null;
    GameObject[] safeZones;
    public VariableJoystick variableJoystick;
    public GameObject deathEffectPrefab;
    ScrLevelController levelController;

    // Start is called before the first frame update
    void Start()
    {
        levelController = GameObject.FindGameObjectWithTag("Controller").GetComponent<ScrLevelController>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        safeZones = GameObject.FindGameObjectsWithTag("SafeZone");
        foreach (GameObject safeZone in safeZones)
        {
            if (safeZone.GetComponent<ScrSafeZone>().behaviour == Behaviour.StartPoint)
            {
                checkPointTransform = safeZone.transform;
            }
            else if (safeZone.GetComponent<ScrSafeZone>().behaviour == Behaviour.EndPoint)
            {
                endPointTransform = safeZone.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (respawn)
        {
            deathTimer -= Time.deltaTime;
            if (deathTimer <= 0.0f)
            {
                transform.position = checkPointTransform.position;
                GetComponent<SpriteRenderer>().sprite = spritePlayer;
                GetComponent<PolygonCollider2D>().isTrigger = false;
                rigidbody2d.simulated = true;
                GameObject.FindGameObjectWithTag("Music").GetComponent<ScrMusicPlayer>().PlayReviveSound();
                respawn = false;
            }
        }
        else
        {
            if (movingToEndPoint)
                moveDirection = endPointTransform.position - transform.position;
            else
                ProcessInputs();
        }
    }

    void FixedUpdate()
    {
        if (!respawn)
            Move(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SafeZone"))
        {
            ScrSafeZone safeZone = collision.GetComponent<ScrSafeZone>();
            if (safeZone.behaviour == Behaviour.EndPoint)
            {
                float secondsToNextScene = 1.0f;
                safeZone.LoadNextScene(secondsToNextScene);
                safeZone.SetActive(true);
                UpdateSafeZones(safeZone.gameObject);
                movingToEndPoint = true;
                invincible = true;
                moveDirection = endPointTransform.position - transform.position;
            }
            else
            {
                checkPointTransform = safeZone.transform;
                if (safeZone.active == false)
                    safeZone.SetActive(true);
                UpdateSafeZones(safeZone.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard") && !invincible)
        {
            OnDeath();
        }
    }

    void ProcessInputs()
    {
        moveDirection = variableJoystick.Direction;
    }

    void Move()
    {
        rigidbody2d.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        if (moveDirection.x != 0 || moveDirection.y != 0)
            angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90.0f;

        rigidbody2d.rotation = angle;
    }

    void OnDeath()
    {
        Instantiate(deathEffectPrefab).transform.position = transform.position;
        GetComponent<SpriteRenderer>().sprite = null;
        GetComponent<PolygonCollider2D>().isTrigger = true;
        rigidbody2d.simulated = false;
        //Handheld.Vibrate(); //Вибрация
        deathTimer = respawnTime;
        respawn = true;
        GameObject.FindGameObjectWithTag("Music").GetComponent<ScrMusicPlayer>().PlayDeathSound();
        //transform.position = checkPointTransform.position;
    }

    void UpdateSafeZones(GameObject except)
    {
        foreach (GameObject safeZone in safeZones)
        {
            if (safeZone != except)
            {
                safeZone.GetComponent<ScrSafeZone>().SetActive(false);
            }
        }
    }
}
