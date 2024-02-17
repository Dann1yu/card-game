using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrentAbility : MonoBehaviour
{
    Battle battleScript;
    // Start is called before the first frame update
    void Start()
    {
        battleScript = GameObject.FindGameObjectWithTag("Battle").GetComponent<Battle>();
        battleScript.Finish_Battle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
