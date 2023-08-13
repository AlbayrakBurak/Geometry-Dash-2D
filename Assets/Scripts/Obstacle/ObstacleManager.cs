using System.Collections;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab; // Engel prefabı
    public Transform spawnPoint; // Engel spawn noktası
    public float spawnInterval = 1f; // Engel spawn aralığı (saniye)
    public float obstacleSpeed = 5f; // Engel hareket hızı
    public int maxSpawnCount = 10;

    public GameObject Portal;

    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

   
    private IEnumerator SpawnObstacles()
    {
                    int obstacleCount = 0;

        while (obstacleCount < maxSpawnCount)
        {
             
            Vector3 spawnPosition = new Vector3(spawnPoint.position.x, -2f, spawnPoint.position.z);
            GameObject spawnedObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

            StartCoroutine(MoveObstacle(spawnedObstacle));

            yield return new WaitForSeconds(spawnInterval);

            obstacleCount++;
            if(obstacleCount==10){
           Vector3 spawnPortal = new Vector3(spawnPoint.position.x,-1f , spawnPoint.position.z);
            GameObject spawnedPortal = Instantiate(Portal,spawnPortal, Quaternion.identity);
            StartCoroutine(MovePortal(spawnedPortal));
            yield return new WaitForSeconds(spawnInterval);
        }
        }
        

    }


    private IEnumerator MoveObstacle(GameObject obstacle)
    {
        Vector3 direction = Vector3.left;

        while (obstacle.transform.position.x > -20f)
        {
            obstacle.transform.Translate(direction * obstacleSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(obstacle);
    }
    private IEnumerator MovePortal(GameObject Portal)
    {
        Vector3 direction = Vector3.left;

        while (Portal.transform.position.x > -20f)
        {
            Portal.transform.Translate(direction * obstacleSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(Portal);
    }
}
