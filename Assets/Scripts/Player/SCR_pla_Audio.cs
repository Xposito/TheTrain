using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_pla_Audio : MonoBehaviour
{
    public AudioClip[] steps;
    public float timeBetweenSteps;
    public LayerMask whatIsGround;

    private Rigidbody rb;
    private float playerHeight = 2.5f;
    private bool grounded;
    private AudioSource audioSource;
    private AudioClip clip;
    float horizontalInput;
    float verticalInput;
    private float timer;
    private bool reproducing;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        timer -= Time.deltaTime;

        if (grounded)
        {
            GroundSteps();
        }
    }

    void GroundSteps()
    {
        if (rb.velocity.magnitude <= 1) return;

        if (horizontalInput != 0 && !reproducing || verticalInput != 0 && !reproducing)
        {
            timer = timeBetweenSteps;
            reproducing = true;
            int index = Random.Range(0, steps.Length);
            clip = steps[index];
            audioSource.clip = clip;
            audioSource.Play();
        }

        if (horizontalInput != 0 && reproducing || verticalInput != 0 && reproducing)
        {

            if (timer <= 0)
            {
                reproducing = false;
            }
        }
    }


    
    void CheckGround()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
    }
}
