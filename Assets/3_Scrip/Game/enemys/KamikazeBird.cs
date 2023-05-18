using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeBird : MonoBehaviour
{
    public GameObject target;
    public float circleRadius = 5f;
    public float circleSpeed = 2f;
    public float diveSpeed = 10f;
    public float delayBeforeSpawn = 10f;

    private float timer = 0f;
    private bool weary = true;
    private Vector3 initialPosition;
    private int numCircle = 0;
    private int maxCircle = 1;


    private void Start()
    {
        initialPosition = new Vector3(0f, 5f, 0f);
        MoveInCircle();
        
    Invoke("setTarget", 10);
    }

    private void setTarget()
    {
        target = FindObjectOfType<Turret_GRAL>()?.gameObject;
        if (target == null)
        {
            Invoke("setTarget", 10);
        }
    }

    void MoveInCircle()
    {
        weary = true;
        numCircle = 0;
    }


    private void Update()
    {
        if (weary)
        {

            float angle = Time.time * circleSpeed;
            float x = Mathf.Sin(angle) * circleRadius;
            float z = Mathf.Cos(angle) * circleRadius;
            transform.position = new Vector3(x, initialPosition.y, z);

            if (Mathf.Abs(angle) >= 2f * Mathf.PI)
            {
                numCircle++;

                if (numCircle >= maxCircle)
                {
                    weary = false;
                }
            }
        }
        else
        {
            if (target != null)
            {
                Vector3 direction = target.transform.position - transform.position;
                transform.Translate(direction.normalized * diveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, target.transform.position) < 0.5f)
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