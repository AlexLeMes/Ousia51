using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weapon : MonoBehaviour {

    public bool flamethrower;

    public float powerattacktimer = 0;

    public GameObject plasmaInUse;
    public GameObject fireInUse;

    public bool ischarging;
    public bool flamethrowerpicked;
    //public GameObject ammopack;
    //public GameObject gaspack;

    public int gas;
    public Slider gasBar;
    public GameObject gasBarObj;

    public GameObject plasma;
    public GameObject plasmaSpecial;
    public GameObject flameBullet;

    GameObject plasmashot;
    GameObject flameShot;

    public Vector3 weaponpos;
    public ParticleSystem flame;

    Rigidbody plasmarb;
    Rigidbody flameBulletRB;

    public float force;
    public float flameForce;
    public float powerattack;
    public bool plasmadf;

    public ParticleSystem chargingEffect;

    //gunLookat _gunLookat;
    bool canshoot;

    public Text ammoText;
    public Text currentWeapon;
    bool showAmmo = false;

    // Use this for initialization
    void Start()
    {
        ischarging = false;
        plasmadf = true;
        flamethrower = false;

        showAmmo = false;

        currentWeapon.text = "Debug: Plasma Gun";

        plasmaInUse.SetActive(true);
        fireInUse.SetActive(false);
        gasBarObj.SetActive(false);



        gasBar.value = gas;

        //flamethrowerpicked = false;

        //_gunLookat = this.gameObject.GetComponent<gunLookat>();
        //canshoot = _gunLookat.canShoot;
        //  MAKE THIS BOOL WORK
    }


    void Update()
    {
        //weaponpos = transform.position;

        if (gas <= 0)
        {
            canshoot = false;
        }
        else if (gas > 0)
        {
            canshoot = true;
        }

        if (Input.GetMouseButton(1)) //starts the timer for charging the plasma weapon
        {
            ischarging = true;
        }

        if (ischarging)
        {
            chargingEffect.Play();
        }
        else if (!ischarging)
        {
            chargingEffect.Stop();
        }


        if (Input.GetMouseButton(1) && plasmadf) //starts the timer for charging the plasma weapon
        {
            powerattacktimer += Time.deltaTime;
            ischarging = true;
        }
        if (Input.GetMouseButtonUp(1) && powerattacktimer > 2 && ischarging && plasmadf)
        {
            powerattackpl();
            powerattacktimer = 0;
        }
        if (Input.GetMouseButtonUp(1) && powerattacktimer < 2 && plasmadf)
        {
            powerattacktimer = 0;
            ischarging = false;
        }
        if (Input.GetMouseButtonDown(0) && powerattacktimer < 2 && plasmadf)
        {
            shootPlasmaGun();
        }
        

        /*
        if (flamethrowerpicked)
        {
            chooseweapon();

        }
        */


        //choose weapon
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            flamethrower = false;
            plasmadf = true;
            showAmmo = false;

            currentWeapon.text = "Plasma Gun";
            fireInUse.SetActive(false);
            plasmaInUse.SetActive(true);
            gasBarObj.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            plasmadf = false;
            flamethrower = true;
            showAmmo = true;

            gasBar.value = gas / 10;

            currentWeapon.text = "Flamethrower";
            plasmaInUse.SetActive(false);
            fireInUse.SetActive(true);
            gasBarObj.SetActive(true);
        }

        if (showAmmo)
        {
            ammoText.text = "DEBUG: GAS: " + gas.ToString();
        }
        else if(!showAmmo)
        {
            ammoText.text = " ";
        }


        if (Input.GetMouseButton(0) && flamethrower && canshoot)
        {
            flame.Play();
            shootFlameThrower();
            gas--;
            gasBar.value = gas;
        }
        else
        {
            flame.Stop();
        }

    }
    public void shootPlasmaGun()
    {
        plasmashot = Instantiate(plasma, transform.position, Quaternion.identity);
        plasmarb = plasmashot.GetComponent<Rigidbody>();
        plasmarb.AddForce(transform.forward * force);

    }
    public void powerattackpl()
    {
        plasmashot = Instantiate(plasmaSpecial, transform.position, Quaternion.identity);
        plasmarb = plasmashot.GetComponent<Rigidbody>();
        plasmarb.AddForce(transform.forward * force);
    }

    public void shootFlameThrower()
    {
        flameShot = Instantiate(flameBullet, transform.position, Quaternion.identity);
        flameBulletRB = flameShot.GetComponent<Rigidbody>();
        flameBulletRB.AddForce(transform.forward * flameForce);
    }

    /*
    public void chooseweapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && flamethrowerpicked == true)
        {
            flamethrower = true;
            plasmadf = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            plasmadf = true;
            flamethrower = false;
        }


    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<weapon>() != null)
        {
            flamethrowerpicked = true;
        }
    }
    */

}

