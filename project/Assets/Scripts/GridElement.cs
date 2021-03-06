﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridElement : MonoBehaviour {

    public const string FLOOR_CODE = "f";
    public const string HOLE_CODE = "o";
    public const string BRAZIER_CODE = "b";

    public bool _isBloodied = false;
    private float _bloodiedIntensity = 0;

    protected const float unityScale = 10.0f;

    protected int _gridPosX;
    protected int _gridPosY;

    public void setGridElement(int x, int y, float tileScale) 
    {
        _gridPosX = x;
        _gridPosY = y;
        this.gameObject.transform.position = new Vector3(_gridPosX * tileScale, 0, _gridPosY * tileScale);
        this.gameObject.transform.localScale = new Vector3(tileScale, 1, tileScale);
      //  this.gameObject.transform.localScale = new Vector3(1 / unityScale, 1 / unityScale, 1 / unityScale); // use this for planes
    }
	
    void Start()
    {

    }
	// Update is called once per frame
	void Update () {
	
	}

    public static GridElement createGridElement(string code, int x, int y, float tileScale)
    {
        if (FLOOR_CODE.CompareTo(code) == 0)
        {
            return createPlaneFloorGridElement(x , y, tileScale);
        }
        else if( HOLE_CODE.CompareTo(code)== 0)
        {
            return createHoleGridElement(x, y, tileScale);
        }
        else if (BRAZIER_CODE.CompareTo(code)==0)
        {
            return createBrazier(x, y, tileScale);
        }
        return null;
    }

    public virtual void fillBlood(float intensity)
    {
        _isBloodied = true;
        if (_bloodiedIntensity < intensity)
        {
            _bloodiedIntensity = intensity;
            renderer.material.SetFloat("_bloodBlend", Mathf.Clamp(_bloodiedIntensity,0,1));
        }
            
    }

    static GridElement createPlaneFloorGridElement(int x, int y, float tileScale)
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Cube);
        plane.AddComponent<GridElement>().setGridElement(x, y, tileScale);
        plane.tag = "MapBlock";
        int rand = Random.Range(0,12);
        if (rand < 10)
            plane.renderer.material = (Material)Resources.Load("Materials/Floor") as Material;
        else if (rand == 10)
        { 
            plane.renderer.material = (Material)Resources.Load("Materials/crackedFloor") as Material;
            int rotation = Random.Range(0,4) % 4;
            plane.transform.eulerAngles = new Vector3(plane.transform.localRotation.x, 90 * rotation, plane.transform.localRotation.z);
        }
        else
        {
          plane.renderer.material = (Material)Resources.Load("Materials/CircleFloor") as Material;
          plane.transform.eulerAngles = new Vector3(plane.transform.localRotation.x, -180, plane.transform.localRotation.z);
        }
        return plane.GetComponent<GridElement>();
    }

    static GridElement createBrazier(int x, int y, float tileScale)
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject brazier = Instantiate(Resources.Load("Prefabs/Brazier")) as GameObject;
        brazier.transform.parent = plane.transform;
        brazier.transform.position = new Vector3(0, 0.5f, 0.5f);
        plane.AddComponent<GridElement>().setGridElement(x, y, tileScale);
        plane.tag = "MapBlock";
      
        plane.renderer.material = (Material)Resources.Load("Materials/Floor") as Material;



        return plane.GetComponent<GridElement>();
    }

    static GridElement createHoleGridElement(int x, int y, float tileScale)
    {
        /*
        GameObject go = Instantiate(Resources.Load("Prefabs/HoleTile")) as GameObject;
        GridElement element = go.GetComponent<GridElement>();
        if(element != null)
        {
            element.setGridElement(x, y, tileScale);
        }
         return element;
         */
        return null;
    }

}

