using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] float rotationSpeed = 15f;
    [SerializeField] string detectPlayerTag = "Player";
    void Update()
    {
        transform.Rotate(new Vector3(45f, 45f, 45f) * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == detectPlayerTag) {
            FindObjectOfType<LevelSystemMgr>().CollectedPickups++;
            Destroy(gameObject);
        }
    }
}
