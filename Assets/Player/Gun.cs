using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject gun;
    [SerializeField] GameObject muzzleFlash;
    [SerializeField] Animator gunAnimator;
    public Transform InteractorSource;
    public AudioSource gunSound;
    public float gunDamage;
    private float gunTime;
    private float gunCooldown;
    public float InteractRange;

    void Start()
    {
        gunSound = gun.GetComponent<AudioSource>();
        gunDamage = 10f;
        InteractRange = 30f;
        gunTime = Time.time;
        gunCooldown = 1.5f;
    }

    void Update()
    {
        muzzleFlash.SetActive(false);
        if (Input.GetKeyDown(KeyCode.Mouse0) && gun.activeSelf && (gunTime + gunCooldown < Time.time))
        {
            gunTime = Time.time;
            gunSound.Play();
            gunAnimator.Play("gunshot", 0, 0f);

            muzzleFlash.SetActive(true);

            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.tag == "Destructable")
                {
                    hitInfo.collider.GetComponent<Rigidbody>().AddForceAtPosition(InteractorSource.forward * 4000f, hitInfo.point);
                    if (hitInfo.collider.gameObject.GetComponent<EyeFollow>())
                    {
                        EyeFollow enemy = hitInfo.collider.gameObject.GetComponent<EyeFollow>();
                        if (enemy.dead == false)
                        {
                            enemy.hurtSound.Play();
                            enemy.eyeHealth -= gunDamage;
                        }
                    }
                }
            }
        }
    }
}
