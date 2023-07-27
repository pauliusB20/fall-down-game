using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystemMgr : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] obstacles;
    [SerializeField] GameObject endingPlatform;
    [SerializeField] Vector3 nextSpawnPosition;
    [SerializeField] Vector3 currentSpawnPosition;
    [SerializeField] int maxSpawnCount = 10;
    [SerializeField] bool levelisFinished = false;
    [SerializeField] bool endingPlatformSpawned = false;
    [SerializeField] string pickupPositionTag = "Pickup";
    [SerializeField] GameObject pickup;

    public Vector3 NextSpawnPosition { set { nextSpawnPosition = value; } get { return nextSpawnPosition; }}
    private float yPosOffset;
    private int spawnCount = 0;
    private int previousIdx = 0;

    void Start()
    {
        var iniObstaclePos = player.transform.position;
        var initObstacle = Instantiate(obstacles[0], iniObstaclePos, Quaternion.identity);
        var spawnPoints = GameObject.FindGameObjectsWithTag(pickupPositionTag);

        foreach (var spawnPoint in spawnPoints) {
            spawnPoint.tag = "-";
        }
    }

    // Update is called once per frame
    void Update()
    {   
        var levelFinish = FindObjectOfType<LevelFinish>();
        if (levelFinish) {
          if (levelFinish.PlayerLanded)
          {
            FindObjectOfType<LevelFinish>().PlayerLanded = false;
            Debug.Log("You have won! The player has safely landed!");
          }
        }

        if (spawnCount >= maxSpawnCount && !endingPlatformSpawned){
            levelisFinished = true;
            Instantiate(endingPlatform, currentSpawnPosition, Quaternion.identity);
            endingPlatformSpawned = true;
        }

        // If a new position is received spawning new obstacle
        if (nextSpawnPosition != Vector3.zero && !levelisFinished) {
            if (yPosOffset == 0f)
                yPosOffset = player.transform.position.y / 4;

            var yPos = nextSpawnPosition.y - yPosOffset;
            var xPos = nextSpawnPosition.x;
            var zPos = nextSpawnPosition.z;

            // For getting random obstacle spawn position
            var randomLimit = obstacles.Length;
            var obstacleToSpawnIdx = Random.Range(0, randomLimit);
             
            // For making sure that the same number would not be repeated sequentially
            if (obstacleToSpawnIdx == previousIdx){
                while (obstacleToSpawnIdx == previousIdx) {
                    obstacleToSpawnIdx = Random.Range(0, randomLimit);
                    if (obstacleToSpawnIdx != previousIdx) {
                        previousIdx = obstacleToSpawnIdx;
                        break;
                    }
                }
            }

            var newObstaclePosition = new Vector3(xPos, yPos, zPos);
            var newObstacle = Instantiate(obstacles[obstacleToSpawnIdx], newObstaclePosition, Quaternion.identity);

            // Spawning pickup objects
            var spawnPoints = GameObject.FindGameObjectsWithTag(pickupPositionTag);

            if (spawnPoints.Length > 0 && spawnCount + 1 != maxSpawnCount) {
               for (var sIdx = 0; sIdx < spawnPoints.Length; sIdx ++) {
                    var spawnPos = spawnPoints[sIdx].transform.position;
                    var newPickup = Instantiate(pickup, spawnPos, Quaternion.identity);
                }
            }


            currentSpawnPosition = newObstacle.transform.position;
            nextSpawnPosition = Vector3.zero;
            spawnCount++;
        }   
    }
}
