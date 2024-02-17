using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenAbility : MonoBehaviour
{
    public Battle battleScript;
    bool abilityTriggered;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(battleScript.finished && !abilityTriggered)
        {
            battleScript.Die(GameObject.Find("Queen"));
            abilityTriggered = true;

        }
    }
}
