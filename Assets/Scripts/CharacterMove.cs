using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public Transform cameraTransform;
    public float movementSpeed = 5f;
    
   


    Rigidbody body;
    float horizontal;
    float vertical;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0|| vertical !=0) 
        {
            animator.SetBool("Walk Forward", true);
        }
        
        else
            animator.SetBool("Walk Forward", false);

         
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            animator.Play("Jump W Root"); 
            body.AddForce(Vector3.up * 200);                 
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            animator.Play("Run In Place");
            animator.SetBool("Run Forward", true);
        }

        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            animator.SetBool("Run Forward", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("Attack 01");

        }

        if (Input.GetMouseButtonDown(1))
        {
            animator.Play("Attack 02");

        }



    }

    private void FixedUpdate()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        Vector3 direction = forward * vertical + right * horizontal;

        Vector3 movement = transform.position + direction.normalized * Time.fixedDeltaTime * movementSpeed;

        body.MovePosition(movement);

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
