using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExitSign : MapItem_Base
{
    protected PlatformKillzone killzone;
    private void Awake()
    {
        killzone = FindObjectOfType<PlatformKillzone>();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            killzone.OnStageEnd();
        }
    }
}
