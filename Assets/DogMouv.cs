using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMouv : MonoBehaviour
{
    public float speed;
    private float speedY;
    public float jumpSpeed;
    public Rigidbody rb;
    public float bigJump;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Avancer
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("La touche D ou fleche de droite à été pressé");
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            transform.localRotation = Quaternion.Euler(0, 90, 0);
        }

        //Reculer
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) //Key code A == Touche Q
        {
            Debug.Log("La touche Q ou fleche de gauche à été pressé");
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            transform.localRotation = Quaternion.Euler(0, 270, 0);
        }

        //Saut
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector3.up * jumpSpeed * bigJump , ForceMode.Impulse);
            isGrounded = false;
        }


    }

    void OnCollisionEnter(Collision collider)
    {
        isGrounded = true;
    }
}
