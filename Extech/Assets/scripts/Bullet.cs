using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public bool isPlasma = false;
    public bool isFire = false;

    public float plasmaDamage;
    public float fireDamage;

    public GameObject plasmaImpactEffect;
    public GameObject fireImpactEffect;

    float damageToDeal = 0f;

    character _charater;

    private void Start()
    {
        if(isPlasma)
        {
            damageToDeal = plasmaDamage;
        }
        else if(isFire)
        {
            damageToDeal = fireDamage;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "enemy")
        {
            _charater = other.gameObject.GetComponent<character>();
            if(_charater == null)
            {
                return;
            }
            else if(_charater != null)
            {
                Debug.Log("bullet found character script");
            }

            if (isPlasma)
            {
                Instantiate(plasmaImpactEffect, transform.position, transform.rotation);
                _charater.takeDamage(damageToDeal);
            }
            else if(isFire)
            {
                _charater.setOnFire(fireImpactEffect);
            }

            Destroy(this.gameObject);

        }
    }


}
