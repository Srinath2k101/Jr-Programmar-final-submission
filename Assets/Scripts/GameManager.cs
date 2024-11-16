using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string currentPlayerSelected;
    public string currentEnemySelected;
    public string whoseMove;

    public static GameManager Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        whoseMove = "Player";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            Debug.Log("right");
        }
        if (Input.GetMouseButton(0))
        {
            Debug.Log("left");
        }
    }

    

}
