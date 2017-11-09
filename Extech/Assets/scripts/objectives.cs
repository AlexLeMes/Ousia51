using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectives : MonoBehaviour {

    public string objectTiveText;
    public Text _objectiveText;

    public bool isActive = false;

    public bool objectiveComplete = false;

    public float objectiveTime = 0f;

    public GameObject explostion;

    public GameObject successMenu;

    triggerObjective _objectiveTrigger;

    private void Awake()
    {
        explostion.SetActive(false);
        successMenu.SetActive(false);
    }

    private void Update()
    {
        _objectiveText.text = objectTiveText;

        if(isActive && objectiveTime > 0)
        {
            objectiveTime -= Time.deltaTime;
            _objectiveText.text = objectiveTime.ToString("F2") + objectTiveText;
		}

        if(!objectiveComplete && objectiveTime <= 0)
        {
            failedObjective();
        }
        else if(objectiveComplete && objectiveTime > 0)
        {
            succesfulObjective();
        }
    }

    public void failedObjective()
    {
        explostion.SetActive(true);
    }

    public void succesfulObjective()
    {
        successMenu.SetActive(true);
        // manger set time scale to 0 here
    }

    public void modText(string text)
    {
        objectTiveText = text;
    }

    private void OnTriggerEnter(Collider other)
    {
        bool status = false;

        if(other.gameObject.tag == "objective")
        {
            _objectiveTrigger = other.gameObject.GetComponent<triggerObjective>();

            status = true;

            if (_objectiveText == null)
            {
                return;
            }
            else
            {
                _objectiveTrigger.completeObjective(status);
            }
        }
    }

}
