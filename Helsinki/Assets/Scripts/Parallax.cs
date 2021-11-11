using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    //Setting variables
    public Camera cam;
    public Transform subject;

    //Creating storage for starting positions 
    Vector2 startPosition;
    float startZ;
    
    //Setting the travel distance of the camera
    Vector2 travel => (Vector2)cam.transform.position - startPosition;

    float distanceFromSubject => transform.position.z - subject.position.z;
    float clippingPlane => (cam.transform.position.z + (distanceFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane));
    
    float parallaxFactor => Mathf.Abs(distanceFromSubject) / clippingPlane;

    //Getting the variables for storage
    public void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;
    }

    //Implementing the loop
    public void Update()
    {
        Vector2 newPosition = startPosition + travel * parallaxFactor;
        transform.position = new Vector3(newPosition.x, newPosition.y, startZ); 
    }


}
