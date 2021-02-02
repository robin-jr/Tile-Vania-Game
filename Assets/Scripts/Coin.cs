using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int score = 100;
    [SerializeField] AudioClip sfx;
    private void OnTriggerEnter2D(Collider2D other)
    {
        AudioSource.PlayClipAtPoint(sfx, Camera.main.transform.position);
        FindObjectOfType<GameSession>().AddToScore(score);
        Destroy(gameObject);
    }
}
