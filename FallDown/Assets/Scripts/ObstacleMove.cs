using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] bool changeDirection = false;
    // Update is called once per frame
    void Update()
    {
        
        var direction = changeDirection ? 1 : -1;

        transform.position += (new Vector3(moveSpeed, 0f, 0f) * Time.deltaTime * direction);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "obstacleStatic") {
            changeDirection = !changeDirection;
        }
    }
}
