using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour {

    public weapon characterWeapon;

    public float health =1f;
    public float stamina = 1f;
    public bool alive = true;

    public float moveSpeed = 0f;
    public float rotateSpeed = 0f;
    public float boostSpeed = 0f;

    public float weaponOneAmmo = 0;

    public Slider characterHealthBar;

    public bool isOnFire = false;
    public float fireDamageOverTime = 0.1f;
    public float burnTime = 5f;
    public float burnTickRate = 1f;

    public void Start()
    {
        characterHealthBar.value = health;

        //characterWeapon = this.gameObject.GetComponent<weapon>();

        if (characterWeapon == null)
        {
            return;
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        characterHealthBar.value = health;
    }

    public void takeFireDamage()
    {
        if (isOnFire)
        {
            health -= 0.2f;
        }
        else
        {
            return;
        }

        characterHealthBar.value = health;
    }


    public void heal(float healing)
    {
        health += healing;
    }

    public void giveAmmo(int ammoAmmount, int ammoType)
    {
        if(ammoType == 0)
        {
            characterWeapon.gas += ammoAmmount;
        }
    }

    public void setOnFire(GameObject fire)
    {
        GameObject fireDamageEffect;

        if (!isOnFire)
        {
            isOnFire = true;
            fireDamageEffect = Instantiate(fire, transform.position, transform.rotation);
            fireDamageEffect.transform.parent = this.gameObject.transform;

            if (isOnFire)
            {
                burnTime -= Time.deltaTime;

                InvokeRepeating("takeFireDamage", 0f, burnTickRate);

                if (burnTime <= 0)
                {
                    isOnFire = false;
                    CancelInvoke();
                    Destroy(fireDamageEffect);
                }
            }
        }
    }

    public void die()
    {
        //death logic here
    }
}
