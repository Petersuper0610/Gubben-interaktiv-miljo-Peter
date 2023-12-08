using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    // Referens till kamerans transform f�r r�relseriktning
    public Transform cameraTransform;

    // Hastighet f�r karakt�rsr�relse
    public float movementSpeed = 5f;

    // Referens till Rigidbody-komponenten
    Rigidbody body;

    // Inmatningsvariabler f�r horisontell och vertikal r�relse
    float horizontal;
    float vertical;

    // Referens till Animator-komponenten
    public Animator animator;

    // Start k�rs innan f�rsta bildrutan
    void Start()
    {
        // H�mta referenser till Animator och Rigidbody-komponenter
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
    }

    // Update k�rs en g�ng per bildruta
    void Update()
    {
        // H�mta obearbetad inmatning f�r horisontell och vertikal r�relse
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // S�tt "Walk Forward"-parametern i Animator baserat p� r�relseing�ng
        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("Walk Forward", true);
        }
        else
        {
            animator.SetBool("Walk Forward", false);
        }

        // Hantera hopp-animation och kraft n�r mellanslagstangenten trycks ner
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("Jump W Root");
            body.AddForce(Vector3.up * 200);
        }

        // Hantera l�p-animation och parameter baserat p� h�ger skift-tangent
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            animator.Play("Run In Place");
            animator.SetBool("Run Forward", true);
        }

        // Stoppa l�p-animation n�r h�ger skift-tangent sl�pps
        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            animator.SetBool("Run Forward", false);
        }

        // Hantera attack-animationer baserat p� musknappsklick
        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("Attack 01");
        }

        if (Input.GetMouseButtonDown(1))
        {
            animator.Play("Attack 02");
        }
    }

    // FixedUpdate anv�nds f�r fysikrelaterade uppdateringar
    private void FixedUpdate()
    {
        // H�mta fram�t- och h�gervektorer fr�n kamerans transform
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Ignorera den vertikala komponenten f�r att s�kerst�lla att r�relsen �r parallell med marken
        forward.y = 0;
        right.y = 0;

        // Ber�kna r�relseriktningen baserat p� inmatning och kamerans orientering
        Vector3 direction = forward * vertical + right * horizontal;

        // Ber�kna den nya positionen baserat p� riktningen, tid och r�relsehastighet
        Vector3 movement = transform.position + direction.normalized * Time.fixedDeltaTime * movementSpeed;

        // Flytta Rigidbody f�r karakt�ren till den nya positionen
        body.MovePosition(movement);

        // Rotera karakt�ren f�r att titta �t r�relseriktningen om den inte �r noll
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
