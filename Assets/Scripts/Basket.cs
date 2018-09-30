using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour     {

    // Use this for initialization
    //void Start () {

    //}

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

        }

    }
}

