using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    [SerializeField] Vilage _target;
    [SerializeField] SoundEffector _soundEffector;

    private List<Enemy> _pool = new List<Enemy>();

    protected void Initialize(Enemy clone)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Enemy spawned = Instantiate(clone, clone.transform.position, Quaternion.identity);
            spawned.SendTarget(_target, _soundEffector);
            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out Enemy result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }
}
