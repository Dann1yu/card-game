using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrentAbility : MonoBehaviour
{
    public Battle battleScript;
    int health;
    int strength;
    // Start is called before the first frame update
    void Start()
    {
        battleScript = GameObject.FindGameObjectWithTag("Battle").GetComponent<Battle>();

    }

    // Update is called once per frame
    void Update()
    {
        if (battleScript.finished){
                health -= 3;
                strength -=3;
             if (health < 0){
                battleScript.Die(GameObject.Find("Trent"));
             }
        }
    }
}
