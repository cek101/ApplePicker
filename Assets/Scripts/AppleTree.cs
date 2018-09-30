using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    [Header ("Set in Inspector")]
    //Prefab for instantiating apples
    public GameObject applePrefab;

    //Speed at which the appleTree moves
    public float    speed = 1f;

    //distance where appleTree turns around
    public float    leftAndRightEdge = 10f;

    //chance that AppleTree will change directions
    public float    chanceToChangeDirections = 0.1f;

    //rate at which Apples will be instatiated
    public float    secondsBetweenAppleDrops = 1f;

         
	void Start () {
        //dropping apples every second
        Invoke("DropApple", 2f); // a 
		
	}

    void DropApple ()   { // b 
        GameObject apple = Instantiate<GameObject>(applePrefab); // c
        apple.transform.position = transform.position; // d
        Invoke("DropApple", secondsBetweenAppleDrops); // e
    }

    // Update is called once per frame
    void Update()   { //f
        //basic Movement
        Vector3 pos = transform.position; //b
        pos.x += speed * Time.deltaTime; //c 
        transform.position = pos;  //d

        //Changing Direction
        if (pos.x < -leftAndRightEdge)  {
            speed = Mathf.Abs(speed); //move right

        }
        else if (pos.x > leftAndRightEdge)  {
            speed = -Mathf.Abs(speed); //move left
        } //else if ( Random.value < chanceToChangeDirections )   { //a
    }    //    speed *= -1; // change direction //b

    void FixedUpdate () {  
        if (Random.value < chanceToChangeDirections)    { //a
            speed *= -1; // change direction //b
        }
    }
}

