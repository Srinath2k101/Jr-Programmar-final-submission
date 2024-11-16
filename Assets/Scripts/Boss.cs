using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;
public class Boss : MonoBehaviour
{
    public GameObject[] players;
    private GameObject player;
    public GameObject highlighter;
    public int health = 1000;
    public int power = 10;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI pwrText;
    public TextMeshProUGUI titleText;

    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayStats();
        
    }

    public void DisplayStats()
    {
        hpText.text = $"HP: {health}";
        pwrText.text = $"PWR: {power}";
        titleText.text = "Boss";
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(3);
        StartShaking();
        yield return new WaitForSeconds(1);
        GameObject targetPlayer = players[Random.Range(0, players.Length)];
        string playerType = targetPlayer.gameObject.name;
        switch (playerType)
        {
            case "Healer":
                targetPlayer.GetComponent<Healer>().health -= power;
                targetPlayer.GetComponent<Healer>().StartShaking();
                break;
            case "Warrior":
                targetPlayer.GetComponent<Warrior>().health -= power;
                targetPlayer.GetComponent<Warrior>().StartShaking();
                break;
            case "Witch":
                targetPlayer.GetComponent<Witch>().health -= power;
                targetPlayer.GetComponent<Witch>().StartShaking();
                break;
            
        }
        GameManager.Instance.whoseMove = "Player";
        power = 10;
    }

    private void StartAttack()
    {
        StartCoroutine(Attack());
    }

    public void SelectEnemy()
    {
        
        if (GameManager.Instance.currentEnemySelected == null || GameManager.Instance.currentEnemySelected != "Boss")
        {
            GameManager.Instance.currentEnemySelected = "Boss";
            this.highlighter.SetActive(true);
            PlayerAction();
            StartAttack();
        }
        else
        {
            GameManager.Instance.currentEnemySelected = null;
            this.highlighter.SetActive(false);
        }
    }

    public void OnMouseDown()
    {
        if (GameManager.Instance.whoseMove == "Player") SelectEnemy();
    }

    private void PlayerAction()
    {
        switch(GameManager.Instance.currentPlayerSelected)
        {
            case "Warrior":
                player = GameObject.Find("Warrior");
                Warrior warriorScript = player.GetComponent<Warrior>();
                warriorScript.Attack();
                break;
            case "Witch":
                player = GameObject.Find("Witch");
                Witch witchScript = player.GetComponent<Witch>();
                witchScript.DeBuff();
                break;
        }
    }

    public void StartShaking()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {

        Vector3 originalPosition = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
