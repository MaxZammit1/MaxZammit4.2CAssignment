using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{

    [SerializeField] int scoreValue = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PolygonCollider2D>())
        {
            FindObjectOfType<GameSession>().AddToScore(scoreValue);

        }

        Destroy(collision.gameObject);
    }
}