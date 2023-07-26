using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string obstacleTag;
    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject player;
    [SerializeField] GameObject endingPlatform;
    [SerializeField] float endingPlatformYOriginOffset = 0f;
    [SerializeField] float distanceBetweenObstacles = 40f;
    GameObject newObstacle;
    float offsetY;
   
    void Start()
    {
       //Spawning ending platform
       var endingPlatformYPos = 0f - endingPlatformYOriginOffset;
       var endingPlatformPos = new Vector3(
         player.transform.position.x,
         0f - endingPlatformYOriginOffset,
         0f
       );      

       Instantiate(endingPlatform, endingPlatformPos, Quaternion.identity); 

       //Spawning player obstacles
       var endYPos = endingPlatform.transform.position.y;

       for (var yPos = player.transform.position.y; yPos >= endYPos; yPos -= distanceBetweenObstacles)
       {
           var newPos = new Vector3(player.transform.position.x, yPos, 0f);
           newObstacle = Instantiate(obstacle, newPos, Quaternion.identity);
       }

       //Ending obstacle    
       var newEndPos = new Vector3(
          0f,
          endingPlatformYPos + endingPlatformYOriginOffset / 3,
          0f
       );   
       newObstacle = Instantiate(obstacle, newEndPos, Quaternion.identity);
    }
    void Update() {

        if (FindObjectOfType<LevelFinish>().PlayerLanded){
          FindObjectOfType<LevelFinish>().PlayerLanded = false;
          Debug.Log("You have won! The player has safely landed!");
        }
    }
    
}
