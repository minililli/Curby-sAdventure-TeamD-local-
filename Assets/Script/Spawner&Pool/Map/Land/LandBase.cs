using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandBase : PoolObject
{
    public float moveSpeed = 1;
    Transform currentTransform;
    Vector2 moveDir;
    Vector2 moveDelta;
    Transform targetTransform;
    Rigidbody2D rigid;

    bool ridePlatform = false;

    public Action<Vector2> onRide;

    private void Awake()
    {
        targetTransform = FindObjectOfType<Player>().transform;
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(Time.fixedDeltaTime * moveSpeed * Vector2.left);
        //Debug.Log($"{gameObject.name} , {transform.position}");
        OnMove(Time.fixedDeltaTime * moveSpeed * Vector2.left);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            ridePlatform = true;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ridePlatform = false;
        }
    }

    void OnMove(Vector2 delta)
    {
        if (ridePlatform)
        {
            moveDir = targetTransform.position - transform.position;
            moveDelta = (Time.fixedDeltaTime * moveSpeed * moveDir);

            Debug.Log($"OnMove : {delta}");
            onRide?.Invoke(delta);
        }
    }
}
