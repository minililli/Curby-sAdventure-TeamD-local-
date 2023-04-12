using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBase: MonoBehaviour
{

    public float slowTime;
    WaitForSeconds slow;

    public float damage=2.0f;          //TrapBase 기본 damage
  
    protected Player player;

    protected virtual void Awake()
    {
        slow = new WaitForSeconds(slowTime);
        player = FindObjectOfType<Player>();
    }
    protected virtual void Start()
    {
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
            Debug.Log(damage);
        if (collision.gameObject.CompareTag("Player"))
        {
            Player obj = collision.gameObject.GetComponent<Player>();
            obj.HP -= damage;
            obj.OnInvincibleMode();
            obj.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 16.0f, ForceMode2D.Impulse);
        }
    }

    protected IEnumerator SlowDown()
    {
        player.MoveSpeed *= 0.5f;
        yield return slowTime;
        player.MoveSpeed *= 2.0f;
    }

}
