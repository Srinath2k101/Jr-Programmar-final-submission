using UnityEngine;
using System.Collections;
public class Warrior : Hero
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayStats();
        
    }

    public void Attack()
    {
        StartShaking();
        highlighter.SetActive(false);
        Boss boss = GameObject.Find("Boss").GetComponent<Boss>();
        boss.highlighter.SetActive(false);
        boss.health -= power;
        boss.StartShaking();
        GameManager.Instance.whoseMove = "Enemy";

    }




        

    

}
    
