using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private GameObject _goal;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private Spawner _spawner;

    [SerializeField] private float _maxSpeed;
    private float _speed;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _goal.transform.position, _speed * Time.deltaTime);
        Vector3 adjustedPosition = new Vector3(_goal.transform.position.x, transform.position.y, _goal.transform.position.z);

        if(_speed > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(adjustedPosition - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _speed * Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        _speed = _maxSpeed;
        _rigidBody.freezeRotation = false;
        _enemy.StoppedMove += StopMove;
    }

    private void OnDisable()
    {
        _enemy.StoppedMove -= StopMove;
    }

    private void StopMove(float speed)
    {
        _speed = speed;
        _rigidBody.freezeRotation = true;
    }

}
