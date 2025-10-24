using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject gun;
    [SerializeField] GameObject bulletHole;
    [SerializeField] Animator gunAnimator;
    public Transform InteractorSource;
    public AudioSource gunSound;
    public float gunDamage;
    public float InteractRange;

    void Start()
    {
        gunSound = gun.GetComponent<AudioSource>();
        gunDamage = 10f;
        InteractRange = 30f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && gun.activeSelf)
        {
            gunSound.Play();
            gunAnimator.Play("gunshot", 0, 0f);
            //gunAnimator.SetTrigger("Gunshot");
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.tag == "Destructable")
                {
                    hitInfo.collider.GetComponent<Rigidbody>().AddForceAtPosition(InteractorSource.forward * 2000f, hitInfo.point);
                    if (hitInfo.collider.gameObject.GetComponent<EyeFollow>())
                    {
                        EyeFollow enemy = hitInfo.collider.gameObject.GetComponent<EyeFollow>();
                        enemy.hurtSound.Play();
                        enemy.eyeHealth -= gunDamage;
                    }
                    else if (hitInfo.collider.gameObject.GetComponent<EyeBoss>())
                    {
                        EyeBoss boss = hitInfo.collider.gameObject.GetComponent<EyeBoss>();
                        boss.hurtSound.Play();
                        boss.eyeHealth -= gunDamage;
                    }
                    //enemy.dead = true;
                }
            }
        }
    }
}
