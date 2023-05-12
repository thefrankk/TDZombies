using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeBird : MonoBehaviour
{
    public GameObject target;
    public float circleRadius=5f;
    public float circuleSpeed = 2f;
    public float diveSpeed = 10f;
    public float delayBeforeSpawn = 10f;
   
    private float timer = 0f;
    private bool weary = true;
    private Vector3 initialPosition;

    private void Start()
    {
        int x = Random.Range(-22, 14);
        initialPosition = new Vector3(0f, 5f, 0f);
        MoveInCircle();

    }


    void MoveInCircle()
    {
        weary = true;
    }


private void Update()
    {
        if (weary)
        {
            
            float angle = Time.time * circuleSpeed;
            float x = Mathf.Sin(angle) * circleRadius;
            float z = Mathf.Cos(angle) * circleRadius;
            transform.position = new Vector3(x, initialPosition.y, z);
                     
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
