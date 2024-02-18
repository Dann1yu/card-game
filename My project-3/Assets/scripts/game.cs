using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class Game : MonoBehaviour
{
    // Start is called before the first frame update

    public bool finished;
    bool playerLost = true;
    public SpriteRenderer sprite_Renderer;
    public Sprite sprite;
    public Sprite[] newsprite = new Sprite[12];
    public cards cardscript;
    public GameObject CardPrefab;
    //We're using lists now it's easier
    public List<GameObject> playerCards = new List<GameObject>();
    public List<GameObject> enemyCards = new List<GameObject>();
    public List<GameObject> allCards = new List<GameObject>();
    public Dictionary<string, int> playerAttributes = new Dictionary<string, int>();
    public Dictionary<string, int> enemyAttributes = new Dictionary<string, int>();
    public GameObject playerCard;
    public GameObject enemyCard;
    public bool pressed;
    public string value;

    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;
    
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
        create_card("Andy", 7, 6, 4, 2, 4);
        create_card("Chad", 8, 8, 3, 7, 7);
        create_card("Tech_bro", 9, 4, 7, 3, 5);
        create_card("Kaylor", 10, 4, 7, 9, 7);
        create_card("league", 11, 1, 9, 1, 1);
        //This is the shuffle part
        int n = allCards.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            GameObject value = allCards[k];
            allCards[k] = allCards[n];
            allCards[n] = value;

        }
        //Deal the cards to the player and the enemy
        for (int i = 0; i < 6; i++) 
        {
            playerCards.Add(allCards[i]);
        }
        for (int i = 6; i < 12; i++)
        {
            enemyCards.Add(allCards[i]);
        }
        Start_Battle(playerCards[0], enemyCards[0]);
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
        cardscript.charisma = rizz;

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
    public void onClick1()
    {
        Debug.Log(pressed);
        value = "strength";
        pressed = true;
        //btn1.SetActive(false);
        Start_Battle(playerCards[0], enemyCards[0]);

    }
    public void onClick2()
    {
        value = "intelligence";
        pressed = true;
        //btn2.interactable = false;
        Start_Battle(playerCards[0], enemyCards[0]);
    }
    public void onClick3()
    {
        value = "charisma";
        pressed = true;
        Start_Battle(playerCards[0], enemyCards[0]);
        //btn3.interactable = false;
    }
    public void onClick4()
    {
        value = "health";
        Start_Battle(playerCards[0], enemyCards[0]);
        //btn4.interactable = false;
    }
    private void shuffle_deck()
    {
        //shuffle the deck array please
    }
    //before the battle gain the attributes to be compared
    public void Start_Battle(GameObject playerCard, GameObject enemyCard)
    {
        string value = "strength";
        int playerValue;
        this.playerCard = playerCard;
        this.enemyCard = enemyCard;
        playerCard.transform.position = new Vector3(-6, 0, 0);
        enemyCard.transform.position = new Vector3(6, 0, 0);
        cards cardscript = playerCard.GetComponent<cards>();
        cards cardscript2 = enemyCard.GetComponent<cards>();
        playerAttributes.Add("strength", cardscript.strength);
        playerAttributes.Add("intelligence", cardscript.intelligence);
        playerAttributes.Add("charisma", cardscript.charisma);
        playerAttributes.Add("health", cardscript.health);
        enemyAttributes.Add("strength", cardscript2.strength);
        enemyAttributes.Add("intelligence", cardscript2.intelligence);
        enemyAttributes.Add("charisma", cardscript2.charisma);
        enemyAttributes.Add("health", cardscript2.health);
       
        int enemyValue = enemyAttributes["strength"];
        if (playerLost)
        {
            foreach(KeyValuePair<string,int> i in enemyAttributes) {
                if(i.Value > enemyValue)
                {
                    enemyValue = i.Value;
                    value = i.Key;
                }
            }
            playerValue = playerAttributes[value];
            Battle(playerValue, enemyValue);
            
        }
        else if(pressed = true)
        {
            
            playerValue = playerAttributes[value];
            enemyValue = enemyAttributes[value];
            pressed = false;
            Battle(playerValue, enemyValue);
        }
    }
    //Once you have the attributes start the battle
    public void Battle(int playerValue, int enemyValue)
    {
        
        //player wins
        if (playerValue > enemyValue)
        {
            Debug.Log("test");
            playerLost = false;
            playerCards.Add(enemyCard);
            playerCards.Insert(playerCards.Count, playerCard);
            enemyCards.Remove(enemyCard);
            Finish_Battle();
        }
        //player draws, choose a random value and play again
        if(playerValue == enemyValue)
        {
            playerValue = playerAttributes.ElementAt(random.Next(0, playerAttributes.Count)).Value;
            enemyValue = enemyAttributes.ElementAt(random.Next(0, playerAttributes.Count)).Value;
            Battle(playerValue, enemyValue);
        }
        //player loses
        if(playerValue < enemyValue)
        {
            Debug.Log("Test again");
            playerLost = true;
            enemyCards.Add(playerCard);
            enemyCards.Insert(enemyCards.Count, enemyCard);
            playerCards.Remove(playerCard);
            Finish_Battle();
        }
    }
    public void Finish_Battle()
    {
        playerAttributes.Clear();
        enemyAttributes.Clear();
        finished = true;
        Debug.Log("Hello World.");
        pressed = false;
        Start_Battle(playerCards[0], enemyCards[0]);
    }
    public void Die(GameObject object1)
    {
        Destroy(object1);
    }
}