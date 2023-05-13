using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Bullet : MonoBehaviour
{
    private GameObject bullet;
    private float timer = 2f;
    private float timerCount = 0f;

    private int counter;
    private int maxcounter = 20;

     void Start()
    {
        StartCoroutine(FireBullet_CR());
    }

    private void Update()
    {
       /* timerCount += Time.deltaTime;
        if (timerCount> timer)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            timerCount = 0f;

        }*/
    }

    IEnumerator FireBullet_CR()
    {
        for (int i=0; i<maxcounter; i++)
        {
            counter++;
            Instantiate(bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(timer);
        }
    }
}
