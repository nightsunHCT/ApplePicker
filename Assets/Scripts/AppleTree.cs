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
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", dropRate);
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
        }  
    }

    // change direction speed moved to FixedUpdate to make sure regardless how fast/slow the computer, 
    // it would be called exactly 50 times per second, while Update() can be called as fast/slow depends on the computer.
    void FixedUpdate() 
    {
        if (Random.value < changeDirection)
        {
            speed *= -1; // change direction (negative value = opposite direction)
        }
    }
}
