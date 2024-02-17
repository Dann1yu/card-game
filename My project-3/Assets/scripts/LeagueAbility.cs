using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeagueAbility : MonoBehaviour
{
    public Battle battleScript;
    int strength = 0;
    bool abilityTriggered;
    // Start is called before the first frame update
    void Start()
    {
        battleScript = GameObject.FindGameObjectWithTag("Battle").GetComponent<Battle>();
    }

    // Update is called once per frame
    void Update()
    {

         if(battleScript.finished && !abilityTriggered)
         {
            strength += 5;
            abilityTriggered = true;
            battleScript.finished = false;
         }
    }
}
