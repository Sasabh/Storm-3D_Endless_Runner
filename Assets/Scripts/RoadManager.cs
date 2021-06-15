using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class RoadManager : MonoBehaviour {

	public GameObject[] roadPrefabs;
	private Transform playerTransform;
	private float spawnz = -11.6f;
	private float safeZone = 15.0f;
	private float roadLength = 7.620134f;
	private int roadOnScreen = 11;
	private int lastPrefabIndex = 0;

	private List<GameObject> activeRoads;
	void Start () {
		activeRoads = new List<GameObject> ();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		for(int i = 0; i < roadOnScreen; i++){
			if(i<3)
				SpawnTile(0);
			else
				SpawnTile();
		}
	}

	void Update () {
		if(playerTransform.position.z - safeZone > (spawnz - roadOnScreen * roadLength)){
			SpawnTile();
			DeleteTile();
		}
	}
	private void SpawnTile(int prefabIndex = -1 ){
		GameObject roadClone;
		if(prefabIndex == -1)
			roadClone = Instantiate (roadPrefabs [RandomPrefabIndex()]) as GameObject;
		else
			roadClone = Instantiate (roadPrefabs [prefabIndex]) as GameObject;
		roadClone.transform.SetParent (transform);
		roadClone.transform.position = Vector3.forward * spawnz;
		spawnz += roadLength;
		activeRoads.Add (roadClone);
	}
	private void DeleteTile(){
		Destroy (activeRoads [0]);
		activeRoads.RemoveAt (0);
	}

	private int RandomPrefabIndex(){
		if (roadPrefabs.Length <= 1) {
			return 0;
		}
		int randomIndex = lastPrefabIndex;
		while(randomIndex == lastPrefabIndex){
			randomIndex = Random.Range(0,roadPrefabs.Length);
		}
		lastPrefabIndex = randomIndex;
		return randomIndex; 
	}
}
