using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public Transform[] spawnPoints;
	public GameObject[] hazards;

	private float timeBtwSpawns; //if no.=2 means enemy spawns every 2s
	public float startTimeBtwSpawns; //variable to reset the time between spawns variable

	public float minTimeBetweenSpawns; //for max lvl difficulty
	public float decrease;

	public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {if (player != null){	

		if(timeBtwSpawns<=0){
			Transform randomSpawnPoint = spawnPoints [Random.Range(0, spawnPoints.Length)];
			GameObject randomHazard = hazards [Random.Range(0, hazards.Length)];

			Instantiate(randomHazard, randomSpawnPoint.position, Quaternion.identity); //Quaternion means no particular position for preference of spawning

			if (startTimeBtwSpawns > minTimeBetweenSpawns){
				startTimeBtwSpawns -= decrease;
			}

			timeBtwSpawns = startTimeBtwSpawns;

		}else {
			timeBtwSpawns -= Time.deltaTime;
		}
		
    }}
}
