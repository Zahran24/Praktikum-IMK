using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    // public float fireRate = 0.3f;
    private GameObject muzzleFlash;
    private AudioSource fireSound;
    private float range = 20.0f;

    private LineRenderer laserLine;

    // Start is called before the first frame update
    void Start()
    {
        this.muzzleFlash = GameObject.Find("MuzzleFlash");
        this.fireSound = GetComponentInChildren<AudioSource>();
        this.laserLine = GetComponent<LineRenderer>();

        this.muzzleFlash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale > 0.0f)
        {
            this.Controls();
        }
    }

    void Controls()
    {
        if(Input.GetMouseButtonDown(0))
        {
            this.fireSound.Play();
            this.Fire();
            StartCoroutine(ToggleMuzzleFlash());
            StartCoroutine(RenderLaserLine());
        }
    }

    void Fire()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        laserLine.SetPosition(0, this.transform.position);

        if(Physics.Raycast(ray, out hit, this.range))
        {
            laserLine.SetPosition(1, hit.point);
            // Debug.DrawRay(ray.origin, hit.point);
            if(hit.collider.name != "Plane")
            {
                Destroy(hit.collider.gameObject);
            }
        }
        else
        {
            laserLine.SetPosition(1, ray.direction + (Camera.main.transform.forward * this.range));
        }
    }

    IEnumerator ToggleMuzzleFlash()
    {
        this.muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        this.muzzleFlash.SetActive(false);
    }

    IEnumerator RenderLaserLine()
    {
        this.laserLine.enabled = true;
        yield return new WaitForSeconds(0.3f);
        this.laserLine.enabled = false;
    }

}
