using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
public class Game : MonoBehaviour
{
    // Start is called before the first frame update

    public bool finished;
    bool playerLost;
    public SpriteRenderer sprite_Renderer;
    public Sprite sprite;
    public Sprite[] newsprite = new Sprite[12];
    public cards cardscript;
    public GameObject CardPrefab;
    public List<GameObject> playerCards = new List<GameObject>();
    public List<GameObject> enemyCards = new List<GameObject>();
    public List<GameObject> allCards = new List<GameObject>();
    public List<GameObject> randomCards = new List<GameObject>();
    System.Random random = new System.Random();

    void Start()
    {


        create_card("kronk", 0, 10, 10, 10, 10);
        create_card("politician", 1, 4, 1, 6, 2);
        create_card("shapiro", 2, 10, 10, 10, 10);
        create_card("lizzie", 3, 10, 10, 10, -1);
        create_card("Trent", 4, 10, 4, 3, 10);
        create_card("William", 5, 5, 5, 5, 5);
        create_card("Pete", 6, 7, 2, 4, 3);
        create_card("Andy", 7, 2, 6, 2, 4);
        create_card("Chad", 8, 8, 3, 7, 7);
        create_card("Tech_bro", 9, 4, 7, 3, 5);
        create_card("Kaylor", 10, 4, 7, 9, 7);
        create_card("league", 11, 1, 9, 1, 1);
        int n = allCards.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            GameObject value = allCards[k];
            allCards[k] = allCards[n];
            allCards[n] = value;

        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void create_card(string name, int id, int str, int intel, int rizz, int health)
    {
        GameObject Circle = GameObject.Instantiate(CardPrefab);
        Circle.transform.localPosition = new Vector3(2, 2, 2);
        Circle.name = name;
        //deck[id] = name;

        cards cardscript = Circle.GetComponent<cards>();

        sprite_Renderer = Circle.GetComponent<SpriteRenderer>();
        sprite_Renderer.sprite = newsprite[id];



        cardscript.strength = str;
        cardscript.health = health;
        cardscript.intelligence = intel;
        cardscript.charissma = rizz;

        allCards.Add(Circle);
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
    public void Start_Battle()
    {
        if (playerLost)
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