using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamicallly")]
    public Text scoreGT;

    void Start()
    {
        // Find a reference to the ScoreCounter GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Get the Text component of that GameObject
        scoreGT = scoreGO.GetComponent<Text>();
        // Set the starting number of points to 0
        scoreGT.text = "0";
    }

    void Update()
    {
        // Get the current screen postion of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        // The Camera's Z position sets how far to push the mouse into 3D 
        mousePos2D.z = -Camera.main.transform.position.z;

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Move the x position of thsi Basket to the x position of the mouse 
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        // pos.y = mousePos3D.y;
        this.transform.position = pos;
    }

    void OnCollisionEnter (Collision coll)
    {
        // Find out what hit this basket 
        GameObject collideWith = coll.gameObject; 
        if (collideWith.tag == "Apple")
        {
            Destroy(collideWith);

            // Parse the text of the scoreGT into an int
            int score = int.Parse(scoreGT.text);
            // Add points for cathing the apple
            score += 100;
            // convert the score back to a string and display it 
            scoreGT.text = score.ToString();

            // Track the High Score
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
