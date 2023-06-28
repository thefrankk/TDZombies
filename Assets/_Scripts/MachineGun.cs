using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MachineGun : MonoBehaviour, IInteractableReceiver, ICameraControllable
{
    [SerializeField] private NormalBullet _bullet;
    [SerializeField] private Transform _cameraPosition;
    [SerializeField] private Transform _firePoint;
    private float _fireRate = 0.1f;
    private float _damage = 1f;
    private float _fireRateCountdown = 0f;

    private Vector3 _basePosition;
    private Quaternion _baseRotation;

    [SerializeField] private LayerMask _layerMask;
    //Camera settings
    private float _minY = 0f;
    private float _maxY = 40f;

    private void Awake()
    {
        FindInteractableSender();
        _basePosition = this.transform.position;
        _baseRotation = this.transform.rotation;
    }

    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // if (_fireRateCountdown > 0) return;
            NormalBullet bullet = Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
            bullet.ApplyForce(_firePoint.transform.forward);

            if (Physics.Raycast(_firePoint.position, _firePoint.transform.forward, out RaycastHit hit, 1000f, _layerMask)) 
            {
                bullet.HitTarget(hit.transform);
            }
        }
    }

    private void Update()
    {
        if(CameraController.Instance.Target != this) return;

        Shoot();

        if (Input.GetKeyDown(KeyCode.E))
        {
            Player.Instance.transform.localScale = Vector3.one;
            CameraController.Instance.SetTarget(Player.Instance);
            this.transform.SetPositionAndRotation(_basePosition, _baseRotation);
        }

        
    }


    public int Id { get; }
    public void DoAction()
    {
        Debug.Log("ACTION");
        Player.Instance.transform.localScale = Vector3.zero;

       CameraController.Instance.SetTarget(this);
    }

   

    public void FindInteractableSender()
    {
        InteractableObject interactableObject = GetComponentInChildren<InteractableObject>();
        interactableObject.InjectDependencies(this);
        Debug.Log(interactableObject);
    }

    public void MoveCamera(CameraController cameraController, ref InputMovement inputMovement)
    {
        Vector3 targetPosition = _cameraPosition.transform.position - (_cameraPosition.transform.rotation * (Vector3.forward * 0.1f));
        cameraController.transform.position = Vector3.Slerp(cameraController.transform.position, targetPosition, Time.deltaTime * 20f);

        inputMovement.YAngle = Mathf.Clamp(inputMovement.YAngle, _minY, _maxY);
        var yAngle = Mathf.Clamp(inputMovement.YAngle, _minY, _maxY);
        cameraController.transform.rotation = Quaternion.Euler(yAngle, inputMovement.XAngle, this.transform.rotation.eulerAngles.z);
        this.transform.rotation = Quaternion.Euler(yAngle, inputMovement.XAngle, this.transform.rotation.eulerAngles.z);
        

    }
}
