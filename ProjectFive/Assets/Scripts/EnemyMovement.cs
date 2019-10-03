using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float enemySpeed = 6.0f;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float step = enemySpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, GameObject.FindWithTag("Player").transform.position, step);
    }
}
