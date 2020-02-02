using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    // Prefab for instantiating apples
    public GameObject applePrefab;

    // Speed of AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around 
    public float edge = 10f;

    // Chance of Apple Tree change direction -- 10% 
    public float changeDirection = .1f;

    // Rate of Apple dropping 
    public float dropRate = 1f; 

    void Start ()
    {
        // Dropping apple every second
    }

    void Update ()
    {
        // basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // changing direction 
        if (pos.x < -edge)
        {
            speed = Mathf.Abs(speed); // move right 
        } else if (pos.x > edge) {
            speed = -Mathf.Abs(speed); // move left
        } else if (Random.value < changeDirection)
        {
            speed *= -1; // change direction
        }

    }
}
