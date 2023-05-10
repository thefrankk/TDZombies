using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    public float radioExplosion = 5f;
    public float tiempoCongelacion = 3f;
    public GameObject bombPrefab;
    private GameObject currentBomb;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioExplosion);
    }

    void Explorar()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radioExplosion);

        foreach (Collider collider in colliders)
        {
            Zombie zombie = collider.GetComponent<Zombie>();
            if (zombie != null)
            {
                zombie.Frozen(tiempoCongelacion);
            }
        }
    }

    void SpawnBomb()
    {
        // Instanciar la bomba desde el prefab
        currentBomb = Instantiate(bombPrefab, transform.position, transform.rotation);
    }
    public void Detonar()
    {
        Explorar();
        Destroy(gameObject);
    }
}
