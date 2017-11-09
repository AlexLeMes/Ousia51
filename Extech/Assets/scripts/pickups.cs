using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickups : MonoBehaviour {

    GameObject _player;
    //public player _playerScript;
    public character _character;


    private keycard _keycard;

    public float healAmmount = 5;
    public int ammoType = 0; // 0 = gas   --- plasma is infinite, so no ID for it
    public int ammoToGive = 0;
    public int cardID;

    public bool healthPickup = false;
    public bool ammoPickup = false;
    public bool keycard = false;
   
    public void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        //_playerScript = _player.GetComponent<player>();
        _character = _player.GetComponent<character>();
    }


   public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("pickup - hit player");

            if (healthPickup)
            {
                _character.heal(healAmmount);
                healthPickup = false;
                Debug.Log("yes");
            }
            else
            {
                return;
            }
                //player.heal(healAmmount);

            if(ammoPickup)
            {
                //player.giveAmmo(ammoToGive, ammoType);
                if (_character)
                {
                    _character.giveAmmo(ammoToGive, ammoType);
                }
                else
                {
                    return;
                }
            }
            if(keycard)
            {
                _keycard = other.gameObject.GetComponent<keycard>();

                if(_keycard == null)
                {
                    return;
                }
                else
                {
                    _keycard.keycardPickup(cardID);
                }
            }

            Destroy(this.gameObject);

        }
    }
}
