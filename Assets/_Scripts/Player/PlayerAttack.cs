using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour
{
    private WeaponManager weapon_Manager;

    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;

    public Animator zoomCameraAnim;
    private bool zoomed;

    private Camera mainCam;

    private GameObject crosshair;

    void Awake()
    {
        weapon_Manager = GetComponent<WeaponManager>();

        // Transform cam = transform.Find(Tags.LOOK_ROOT);
        // if (cam != null)
        //{
        //    Transform zoomCam = cam.Find(Tags.ZOOM_CAMERA);
        //    if (zoomCam != null)
        //        zoomCameraAnim = zoomCam.GetComponent<Animator>();
        //}
        //zoomCameraAnim = transform.Find(Tags.LOOK_ROOT)
        //                                .transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();

        crosshair = GameObject.FindWithTag(Tags.CROSSHAIR);

        mainCam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WeaponShoot();
        ZoomInAndOut();
    }

    void WeaponShoot()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (weapon_Manager.GetCurrentSelectedWeapon() == null)
            return;

        // If we have assault rifle (Probably not required in final version)
        if (weapon_Manager.GetCurrentSelectedWeapon().fireType == WeaponFireType.MULTIPLE)
        {
            // If we press and hold left mouse click AND
            // if Time is greater than the nextTimeToFire
            if (Input.GetMouseButton(0) && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;

                weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                // BulletFired();
            }
        }
        // If we have a weapon that shoots once (Axe/Revolver)
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Handle axe
                if (weapon_Manager.GetCurrentSelectedWeapon().tag == Tags.AXE_TAG)
                {
                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                    BulletFired();
                }
                // Handle shoot
                if (weapon_Manager.GetCurrentSelectedWeapon().bulletType == WeaponBulletType.BULLET)
                {
                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                    BulletFired();
                }
            }
            // If input gets mouse button 0
        }
        // else
    }
    // Weapon shoot
    void ZoomInAndOut()
    {
        if (weapon_Manager.GetCurrentSelectedWeapon() == null)
            return;

        // We are going to aim with our camera on the weapon
        if (weapon_Manager.GetCurrentSelectedWeapon().weapon_Aim == WeaponAim.AIM)
        {
            // If we press and hold the right mouse button
            if (Input.GetMouseButtonDown(1))
            {
                zoomCameraAnim.Play(AnimationTags.ZOOM_IN_ANIM);

                crosshair.SetActive(false);
            }

            // When we release the right mouse button click
            if (Input.GetMouseButtonUp(1))
            {
                zoomCameraAnim.Play(AnimationTags.ZOOM_OUT_ANIM);

                crosshair.SetActive(true);
            }
        }
    }
    void BulletFired()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
        {
            if (hit.transform.tag == Tags.ENEMY_TAG)
            {
                hit.transform.GetComponent<HealthScript>().ApplyDamage(damage);
            }
        }
    }
}
