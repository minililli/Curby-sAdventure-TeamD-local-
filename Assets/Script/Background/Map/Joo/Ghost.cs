using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : TrapBase
{
    [Range(0.0f, 1.0f)]
    public float damageRatio = 0.6f;
    [Range(1.0f, 50.0f)]
    public float pushForce = 20.0f;

    SpriteRenderer ghostRenderer;

    public float speed = 5.0f;
    int dir=1;

    private void Awake()
    {
        ghostRenderer= GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        transform.Translate(Time.fixedDeltaTime * dir * speed * Vector2.left, Space.Self);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player obj = collision.gameObject.GetComponent<Player>();
            if (obj != null)
            {
                obj.HP -= obj.maxHp * damageRatio;
                obj.GetComponent<Rigidbody2D>().AddForce(Vector2.up * pushForce, ForceMode2D.Impulse);
            }
        }

        dir *= -1;
        ghostRenderer.flipX = !ghostRenderer.flipX;
    }

}
