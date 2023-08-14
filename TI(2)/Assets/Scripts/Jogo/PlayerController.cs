using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform[] paths;
    public float speed = 5f, laneChangeSpeed = 5f;

    public int currentPathIndex = 1;
        
    
    void Update()
    {
        Movimento();   
    }

    public void Movimento()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if(touch.position.x < Screen.width/2)
                {
                    ChangeLane(-1);
                }
                else
                {
                    ChangeLane(1);
                }
            }
        }
        Vector3 targetPosition = new Vector3(paths[currentPathIndex].position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, laneChangeSpeed * Time.deltaTime);
    }
    void ChangeLane(int direction)
    {
        int newPathIndex = currentPathIndex + direction;
        if (newPathIndex >= 0 && newPathIndex < paths.Length)
        {
            currentPathIndex = newPathIndex;
        }
    }
}
