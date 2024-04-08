using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(-2f, 2.5f),transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < -45)
        {
            Destroy(gameObject);    //Destroy Self
        }

    }


}
