using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrDoor : MonoBehaviour
{
    public enum Direction
    {
        Up = 1,
        Down = -1
    }

    public enum Status
    { 
        StayingOnBottom = 0,
        MovingUpwards = 1,
        StayingOnTop = 2,
        MovingDownwards = 3
    }

    public Transform doorIn;
    float doorInY;
    Status status = Status.StayingOnBottom;
    public Direction direction; 
    public float pushForwardTime = 1.0f;
    public float pushBackwardTime = 1.0f;
    public float stayingOnTopTime = 1.0f;
    public float stayingOnBottomTime = 1.0f;
    float timer;
    float timerProportion;

    private void Start()
    {
        timer = stayingOnBottomTime;
        doorInY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        float doorInNewY;
        switch (status)
        {
            case Status.StayingOnBottom:
                timerProportion = 1.0f - timer / stayingOnBottomTime;

                if (timer <= 0)
                {
                    status = Status.MovingUpwards;
                    timer = pushForwardTime;
                }
                break;

            case Status.MovingUpwards:
                timerProportion = 1.0f - timer / pushForwardTime;

                doorInNewY = Mathf.Lerp(doorInY, doorInY + 2.0f *(float)direction, timerProportion);
                doorIn.position = new Vector3(doorIn.position.x, doorInNewY, doorIn.position.z);

                if (timer <= 0)
                {
                    status = Status.StayingOnTop;
                    timer = stayingOnTopTime;
                }

                break;
            case Status.StayingOnTop:
                timerProportion = 1.0f - timer / stayingOnTopTime;

                if (timer <= 0)
                {
                    status = Status.MovingDownwards;
                    timer = pushBackwardTime;
                }

                break;
            case Status.MovingDownwards:
                timerProportion = 1.0f - timer / pushBackwardTime;

                doorInNewY = Mathf.Lerp((doorInY + 2.0f * (float)direction), doorInY, timerProportion);
                doorIn.position = new Vector3(doorIn.position.x, doorInNewY, doorIn.position.z);

                if (timer <= 0)
                {
                    status = Status.StayingOnBottom;
                    timer = stayingOnBottomTime;
                }

                break;

        }

       
    }
}
