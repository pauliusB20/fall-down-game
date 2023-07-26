using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform playerPos;

    Vector3 offset;

    void Start()
    {
        offset = transform.position - playerPos.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {       
        transform.position = playerPos.position + offset;
    }
}
