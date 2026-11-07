using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;

    private float maxHealth;

    public float invulnerabilityTime;

    private float invulnerabilityTimer;

    public Image healthBar;
    
    void Start()
    {
        maxHealth = health;    
    }

    
    void Update()
    {
        invulnerabilityTimer -= Time.deltaTime;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && invulnerabilityTimer <= 0)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            health -= enemy.damage;
            healthBar.fillAmount = health / maxHealth;
            if (health <= 0)
            {
                GameOver.instance.Defeat();
            }
            invulnerabilityTimer = invulnerabilityTime;
        }
    }
}