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

    bool ridePlatform = false;

    public Action<Vector2> onRide;

    private void Awake()
    {
        targetTransform = FindObjectOfType<Player>().transform;
    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        transform.Translate(Time.fixedDeltaTime*moveSpeed*Vector2.left);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ridePlatform = true;
        if(ridePlatform)
        {
            OnMove();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ridePlatform = false;
        }
    }

    void OnMove()
    {
        moveDir = targetTransform.position- transform.position;
        moveDelta = (Time.fixedDeltaTime * moveSpeed * moveDir);
        onRide?.Invoke(moveDelta);
    }
}
