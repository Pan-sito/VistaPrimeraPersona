using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;

    public float health;

    private float maxHealth;

    public Image healthBar;

    public float damage;

    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("FollowPlayer", 1f, 0.5f);
        maxHealth = health;
        animator = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(collision);
        }
    }

    private void OnDestroy()
    {
        Victory.instance.enemysDefeated += 1;
    }

    private void TakeDamage(Collision collision)
    {
        health -= 25;
        Destroy(collision.gameObject);
        healthBar.fillAmount = health / maxHealth;
        if(health <= 0)
        {
            GetComponent<CapsuleCollider>().enabled = false;
            animator.SetTrigger("Death");
            agent.isStopped = true;
            Destroy(gameObject, 5f);
        }
    }

    private void FollowPlayer()
    {
        agent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;      
    }
}