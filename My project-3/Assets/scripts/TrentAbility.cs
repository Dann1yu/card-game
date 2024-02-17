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
            if (health > 2 && strength > 2){
                health -= 4;
                strength -=4;
             }
             else{
             battleScript.Die(GameObject.Find("Trent"));}
        }
    }
}
