using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private int _scorePoint;
    [SerializeField] private GameObject _dropBlood;
    [SerializeField] private Attack _attack;
    [SerializeField] private EnemyHealth _enemyHealth;

    public event UnityAction StartAttack;
    public event UnityAction Died;
    public event UnityAction<float> StoppedMove;
    public event UnityAction DecreasedHP;

    public Vilage Target { get; private set; }
    public SoundEffector SoundEffector { get; private set; }


    private void OnMouseDown()
    {
        DecreasedHP.Invoke();
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
        Target.IncreaseScore(_scorePoint);
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    private void OnEnable ()
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
        _enemyHealth.Died += DeathEffect;
        _dropBlood.SetActive(false);
        _attack.enabled = false;
    }

    private void OnDisable()
    {
        _enemyHealth.Died -= DeathEffect;
        StopCoroutine(Death());
    }

    public void SendTarget(Vilage target, SoundEffector soundEffector) 
    {
        Target = target;
        SoundEffector = soundEffector;
    }

    private void DeathEffect()
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        StartCoroutine(Death());
        StoppedMove.Invoke(0);
        Died.Invoke();
        _dropBlood.SetActive(true);
    }
}
