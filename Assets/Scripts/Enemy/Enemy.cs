using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _dropBlood;
    [SerializeField] private float _damage;
    [SerializeField] private Attack _attack;

    public event UnityAction StartAttack;
    public event UnityAction Died;
    public event UnityAction<float> StoppedMove;

    public float Damage => _damage;

    private void OnMouseDown()
    {
        _dropBlood.SetActive(true);
        Died.Invoke();
        StoppedMove.Invoke(0);
        StartCoroutine(Death());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Frame"))
        {
            StartAttack.Invoke();
            StoppedMove.Invoke(0);
            _attack.enabled = true;
        }
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    private void OnEnable ()
    {
        _dropBlood.SetActive(false);
        _attack.enabled = false;
    }

    private void OnDisable()
    {
        StopCoroutine(Death());
    }
}
