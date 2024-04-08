using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public float minSpawnRate;
    public float maxSpawnRate;
    private float currSpawnRate;
    public float timer = 0;

    public GameObject pipes;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(pipes, transform.position, transform.rotation);
        currSpawnRate = Random.Range(minSpawnRate, maxSpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timer < currSpawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Instantiate(pipes, transform.position, transform.rotation);
            timer = 0;
            currSpawnRate = Random.Range(minSpawnRate, maxSpawnRate);
            Debug.Log(currSpawnRate);
        }

        
    }
}
