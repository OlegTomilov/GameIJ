using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingEffect : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _lightingEffect;

    private Ray _ray;
    private RaycastHit _raycastHit;
    private float _distantionAxisZ = 60;
    private float _lengthOfRay = 500;

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

            if(Physics.Raycast(_ray, out _raycastHit, _lengthOfRay))
            {
                if (true)
                {
                    var pointOfInstantiate = _raycastHit.point + new Vector3(0, _distantionAxisZ, 0);
                    SetEffect(_lightingEffect, pointOfInstantiate);
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
        yield return new WaitForSeconds(0.3f);
        effect.SetActive(false);
    }
}
