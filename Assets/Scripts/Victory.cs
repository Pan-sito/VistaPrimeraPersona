using TMPro;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public GameObject victoryScreen;

    public float enemysDefeated;

    private float totalEnemys;

    public TextMeshProUGUI winConditionText;

    public static Victory instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        totalEnemys = GameObject.FindGameObjectsWithTag("Enemy").Length;
        winConditionText.text = $"Enemys defeated: {enemysDefeated}/{totalEnemys}";
    }

   
    void Update()
    {
        if (enemysDefeated >= totalEnemys)
        {
            victoryScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        winConditionText.text = $"Enemys defeated: {enemysDefeated}/{totalEnemys}";
    }
}
