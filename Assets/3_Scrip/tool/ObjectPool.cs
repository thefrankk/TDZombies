using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject[] prefabArray; // Arreglo de objetos que se van a guardar en el pool
    public int poolSize = 20;// Tamaño del pool para cada objeto

    private List<GameObject>[] objectPool;
    private Dictionary<string, int> inventory;
    private static ObjectPool instance;


    void Awake()
    {
        objectPool = new List<GameObject>[prefabArray.Length];

        for (int i = 0; i < prefabArray.Length; i++)
        {
            objectPool[i] = new List<GameObject>();
            for (int j = 0; j < poolSize; j++)
            {
                GameObject obj = Instantiate(prefabArray[i]);
                obj.SetActive(false);
                objectPool[i].Add(obj);
            }
        }

        inventory = new Dictionary<string, int>();
        inventory.Add("Normal", 20);
        inventory.Add("Iceberg", 0);
        inventory.Add("Fire", 0);

      
    }

    public GameObject GetObject(int index)
    {
        string bulletType = prefabArray[index].name;
        if (inventory[bulletType] > 0)
        {
            for (int i = 0; i < objectPool[index].Count; i++)
            {
                if (!objectPool[index][i].activeInHierarchy)
                {
                    inventory[bulletType]--;
                    return objectPool[index][i];
                }
            }
        }

        return null;
    }

    public void AddToInventory(string bulletType, int amount)
    {
        if (inventory.ContainsKey(bulletType))
        {
            inventory[bulletType] += amount;
        }
    }


    public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        // Buscar el índice del objeto en el arreglo de prefabs
        int index = System.Array.IndexOf(prefabArray, prefab);

        // Obtener un objeto de la pool correspondiente
        GameObject obj = GetObject(index);

        if (obj == null)
        {
            // Si no hay objetos disponibles en la pool, instanciar uno nuevo y agregarlo a la pool
            obj = Instantiate(prefab);
            objectPool[index].Add(obj);
        }

        // Configurar la posición y rotación del objeto y activarlo
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);

        return obj;
    }

    // Propiedad pública que devuelve la instancia única
    public static ObjectPool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ObjectPool>();
            }
            return instance;
        }
    }
}

