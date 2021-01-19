using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    [SerializeField] AudioClip playerHit;
    [SerializeField] [Range(0, 1)] float playerHitSound = 0.7f;

    [SerializeField] int scoreValue = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PolygonCollider2D>())
        {
            FindObjectOfType<GameSession>().AddToScore(scoreValue);

            AudioSource.PlayClipAtPoint(playerHit, Camera.main.transform.position, playerHitSound);

        }

        Destroy(collision.gameObject);
    }
}