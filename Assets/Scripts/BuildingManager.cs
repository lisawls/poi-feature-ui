using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
	public GameObject[] buildings;
	private GameObject pendingObject;
	
	private Vector3 pos;
	public float rotateAmount;
	
	private RaycastHit hit;
	[SerializeField] private LayerMask layerMask;

	public float gridSize;
	bool gridOn;
	[SerializeField] private Toggle gridToggle;

    // Update is called once per frame
    void Update()
    {
		if (pendingObject != null)
		{
			if (gridOn)
			{
				pendingObject.transform.position = new Vector3(
					RoundToNearestGrid(pos.x),
					RoundToNearestGrid(pos.y),
					RoundToNearestGrid(pos.z)
					);
			}
			else
			{
				pendingObject.transform.position = pos;
			}
			if (Input.GetMouseButtonDown(0))
			{
				PlaceObject();
			}
			if (Input.GetKeyDown(KeyCode.R))
            {
				RotateObject();
            }
		}
    }
	
	public void PlaceObject()
	{
		pendingObject = null;
	}

	public void RotateObject()
    {
		pendingObject.transform.Rotate(Vector3.up, rotateAmount);
    }
	
	private void FixedUpdate()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		if (Physics.Raycast(ray, out hit, 1000, layerMask))
		{
			pos = hit.point;
		}
	}
	
	public void SelectObject(int index)
	{
		pendingObject = Instantiate(buildings[index], pos, transform.rotation);
	}

	public void ToggleGrid()
    {
		if (gridToggle.isOn)
        {
			gridOn = true;
        }
		else
        {
			gridOn = false;
        }
    }

	float RoundToNearestGrid(float pos)
    {
		float xDiff = pos % gridSize;
		pos -= xDiff;
		if (xDiff > (gridSize / 2))
        {
			pos += gridSize;
        }
		return pos;
    }
}
