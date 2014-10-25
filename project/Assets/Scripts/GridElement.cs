using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridElement : MonoBehaviour {

    public const string FLOOR_CODE = "f";
    public const string HOLE_CODE = "o";

    public bool _isBloodied = false;

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
        return null;
    }

    public void fillBlood()
    {
        _isBloodied = true;
        transform.renderer.material = (Material)Resources.Load("Materials/blue_color") as Material;

    }

    static GridElement createPlaneFloorGridElement(int x, int y, float tileScale)
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Cube);
        plane.AddComponent<GridElement>().setGridElement(x, y, tileScale);
        plane.tag = "MapBlock";
        //plane.renderer.material = (Material)Resources.Load("Materials/Floor") as Material;
        return plane.GetComponent<GridElement>();
    }

    static GridElement createHoleGridElement(int x, int y, float tileScale)
    {
        return null;
    }

}

