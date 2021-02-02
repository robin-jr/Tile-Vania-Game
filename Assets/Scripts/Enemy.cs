using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    int moveDirection = 1;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(moveSpeed * moveDirection * Time.deltaTime, 0f));
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        moveDirection = -moveDirection;
        transform.localScale = new Vector2(moveDirection, 1f);
    }
}
