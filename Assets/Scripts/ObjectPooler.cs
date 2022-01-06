using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler instance;
    [SerializeField] private int NoOfObjToPool;
    [SerializeField] private GameObject obstaclesPrefab;
    private List<GameObject> obstaclesList = new List<GameObject>();
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        GenerateObject();
    }

    public void GenerateObject()
    {
        for (int i = 0; i < NoOfObjToPool; i++)
        {
            GameObject obstacle = Instantiate(obstaclesPrefab);
            obstacle.SetActive(false);
            obstaclesList.Add(obstacle);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i=0; i<NoOfObjToPool; i++)
        {
            if (!obstaclesList[i].activeInHierarchy)
            {
                return obstaclesList[i];
            }
        }
        return null;
    }
    public GameObject DeletePooledObject()
    {
        for (int i = 0; i < NoOfObjToPool; i++)
        {
            obstaclesList[i].SetActive(false);
        }
        return null;
    }

}
