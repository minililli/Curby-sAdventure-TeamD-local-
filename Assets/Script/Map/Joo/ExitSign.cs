using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSign : MonoBehaviour
{
    PlatformKillzone killzone;
    private void Awake()
    {
        killzone = FindObjectOfType<PlatformKillzone>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            killzone.StageEnd();
        }
    }
}
