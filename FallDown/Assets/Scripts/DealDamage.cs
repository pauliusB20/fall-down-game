using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == playerTag) {
            Destroy(other.gameObject);
            FindObjectOfType<LevelSystemMgr>().PlayerDestroyed = true;
        }
    }
}
