using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ghost : TrapBase
{
    float ghostdamage;
    int count;
    SpriteRenderer ghostRenderer;
    int dir;
    
    protected override void Awake()
    {
        base.Awake();
        ghostRenderer = GetComponent<SpriteRenderer>();
    }
    protected override void Start()
    {
        dir = 1;
        SetDamage(player);
    }

    private void Update()
    {
        transform.Translate(Time.deltaTime * dir * Vector2.left );
    }
    float SetDamage(Player player)
    {
        ghostdamage = player.maxHp * 0.6f;
        return ghostdamage;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player obj = collision.gameObject.GetComponent<Player>();
            SetDamage(obj);
            damage = ghostdamage;
            obj.HP -= ghostdamage;
            obj.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 20.0f, ForceMode2D.Impulse);
            obj.OnInvincibleMode();
            obj.StartCoroutine(SlowDown());
        }
        dir *= -1;
    }
}
