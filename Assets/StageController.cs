using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour {

	public GameObject[] StageObjects; // An array of BG prefabs.

	// Queue to hold the objects.
	Queue<GameObject> availableObjects = new Queue<GameObject>();

	// Use this for initialization
	void Start () {
		// Add the available objects to the queue.
		availableObjects.Enqueue(StageObjects [0]); 
		availableObjects.Enqueue(StageObjects [1]);
		availableObjects.Enqueue(StageObjects [2]);
		availableObjects.Enqueue(StageObjects [3]);
	}
}

