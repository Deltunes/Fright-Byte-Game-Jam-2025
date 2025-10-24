using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBoss : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] public AudioSource hurtSound;
    [SerializeField] AudioSource passiveSound;
    Rigidbody rb;

    public float detectRange;
    public bool dead;
    public float eyeHealth;
    public float eyeSpeed;
    bool boatSpotted;

    private void Start()
    {
        detectRange = 100f;
        eyeHealth = 200f;
        eyeSpeed = 4f;
        dead = false;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        boatSpotted = false;
    }

    // Update is called once per frame
    void Update()
    {
        print(eyeHealth);
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
                if (distance > 20f)
                {
                    transform.LookAt(player.transform.position);
                    transform.Rotate(Vector3.right, -90f, Space.Self);
                    rb.AddRelativeForce(Vector3.up * -eyeSpeed * distance);
                }
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

            if (rb.transform.position.y < -15)
            {
                rb.AddForce(Vector3.up * 1500f);
            }
        }
    }
}
