using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    bool playerLost;
    public bool finished;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Start_Battle()
    {
        if(playerLost)
        {
            
        }
    }
    public void Finish_Battle()
    {
        finished = true;
        Debug.Log("Hello World.");
    }
    public void Die(GameObject object1)
    {
        Destroy(object1);
    }
}
