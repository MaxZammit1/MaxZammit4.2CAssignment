using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] float health = 100f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.7f;

    [SerializeField] AudioClip playerHit;
    [SerializeField] [Range(0, 1)] float playerHitSound = 0.7f;

    [SerializeField] int scoreValue = 5;

    float xMin, xMax;

    void Start()
    {
        SetUpMoveBoundaries();
    }

    void Update()
    {
        Move();
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        this.transform.position = new Vector2(newXPos, transform.position.y);

    }

    private void OnTriggerEnter2D(Collider2D bullet)
    {
        DamageDealer DmgDeal = bullet.gameObject.GetComponent<DamageDealer>();
        AudioSource.PlayClipAtPoint(playerHit, Camera.main.transform.position, playerHitSound);

        if (!DmgDeal)
        {
            return;
        }

        ProcessHit(DmgDeal);

        Destroy(bullet.gameObject);

    }

    private void ProcessHit(DamageDealer dmgDeal)
    {
        health -= dmgDeal.GetDamage();

        if (health <= 0)
        {
            Destroy(gameObject);

            FindObjectOfType<Level>().LoadGameOver();
        }

        
    }
}
