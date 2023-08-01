using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   [SerializeField] string playerTag = "Player";
   [SerializeField] int doorId = 1;

   public int DoorId { set { doorId = value; } get { return doorId; }}


   private void OnCollisionEnter(Collision other) {
         if (other.gameObject.tag == playerTag) {
            var player = other.gameObject.GetComponent<Player>();
            var keysInventory = player.KeysInventory;

            if (keysInventory.Count == 0)
            {
                // Note: In the future: player is able to open the door without the key, but for that he will need to take some damage
                Debug.Log("No key is not present in the player's inventory!");
                return;
            }

            foreach (var key in keysInventory) {
                if (key.DoorId == doorId) {
                    Debug.Log("Door unclocked!");
                    Destroy(gameObject);
                }
            }              
        }
    }        
    
}
