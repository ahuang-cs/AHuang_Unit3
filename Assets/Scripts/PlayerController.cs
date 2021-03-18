using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravityModifier = 2f;
    public float jumpForce = 10f;
    public bool gameOver = false;

    private Rigidbody rb;
    private bool onGround = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver && Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Ground":
                onGround = true;
                break;
            case "Obstacle":
                Debug.Log("Game Over!");
                gameOver = true;
                break;
        }
        
    }
}
