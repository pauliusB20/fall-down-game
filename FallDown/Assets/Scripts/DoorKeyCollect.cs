using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyCollect : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";
    [SerializeField] int doorId = 1;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == playerTag) {
            var detectedPlayer = other.gameObject.GetComponent<Player>();
            detectedPlayer.addDoorKey(doorId);
            Destroy(gameObject);
        }
    }
}
