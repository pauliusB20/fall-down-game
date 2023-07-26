using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{

    [SerializeField]
    string playerTag = "Player";

    [SerializeField]
    bool playerLanded = false;

    public bool PlayerLanded {set {playerLanded = value;} get { return playerLanded; }}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == playerTag && !playerLanded)
        {
            var landedPlayer = other.gameObject;
            landedPlayer.GetComponent<Player>().enabled = false;
            landedPlayer.GetComponent<Rigidbody>().isKinematic = true;
            playerLanded = true;

        }    
    }
}
