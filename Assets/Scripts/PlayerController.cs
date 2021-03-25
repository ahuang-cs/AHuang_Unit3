using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravityModifier = 2f;
    public float jumpForce = 10f;
    public float flipTorque = 20f;
    public bool gameOver = false;
    public ParticleSystem gameOverParticleSystem;
    public ParticleSystem dirtParticleSystem;
    public AudioClip jumpSFX;
    public float jumpSFXVol = 1.0f;
    public AudioClip crashSFX;
    public float crashSFXVol = 1.0f;

    private Rigidbody rb;
    private bool onGround = true;
    private Animator anim;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

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
            dirtParticleSystem.Stop();
            audio.PlayOneShot(jumpSFX, jumpSFXVol);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            // Landed after jump
            case "Ground":
                onGround = true;
                if (!gameOver)
                {
                    dirtParticleSystem.Play();
                }
                break;

            // Crashed into obstacle
            case "Obstacle":
                Debug.Log("Game Over!");
                gameOver = true;
                anim.SetBool("Death_b", true);
                anim.SetInteger("DeathType_int", 2);
                dirtParticleSystem.Stop();
                gameOverParticleSystem.Play();
                audio.PlayOneShot(crashSFX, crashSFXVol);
                break;
        }
        
    }
}
