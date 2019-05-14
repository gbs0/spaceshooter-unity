using UnityEngine;
using System.Collections;
using System.Collections.Generic; // For the Queue.

public class BackgroundController : MonoBehaviour {

	public GameObject[] BGObjects; // An array of BG prefabs.
	public float yStore;
	public int planetNumber;

	// Queue to hold the objects.
	Queue<GameObject>availableObjects = new Queue<GameObject>();

	// Use this for initialization
	void Start () 
	{
		// Add the available objects to the queue.
		//availableObjects.Enqueue(BGObjects [0]); 
		//availableObjects.Enqueue(BGObjects [1]);
		//availableObjects.Enqueue(BGObjects [2]);
		//availableObjects.Enqueue(BGObjects [3]);

		// Call the MoveObjectDown function every 20 seconds.
		//InvokeRepeating("MoveObjectDown", 0, 1f);	
		yStore = -5;
	}


	void Update(){

		transform.Translate(new Vector2(0,yStore * Time.deltaTime));

		if (BGObjects[planetNumber].transform.position.y < -7) {

			BGObjects[planetNumber].transform.position = new Vector3(BGObjects[planetNumber].transform.position.x,3.75f,0);	

			planetNumber++;



		}

		if(planetNumber == 3){

			planetNumber = 0;
		}

	}


	// Function to dequeue an object, and set its isMoving flag to true
	// so that the object will start to scroll down the screen.
	void MoveObjectDown()
	{
		print("I should go down!");

		EnqueueObjects ();

		// If the queue is empty, then return.
		if (availableObjects.Count == 0)
			return;

		// Get an object from the queue.
		GameObject aPlanet = availableObjects.Dequeue ();
		aPlanet.GetComponent<BGObject>().isMoving = true; // Set the objects isMoving flag to true.
	}

	// Function to enqueue objects that are below the screen and not moving.
	void EnqueueObjects()
	{
		foreach (GameObject anObject in BGObjects) 
		{
			// If the planet is below the screen and the planet is not moving.
			if((anObject.transform.position.y < 0) && (!anObject.GetComponent<BGObject>().isMoving))
			{
				// Reset the planet position.
				yStore = -5;	
				anObject.GetComponent<BGObject>().ResetPosition();
				// Enqueue the object.
				availableObjects.Enqueue(anObject);
			}
		}
	}
}