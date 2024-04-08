using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleController : MonoBehaviour
{
    public LogicController logic;   //Assigned at Runtime
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        logic.addScore(1);
    }
}
