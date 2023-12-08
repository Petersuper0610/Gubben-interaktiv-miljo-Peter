using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    // Referens till kamerans transform för rörelseriktning
    public Transform cameraTransform;

    // Hastighet för karaktärsrörelse
    public float movementSpeed = 5f;

    // Referens till Rigidbody-komponenten
    Rigidbody body;

    // Inmatningsvariabler för horisontell och vertikal rörelse
    float horizontal;
    float vertical;

    // Referens till Animator-komponenten
    public Animator animator;

    // Start körs innan första bildrutan
    void Start()
    {
        // Hämta referenser till Animator och Rigidbody-komponenter
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
    }

    // Update körs en gång per bildruta
    void Update()
    {
        // Hämta obearbetad inmatning för horisontell och vertikal rörelse
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // Sätt "Walk Forward"-parametern i Animator baserat på rörelseingång
        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("Walk Forward", true);
        }
        else
        {
            animator.SetBool("Walk Forward", false);
        }

        // Hantera hopp-animation och kraft när mellanslagstangenten trycks ner
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("Jump W Root");
            body.AddForce(Vector3.up * 200);
        }

        // Hantera löp-animation och parameter baserat på höger skift-tangent
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            animator.Play("Run In Place");
            animator.SetBool("Run Forward", true);
        }

        // Stoppa löp-animation när höger skift-tangent släpps
        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            animator.SetBool("Run Forward", false);
        }

        // Hantera attack-animationer baserat på musknappsklick
        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("Attack 01");
        }

        if (Input.GetMouseButtonDown(1))
        {
            animator.Play("Attack 02");
        }
    }

    // FixedUpdate används för fysikrelaterade uppdateringar
    private void FixedUpdate()
    {
        // Hämta framåt- och högervektorer från kamerans transform
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Ignorera den vertikala komponenten för att säkerställa att rörelsen är parallell med marken
        forward.y = 0;
        right.y = 0;

        // Beräkna rörelseriktningen baserat på inmatning och kamerans orientering
        Vector3 direction = forward * vertical + right * horizontal;

        // Beräkna den nya positionen baserat på riktningen, tid och rörelsehastighet
        Vector3 movement = transform.position + direction.normalized * Time.fixedDeltaTime * movementSpeed;

        // Flytta Rigidbody för karaktären till den nya positionen
        body.MovePosition(movement);

        // Rotera karaktären för att titta åt rörelseriktningen om den inte är noll
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
