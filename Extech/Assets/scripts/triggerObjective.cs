using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerObjective : MonoBehaviour {

    GameObject player;
    objectives _objectvies;

    public string objectivesText;
    public string objectiveCompleteText;

    public bool objectiveComplete = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        _objectvies = player.GetComponent<objectives>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _objectvies.modText(objectivesText);
        }
    }

    public void completeObjective(bool complete)
    {
        if(complete)
        {
            _objectvies.modText(objectiveCompleteText);
        }
    }

    public void bombObjective()
    {
        //logic here
    }

}
