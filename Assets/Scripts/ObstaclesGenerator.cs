using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour
{
    public float waitTime;
    public float minHeight;
    public float maxHeight;
    private void Start()
    {
        StartCoroutine("WaitTimeToPool");
    }
    private void GenerateObstacles()
    {
        GameObject obstacles = ObjectPooler.instance.GetPooledObject();
        if (obstacles != null)
        {
            obstacles.transform.position = this.transform.position + new Vector3(0, Random.Range(minHeight, maxHeight), 0);
            obstacles.SetActive(true);
        }
        StartCoroutine("WaitTimeToPool");
    }
    IEnumerator WaitTimeToPool()
    {
        yield return new WaitForSeconds(waitTime);
        GenerateObstacles();
    }
}
