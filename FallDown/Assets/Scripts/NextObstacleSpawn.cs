using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextObstacleSpawn : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";
    [SerializeField] bool spawnNextObstacle = false;
    // [SerializeField] GameObject mainObstacleObject;
    
    public bool SpawnNextObstacle { set { spawnNextObstacle = value; } get { return spawnNextObstacle; }}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == playerTag){
            FindObjectOfType<LevelSystemMgr>().NextSpawnPosition = other.gameObject.transform.position;
            SpawnNextObstacle = true;          

            StartCoroutine(handleDespawn());
        }
    }

    IEnumerator handleDespawn(){
        var systemMgr = FindObjectOfType<LevelSystemMgr>();
        var delayInSeconds = systemMgr.DespawnDelaySeconds;
        var parentObstacleObj = gameObject.transform.parent.gameObject.transform.parent.gameObject;        
        yield return new WaitForSeconds(delayInSeconds);
        Destroy(parentObstacleObj);
    }
   
}
