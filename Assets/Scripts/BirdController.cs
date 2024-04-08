using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    private Animator myAnimator;
    public float flapStrength = 10;
    public LogicController logic;   //Assigned at Runtime
    public PlayerControls playerControls;   //PlayerControls was the name of the Input Action I created

    private InputAction jump;

    private void Awake()
    {
        playerControls = new PlayerControls();
        
    }
    private void OnEnable()
    {
        jump = playerControls.Player.Fire;
        jump.Enable();

        //Register to "Fire" Event
        jump.performed += Fire;
        jump.canceled += StopFire;
    }

    private void OnDisable()
    {
        jump.Disable();
    }

    void Fire(InputAction.CallbackContext context)
    {
        if (!logic.gameOverFLag)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
            //myAnimator.Play("SimpleJumpAnim");
            myAnimator.SetBool("isJumping", true);
        }
    }

    void StopFire(InputAction.CallbackContext context)
    {
        myAnimator.SetBool("isJumping", false);
    }

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicController>();
    }

    // Update is called once per frame
    void Update()
    {

        /*if (Input.GetKeyDown(KeyCode.Space) && !logic.gameOverFLag)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
        }*/

        if (!logic.gameOverFLag)
        {
            transform.rotation = Quaternion.Euler(0, 0, myRigidBody.velocity.y * 2);
        }


        if(transform.position.y > 5 || transform.position.y < -5)
        {
            logic.gameOver();
        }

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }

        //Debug.Log(logic.gameOverFLag);
        //Debug.Log(transform.position.y);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        myRigidBody.AddForce(Vector2.left * 15, ForceMode2D.Impulse);
        myRigidBody.AddTorque(150);
        logic.gameOver();
    }


}
