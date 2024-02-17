using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class cards : MonoBehaviour
{

    public int age;
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        create_card("krunk", 3, 3, 3, 3);
        create_card("krunk", 3, 3, 3, 3);
        create_card("krunk", 3, 3, 3, 3);
        create_card("krunk", 3, 3, 3, 3);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void create_card(string name, int str, int intel, int rizz, int health)
    {

    }
}
