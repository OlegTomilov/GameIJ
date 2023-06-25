using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Card _card;
    private Vilage _vilage;
    private GameObject _draggingBuilding;
    private Building _building;
    private Vector2Int _gridSize = new Vector2Int(1000, 1000);

    private bool _isAvailableToBuild;
    private float maxDistantionX = 350f;
    private float maxDistantionZ = 200f;
    private float minDistantionX = 120F;
    private float minDistantionZ = 50f;

    private Building[,] _grid;

    private void Awake()
    {
        _grid = new Building[_gridSize.x, _gridSize.y];
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(_draggingBuilding != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);
                int xPosition = Mathf.RoundToInt(worldPosition.x);
                int zPosition = Mathf.RoundToInt(worldPosition.z);

                if (xPosition < maxDistantionX && xPosition > minDistantionX 
                    && zPosition < maxDistantionZ && zPosition > minDistantionZ)
                    _isAvailableToBuild = true;
                else 
                    _isAvailableToBuild = false;

                _draggingBuilding.transform.position = new Vector3(xPosition, 0, zPosition);
                _building.SetColor(_isAvailableToBuild);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _draggingBuilding = Instantiate(_card.GetPrefab(), Vector3.zero, Quaternion.identity);
        _building = _draggingBuilding.GetComponent<Building>();

        var groundPlane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(groundPlane.Raycast(ray, out float position))
        {
            Vector3 worldPosition = ray.GetPoint(position);
            int xPosition = Mathf.RoundToInt(worldPosition.x);
            int zPosition = Mathf.RoundToInt(worldPosition.z);

            _draggingBuilding.transform.position = new Vector3(xPosition, 0, zPosition);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!_isAvailableToBuild || !_vilage.IsEnoughMoney(_card.Cost))
        {
            Destroy(_draggingBuilding);
            _vilage.PlayAnimation();
        }
        else
        {
            _grid[(int)_draggingBuilding.transform.position.x, 
                (int)_draggingBuilding.transform.position.z] = _building;
            _draggingBuilding.GetComponent<Collider>().enabled = true;
            _building.ResetColor();
            _vilage.BuyTower(_card.Cost);
        }
    }
    
    public void TransferObjects(Card card, Vilage vilage)
    {
        _card = card;
        _vilage = vilage;
    }
}
