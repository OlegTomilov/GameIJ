using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingEffect : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _lightingEffect;
    [SerializeField] private Coin _coin;
    [SerializeField] private Vilage _vilage;
    [SerializeField] private SoundEffector _soundEffector;

    private Ray _ray;
    private RaycastHit _raycastHit;
    private float _distantionAxisZ = 60;
    private float _lengthOfRay = 500;
    private float _timeDelayOfEffect = 0.3f;

    private void Start()
    {
        _camera = Camera.main;
        _lightingEffect.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _raycastHit, _lengthOfRay))
            {
                if (_raycastHit.collider.GetComponent<Enemy>())
                {
                    var pointOfInstantiate = _raycastHit.point + new Vector3(0, _distantionAxisZ, 0);
                    SetEffect(_lightingEffect, pointOfInstantiate);
                    _soundEffector.PlayLightClip();
                }

                if (_raycastHit.collider.GetComponent<Coin>())
                {
                    _vilage.TakeReward();
                    _soundEffector.PlayCoinClip();
                }
            }
        }
    }

    private void SetEffect(GameObject effect, Vector3 point)
    {
        effect.SetActive(true);
        effect.transform.position = point;
        StartCoroutine(DestroyEffect(effect));
    }

    private IEnumerator DestroyEffect(GameObject effect)
    {
        yield return new WaitForSeconds(_timeDelayOfEffect);
        effect.SetActive(false);
    }
}
