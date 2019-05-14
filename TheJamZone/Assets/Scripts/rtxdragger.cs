using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rtxdragger : MonoBehaviour
{
    private bool clicked;
    private GameObject target;
    public Vector3 screen_space;
    public Vector3 offset;

    void Update()
    {
        // Debug.Log(_mouseState);
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hitInfo;
            target = GetClickedObject(out hitInfo);
            if (target != null)
            {
                clicked = true;
                screen_space = Camera.main.WorldToScreenPoint(target.transform.position);
                offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screen_space.z));
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            clicked = false;
        }
        if (clicked)
        {
            //keep track of the mouse position
            var mouse_screen_space = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screen_space.z);

            //convert the screen mouse position to world point and adjust with offset
            var mouse_pos = Camera.main.ScreenToWorldPoint(mouse_screen_space) + offset;

            //update the position of the object in the world
            target.transform.position = mouse_pos;
        }
    }


    GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }

        return target;
    }
}
   