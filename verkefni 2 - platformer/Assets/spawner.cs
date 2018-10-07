using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
    public GameObject platform;
    public GameObject coin;
    public float spawnRatePlatform = 2f;
    public float nextSpawnPlatform =0.0f;
    public float spawnRateCoin = 2f;
    public float nextSpawnCoin = 0.0f;
	// Use this for initialization
	void Start () {
        
		
	}
    //transform.position.y
    // Update is called once per frame
    void Update () {
        if (Time.time > nextSpawnPlatform)
        {
            nextSpawnPlatform = Time.time + spawnRatePlatform;
            Instantiate(platform, new Vector2(Random.Range(-9.49f, 9.49f), 5.54f), Quaternion.identity);
        }

        if (Time.time > nextSpawnCoin)
        {
            nextSpawnCoin = Time.time + spawnRateCoin;
            Instantiate(coin, new Vector2(Random.Range(-9.49f, 9.49f), 5.54f), Quaternion.identity);
        }

    }
}
