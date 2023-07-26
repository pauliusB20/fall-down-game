using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speedX = 0.5f;
    [SerializeField] float fallDownSpeed = 0.01f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var horizontalMove = Input.GetAxis("Horizontal") * speedX * Time.deltaTime;
        var verticalMove = -1 * fallDownSpeed * Time.deltaTime;
        var newMovement = new Vector3(horizontalMove, verticalMove, 0f);
        rb.AddForce(newMovement);
    }

}
