using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This line enables use of uGUI features

public class Basket : MonoBehaviour     {
    [Header("Set Dynamically")]
    // Use this for initialization
    void Start () {
        // find a reference to the ScoreCounter GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Get the Text Component of that GameObject
        scoreGT = scoreGO.GetComponent<Text>();
        // Set the starting number of points to 0
        scoreGT.text = "0";

    }

    // Update is called once per frame
    void Update()    {
        //Get the current screen position of the mouse from input
        Vector3 mousePos2D = Input.mousePosition; //a

        // The camera's z position sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z; //b 

        //convert the point from 2d screen space into 3d game world space
        Vector3 mousePos3d = Camera.main.ScreenToWorldPoint(mousePos2D); //c

        // move the x position of this Basket to the x position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3d.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)       { //a catching apples page 483 check code in book?
      //find out what hit this basket
        GameObject collideWith = coll.gameObject; //b
        if (collidedWith.tag == "Apple")  {  //c
            Destroy(collidedWith);

            // Parse the text of the scoreGT into an int
            int score = int.Parse(scoreGT.text);
            // add points for catching the apple
            score += 100;
            // Convert the score back to a string and display it
            scoreGT.text = score.ToString();

            // convert the score back to a string and display it
            scoreGT.text = HighScore.ToString();

            // track the ghigh score
            if (score > HighScore.score) { }
            HighScore.score = score;
        }

    }
}

