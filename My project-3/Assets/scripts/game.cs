using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject card;
    public SpriteRenderer spriteRenderer;
    public Sprite newsprite;

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
        GameObject Circle = GameObject.Instantiate(GameObject.Find("Card"));
        Circle.transform.localPosition = new Vector3(2, 2,2);
        //Circle.Sprite = newsprite;
    }
}
