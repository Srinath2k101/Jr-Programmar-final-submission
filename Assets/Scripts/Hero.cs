using UnityEngine;
using TMPro;
using System.Collections;

public enum CharacterType { Warrior, Healer, Witch }
public abstract class Hero : MonoBehaviour
{
    public GameObject highlighter;
    public CharacterType characterType;
    public int health;
    public int power;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI pwrText;

    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayStats()
    {
        hpText.text = $"HP: {health}";
        pwrText.text = $"PWR: {power}";
    }

    public void SelectHero()
    {
        if (GameManager.Instance.currentPlayerSelected == null || GameManager.Instance.currentPlayerSelected != this.characterType.ToString())
        {
            GameManager.Instance.currentPlayerSelected = this.characterType.ToString();
            this.highlighter.SetActive(true);
        }
        else
        {
            GameManager.Instance.currentPlayerSelected = null;
            this.highlighter.SetActive(false);
        }

    }


    public void OnMouseDown()
    {
        if (GameManager.Instance.whoseMove == "Player")
        {
            if (Input.GetMouseButton(0))
            { SelectHero(); Debug.Log("Left-click detected"); }

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
