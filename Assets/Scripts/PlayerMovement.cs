using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed;
    private float verticalSpeedLastFrame;
    public int jumpForce;
    private bool onGround;
    List<GameObject> currentCollisions = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        verticalSpeedLastFrame = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && onGround /*&& (Mathf.Floor(verticalSpeedLastFrame * 1000) / 1000) == 0 && (Mathf.Floor(rb.velocity.y * 1000) / 1000 == 0)*/)
        {
            rb.AddForce(new Vector2(0, .8f) * jumpForce, ForceMode2D.Impulse);

        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        
        verticalSpeedLastFrame = rb.velocity.y;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            onGround = true;
            currentCollisions.Add(collision.gameObject);
        }
        if (collision.collider.tag == "Spike")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            currentCollisions.Remove(collision.gameObject);
            onGround = false;
            for (int i = 0; i < currentCollisions.Count; i++)
            {
                if (currentCollisions[i].tag == "Ground")
                {
                    onGround = true;
                }
            }

        }
    }
}
