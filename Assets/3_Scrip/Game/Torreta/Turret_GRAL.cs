using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Turret_GRAL : MonoBehaviour
{
    public event Action<Turret_GRAL> OnShoot;
    public event Action<Turret_GRAL> OnDeath;

    [SerializeField] private float life;
    [SerializeField] private float damage;
    [SerializeField] private float shootInterval;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    private float lastShootTime;

    private void Start()
    {
        lastShootTime = Time.time;
    }

    private void Update()
    {
        if (Time.time > lastShootTime + shootInterval)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }
    public void ReceiveDamage(float damageTaken)
    {
        life -= damageTaken;
        if (life <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDeath?.Invoke(this);
        Destroy(gameObject);
    }

   

    private void Shoot()
    {
GameObject bulletInstance = ObjectPool.Instance.Spawn(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Bullet bullet = bulletInstance.GetComponent<Bullet>();
        bullet.Init(damage);
        OnShoot?.Invoke(this);
    }
}

public class Bullet : MonoBehaviour
{
    private float damage;

    public void Init(float bulletDamage)
    {
        damage = bulletDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        Zombie zombie = other.GetComponent<Zombie>();
        if (zombie != null)
        {
            zombie.ReceiveDamage(damage);
        }
        
    }
}

