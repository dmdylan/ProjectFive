using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth;
    private Renderer render;

    private void Awake()
    {
        render = GetComponent<Renderer>();        
    }

    void Update()
    {
        IsHealthZero();
        ChangeColorBasedOnHealthValue();
    }

    private void IsHealthZero()
    {
        if (enemyHealth <= 0)
        {
            Object.Destroy(gameObject);
            GameManagement.playerTotalPoints += 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            enemyHealth -= 1;
        }

        if (collision.gameObject.tag == "EnemyBoundary")
        {
            Destroy(gameObject);
        }
    }

    private void ChangeColorBasedOnHealthValue()
    {
        Color color = new Color(1, 0.3607f, 0.3607f);
        if(enemyHealth == 1)
        {
            render.material.SetColor("_Color", color);
        }
    }
}
