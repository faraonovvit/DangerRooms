using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrLightMove : MonoBehaviour
{
    public enum Behaviour
    { 
        moveHorizontal,
        moveVertical,
        moveClockwise
    }
    public enum Direction
    { 
        down,
        left,
        up,
        right
    }

    public Behaviour behaviour;
    Direction direction;
    public float x = 11.0f; 
    public float y = 7.0f;
    public float speed = 3.0f;

    void Start()
    {
        switch (behaviour)
        {
            case Behaviour.moveClockwise:
                direction = Direction.down;
                break;
            case Behaviour.moveHorizontal:
                direction = Direction.left;
                break;
            case Behaviour.moveVertical:
                direction = Direction.down;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        switch (behaviour)
        {
            case Behaviour.moveHorizontal:
                switch (direction)
                {
                    case Direction.left:
                        if (x > -11.0f)
                            x -= Time.deltaTime * speed;
                        else
                        {
                            x = -11.0f;
                            direction = Direction.right;
                        }
                        break;
                    case Direction.right:
                        if (x < 11.0f)
                            x += Time.deltaTime * speed;
                        else
                        {
                            x = 11.0f;
                            direction = Direction.left;
                        }
                        break;
                }
                break;
            case Behaviour.moveVertical:
                switch (direction)
                {
                    case Direction.down:
                        if (y > -7.0f)
                            y -= Time.deltaTime * speed;
                        else
                        {
                            y = -7.0f;
                            direction = Direction.up;
                        }
                        break;
                    case Direction.up:
                        if (y < 7.0f)
                            y += Time.deltaTime * speed;
                        else
                        {
                            y = 7.0f;
                            direction = Direction.down;
                        }
                        break;
                }
                break;
            case Behaviour.moveClockwise:
                switch (direction)
                {
                    case Direction.down:
                        if (y > -7.0f)
                            y -= Time.deltaTime * speed;
                        else
                        {
                            y = -7.0f;
                            direction = Direction.left;
                        }
                        break;
                    case Direction.left:
                        if (x > -11.0f)
                            x -= Time.deltaTime * speed;
                        else
                        {
                            x = -11.0f;
                            direction = Direction.up;
                        }
                        break;
                    case Direction.up:
                        if (y < 7.0f)
                            y += Time.deltaTime * speed;
                        else
                        {
                            y = 7.0f;
                            direction = Direction.right;
                        }
                        break;
                    case Direction.right:
                        if (x < 11.0f)
                            x += Time.deltaTime * speed;
                        else
                        {
                            x = 11.0f;
                            direction = Direction.down;
                        }
                        break;
                }
                break;
        }
        
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
