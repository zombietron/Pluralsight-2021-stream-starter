using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerEndless : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    [SerializeField] [Range(100,1000)] float JumpPower;

    bool grounded = true;
    
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim != null)
        {

            if (GameManager.Instance.isRunning)
            {
                if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
                {
                    if (grounded)
                    {
                        Jump();
                    }
                }
            }
        }


    }
    public void Jump()
    {
        grounded = false;
        rb.AddForce(Vector2.up * JumpPower);
        anim.SetBool("jump", true);
        Debug.LogWarning("Jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.CompareTag("ground"))
        {
            anim.SetBool("grounded", true);
            anim.SetBool("jump", false);
            grounded = true;
        }

        if(collision.gameObject.CompareTag("Enemy"))
        {
            anim.SetBool("gameover", true);
            GameManager.Instance.GameOver();
        }
    }

    public void StartRunning()
    {
        anim.SetBool("start", true);
    }

}
