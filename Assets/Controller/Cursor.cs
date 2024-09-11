using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private Vector3 _screenPosition; 
    private Vector3 _worldPosition;
    RaycastHit hit = new RaycastHit();

    // Update is called once per frame
    void Update()
    {
        _screenPosition = Input.mousePosition;
        Ray ray = _camera.ScreenPointToRay(_screenPosition);

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);

        if (Physics.Raycast(ray, out hit, 1000)) 
        {
            _worldPosition = hit.point;
        }
        transform.position = _worldPosition; 
    }
}
