using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBird : MonoBehaviour
{
    [SerializeField] private float birdSpeed;   
    public Vector3 initialPosition;

    private Rigidbody rb;
    private AudioSource audioSource;
    public AudioClip clip1;
    public AudioClip clip2;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector3.up * birdSpeed;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            FindObjectOfType<GameManager>().GameOverFnc();
            audioSource.PlayOneShot(clip2, 0.1f);
        }

        if(other.gameObject.tag == "ScoreCounter")
        {
            GameManager.score++;
            audioSource.PlayOneShot(clip1, 0.1f);
        }
    }

    public Vector3 ReturnBirdPosition()
    {
        Debug.Log(initialPosition);
        return initialPosition;
    }
}
