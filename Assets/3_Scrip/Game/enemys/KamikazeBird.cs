using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeBird : MonoBehaviour
{
    public GameObject target;
    public float circleRadius=5f;
    public float circuleSpeed = 1.6f;
    public float diveSpeed = 10f;
    public float delayBeforeSpawn = 10f;

    private float timer = 0f;
    private bool weary = true;
    private Vector3 initialPosition;

    private void Start()
    {
        float positionX = Random.Range(-27f,12f);
        float positionZ = Random.Range(-29f, 1f);

        initialPosition = new Vector3(positionX, 14f, positionZ);
        SpawnKamikaze();

    }

    private void Update()
    {
        if (weary)
        {
            timer += Time.deltaTime;

            float angle = timer * circuleSpeed;
            float x = Mathf.Sin(angle) * circleRadius;
            float z = Mathf.Cos(angle) * circleRadius;
            transform.position = new Vector3(x, initialPosition.y, z);

         
            if (timer>= 5f)
            {
                weary = false;
                timer = 0;

            }
        }
        else
        {
            if (target !=null)
            {
                Vector3 direction = target.transform.position - transform.position;
                transform.Translate(direction.normalized * diveSpeed * Time.deltaTime);

                if (Vector3.Distance (transform.position, target.transform.position)<0.5f)
                {
                    Destroy(target);
                    Destroy(gameObject);
                    Invoke("SpawnBird", delayBeforeSpawn);
                }

            }
        }
    }

    void SpawnKamikaze()
    {
        GameObject newKamikaze = Instantiate(gameObject, initialPosition, Quaternion.identity);
        newKamikaze.SetActive(true);
        newKamikaze.GetComponent<KamikazeBird>().target = target;
    }
}
