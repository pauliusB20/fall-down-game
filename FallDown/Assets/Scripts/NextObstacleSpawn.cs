using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextObstacleSpawn : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";
    [SerializeField] bool spawnNextObstacle = false;
    [SerializeField] GameObject mainObstacleObject;
    [SerializeField] float delayInSeconds = 2f;

    public bool SpawnNextObstacle { set { spawnNextObstacle = value; } get { return spawnNextObstacle; }}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == playerTag){
            FindObjectOfType<LevelSystemMgr>().NextSpawnPosition = other.gameObject.transform.position;
            spawnNextObstacle = true;

            StartCoroutine(handleDespawn());
        }
    }

    IEnumerator handleDespawn(){
        yield return new WaitForSeconds(delayInSeconds);
        Destroy(mainObstacleObject);
    }
   
}
