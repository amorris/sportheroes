using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    private Animation animation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animation = GetComponent<Animation>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Debug.Log(moveHorizontal);
        Debug.Log(moveVertical);
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 40));
            animation.Play("jump");
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed, ForceMode.VelocityChange);
        
        if (rb.velocity.x != 0 && rb.velocity.z != 0)
            animation.Play("run");
        else if (rb.velocity.y == 0)
            animation.Play("idle"); 
    }
}
