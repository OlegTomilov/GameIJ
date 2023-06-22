using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
    [SerializeField] Card _card;
    private float _delayTime = 1;
    private float _timer;

    public event UnityAction Destroyed;

    private void OnCollisionStay(Collision collision)
    {
        _timer += Time.deltaTime;

        if (_delayTime < _timer)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(_card.Damage);
            Destroyed.Invoke();
            _timer = 0;
        }
    }
}
