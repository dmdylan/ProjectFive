using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth;
    //public GameManagement gameManager;

    // Update is called once per frame
    void Update()
    {
        IsHealthZero();
    }

    private void IsHealthZero()
    {
        if (enemyHealth <= 0)
        {
            Object.Destroy(gameObject);
            GameManagement.playerTotalPoints += 5;
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
}
