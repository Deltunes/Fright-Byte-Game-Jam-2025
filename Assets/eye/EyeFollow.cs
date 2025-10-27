using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] public AudioSource hurtSound;
    [SerializeField] AudioSource passiveSound;
    Rigidbody rb;
    
    private float detectRange;
    private float eyeSpeed;
    private bool boatSpotted;
    private float lockOnDistance;

    public bool dead;
    public float eyeHealth;

    private void Start()
    {
        dead = false;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        boatSpotted = false;

        bool webGLBuild = true;
        if (webGLBuild)
        {
            detectRange = 50f;
            eyeHealth = 60f;
            eyeSpeed = 160f;
            lockOnDistance = 6f;
        }
        else
        {
            print("oops");
            detectRange = 30f;
            eyeHealth = 60f;
            eyeSpeed = 80;
            lockOnDistance = 3f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (player.transform.position - transform.position).magnitude;

        if (distance < detectRange && boatSpotted == false)
        {
            boatSpotted = true;
            hurtSound.Play();
        }

        if (eyeHealth <= 0)
        {
            dead = true;
            passiveSound.enabled = false;
        }

        if (!dead)
        {
            if (boatSpotted)
            {
                if (distance > 3f)
                {
                    transform.LookAt(player.transform.position);
                    transform.Rotate(Vector3.right, -90f, Space.Self);
                }
                rb.AddRelativeForce(Vector3.up * -eyeSpeed);
            }
        }
        else if (dead)
        {
            if (rb.useGravity == false)
            {
                rb.useGravity = true;
            }

            if (distance > 10f)
            {
                rb.excludeLayers = LayerMask.GetMask("Default");
            }
            
            if (rb.transform.position.y < -9f)
            {
                rb.AddForce(Vector3.up * 80f);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            FPSController FPS = other.transform.GetComponent<FPSController>();
            FPS.playerHealth -= 0.1f;
        }
    }
}
