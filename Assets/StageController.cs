using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour {

	public GameObject[] BGObjects; // An array of BG prefabs.

	// Queue to hold the objects.
	Queue<GameObject> availableObjects = new Queue<GameObject>();

	// Use this for initialization
	void Start () {
		// Add the available objects to the queue.
		availableObjects.Enqueue(BGObjects [0]); 
		availableObjects.Enqueue(BGObjects [1]);
		availableObjects.Enqueue(BGObjects [2]);
		availableObjects.Enqueue(BGObjects [3]);
	}
}

