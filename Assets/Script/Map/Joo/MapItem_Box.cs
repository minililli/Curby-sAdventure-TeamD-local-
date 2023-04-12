using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class MapItem_Box : MapItem_Base
{
    public int exp = 5;
    public float itemchance = 0.4f;
    float r;
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Skill1") || collision.gameObject.CompareTag("Skill3"))
        {
            GetRidOfBox();
        }
        player.AddExp(exp);
    }
    void GetRidOfBox()
    {
        this.gameObject.SetActive(false);
        r = Random.Range(0.0f, 1.0f);
        if (r < 0.4f)
        {
            GameObject obj = Factory.Inst.GetObject(PoolObjectType.ItemStar); //아이템 생성
            obj.GetComponents<ItemStar>();
            obj.transform.position = transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Skill2"))
        {
            this.gameObject.SetActive(false);
            player.AddExp(exp);
        }
    }

}
