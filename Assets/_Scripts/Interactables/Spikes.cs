using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class Spikes : MonoBehaviour, IInteractableReceiver
{
    [SerializeField] private int _id;
    [SerializeField] private float _timeDuration;

    private float _currentTime;

    public float YPosStart { get => transform.position.y - 0.5f; }
    public float YPosEnd { get => transform.position.y + 0.5f; }
    
    public int Id => _id;

    public void DoAction()
    {
        StartCoroutine(startMove());
    }

    private IEnumerator startMove()
    {
        _currentTime = _timeDuration;
        StartCoroutine(smoothMoveCoroutine(new Vector3(this.transform.position.x, YPosEnd, this.transform.position.z), 0.5f));
        while (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
            yield return null;
        }

        StartCoroutine(smoothMoveCoroutine(new Vector3(this.transform.position.x, YPosStart, this.transform.position.z), 0.5f));
    }

    private IEnumerator smoothMoveCoroutine(Vector3 target, float duration)
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Slerp(startPosition, target, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
    }

    private void Awake()
    {
        FindInteractableSender();
    }
    public void FindInteractableSender()
    {
        InteractableObject interactableObject = FindObjectsOfType<InteractableObject>().FirstOrDefault(x => x.Id == Id);

        interactableObject.InjectDependencies(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Zombie>(out Zombie zombie))
        {
            Destroy(zombie.gameObject);
        }
    }
}
