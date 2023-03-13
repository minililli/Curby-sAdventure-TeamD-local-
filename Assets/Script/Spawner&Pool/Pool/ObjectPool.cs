using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : PoolObject
{
    public GameObject originalPrefab;
    public int poolSize = 32;
    T[] pool;
    Queue<T> readyQueue;


    public void Initialize()
    {
        pool = new T[poolSize];
        readyQueue = new Queue<T>(poolSize);
        // readyQueue.Count(); 큐가 실제 사용하는 갯수
        // readyQueue.Capacity(); 미리 만들어놓은 노드의 갯수
        GenerateObjects(0, poolSize, pool);
    }

    private void GenerateObjects(int start, int end, T[] newArray)
    {
        for (int i = start; i < end; i++)
        {
            GameObject obj = Instantiate(originalPrefab, transform);
            obj.gameObject.name = $"{originalPrefab.name}_{i}";
            T comp = obj.GetComponent<T>();

            comp.onDisable += () => readyQueue.Enqueue(comp);

            newArray[i] = comp;
            obj.SetActive(false);
        }
    }
    public T GetObject()
    {
        if (readyQueue.Count > 0)
        {
            T obj = readyQueue.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            ExpandPool();
            return GetObject();
        }
    }

    public T GetObject(Transform spawnTransform)
    {
        if(readyQueue.Count > 0)
        {
            T obj = readyQueue.Dequeue();
            obj.transform.position = spawnTransform.position;
            obj.transform.rotation = spawnTransform.rotation;
            obj.transform.localScale =spawnTransform.localScale;
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            ExpandPool();
            return GetObject();
        }
    }

    private void ExpandPool()
    {
        Debug.LogWarning($"{this.gameObject.name} 풀 사이즈 증가");
        int newSize = poolSize * 2;
        T[] newPool = new T[newSize];
        for(int i = 0; i < poolSize; i++)
        {
            newPool[i] = pool[i];
        }
        GenerateObjects(poolSize, newSize, newPool);
        pool = newPool;
        poolSize = newSize;
    }
}
