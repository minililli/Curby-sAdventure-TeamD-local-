using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolObjectType
{
    None=-1,
    Attack=0,
    Enemy,
    Trap,
    Coin,
    Item
}

public class Factory : Singleton<Factory>
{

}
