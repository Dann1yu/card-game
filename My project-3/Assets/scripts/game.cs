using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
    // Start is called before the first frame update

    
    public SpriteRenderer sprite_Renderer;
    public Sprite sprite;
    public Sprite[] newsprite = new Sprite[30];
    public cards cardscript;
    public GameObject CardPrefab;
    public string[] deck;

    void Start()
    {
        

        create_card("krunk", 0, 1, 1, 3, 4);
        create_card("james", 1, 3, 3, 3, 4);
        create_card("shapior", 2, 33, 32, 31, 4);


       //create_card("null", 0, 0, 0, 0, 0);
        //delete_card("Card");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void create_card(string name,int id, int str, int intel, int rizz, int health)
    {
        GameObject Circle = GameObject.Instantiate(CardPrefab);
        Circle.transform.localPosition = new Vector3(2, 2,2);
        Circle.name = name;
        //deck[id] = name;

        cards cardscript = Circle.GetComponent<cards>();

        sprite_Renderer = Circle.GetComponent<SpriteRenderer>();
        sprite_Renderer.sprite = newsprite[id];
        
        

        cardscript.strength = str;
        cardscript.health = health;
        cardscript.intelligence = intel;
        cardscript.charissma = rizz;

    }

    private void delete_card(string name)
    {
        GameObject Circle = (GameObject.Find(name));
        Debug.Log(Circle.name);
        Destroy(Circle);
        
    }

    //subrouitne to shuffle an array of the names or ids of the cards and then 
    //give to both players

    private void shuffle_deck()
    {
       //shuffle the deck array please
    }
}
