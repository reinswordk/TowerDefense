using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{

    private Tower _placedTower;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_placedTower != null && _placedTower.isPlaced && !_placedTower.gameObject.activeSelf) {
            _placedTower = null;
        }

        if (_placedTower == null)
        {
            Tower tower = collision.GetComponent<Tower>();
            if (tower != null)
            {
                tower.SetPlacePosition(transform.position);
                _placedTower = tower;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_placedTower == null) return;

        if (!_placedTower.isPlaced)
        {
            _placedTower.SetPlacePosition(null);
            _placedTower = null;
        }
    }
}
