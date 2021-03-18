using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float minX = -10f;
    public float speed = 10f;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            if(transform.position.x < minX && gameObject.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
            }
        }
    }
}
