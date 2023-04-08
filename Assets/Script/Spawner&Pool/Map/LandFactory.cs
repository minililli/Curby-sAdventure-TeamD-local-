using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrackType
{
    Land1 = 0,
    Land2,
    Land3,
    Land4
}
public class LandFactory : Singleton<LandFactory>
{
    Land1Pool land1pool;
    Land2Pool land2pool;
    Land3Pool land3pool;
    Land4Pool land4pool; 

    protected override void PreInitialize()
    {
        land1pool = GetComponentInChildren<Land1Pool>();
        land2pool = GetComponentInChildren<Land2Pool>();
        land3pool = GetComponentInChildren<Land3Pool>();
        land4pool = GetComponentInChildren<Land4Pool>();
       
    }

    protected override void Initialize()
    {
        land1pool?.Initialize();
        land2pool?.Initialize();
        land3pool?.Initialize();
        land4pool?.Initialize();
       
    }

    public GameObject GetObject(TrackType type)
    {
        GameObject result = null;
        switch (type)
        {
            case TrackType.Land1:
                result = GetLand1().gameObject;
                break;
            case TrackType.Land2:
                result = GetLand2().gameObject;
                break;
            case TrackType.Land3:
                result = GetLand3().gameObject;
                break;
            case TrackType.Land4:
                result = GetLand4().gameObject;
                break;
        }
        return result;
    }


    public Land1 GetLand1() => land1pool?.GetObject();
    public Land2 GetLand2() => land2pool?.GetObject();
    public Land3 GetLand3() => land3pool?.GetObject();
    public Land4 GetLand4() => land4pool?.GetObject();

}
