using UnityEngine;

public class Witch : Hero
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


    public void DeBuff()
    {
        StartShaking();
        highlighter.SetActive(false);
        Boss boss = GameObject.Find("Boss").GetComponent<Boss>();
        boss.highlighter.SetActive(false);
        boss.power /= power;
        boss.StartShaking();
        GameManager.Instance.whoseMove = "Enemy";
    }
}
