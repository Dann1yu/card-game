using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Finish_Battle()
    {
        Debug.Log("Hello World.");
    }
    public void Die(GameObject object1)
    {
        Destroy(object1);
    }
}
