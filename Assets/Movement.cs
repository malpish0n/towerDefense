using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rig;
    public float moveSpeed;
    float moveX;
    float moveY;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        Moving();
        AnimatorMovement();



    }

    void Moving()
    {
        if (moveX != 0 && moveY != 0)
        {
            rig.velocity = new Vector2(moveX * moveSpeed / Mathf.Sqrt(2), moveY * moveSpeed / Mathf.Sqrt(2));
            
        }
        else
        {
            rig.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
        }
    }

    bool isMoving()
    {
        if(moveX != 0 || moveY != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void AnimatorMovement()
    {
        if (isMoving())
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }
        
    }
    
}
