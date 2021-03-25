using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravityModifier = 2f;
    public float jumpForce = 10f;
    public float flipTorque = 20f;
    public bool gameOver = false;

    private Rigidbody rb;
    private bool onGround = true;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Jump triggered
        if (!gameOver && Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
            anim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            // Landed after jump
            case "Ground":
                rb.angularVelocity = Vector3.zero;
                onGround = true;
                break;

            // Crashed into obstacle
            case "Obstacle":
                Debug.Log("Game Over!");
                gameOver = true;
                anim.SetBool("Death_b", true);
                anim.SetInteger("DeathType_int", 2);
                break;
        }
        
    }
}
