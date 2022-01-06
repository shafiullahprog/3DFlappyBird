using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacles : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
 
    void FixedUpdate()
    {
        MoveLeft();
        DeleteObject();
    }
    private void MoveLeft()
    {
        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;
    }

    private void DeleteObject()
    {
        if (transform.position.x < -60f)
        {
            gameObject.SetActive(false);
        }
    }
}