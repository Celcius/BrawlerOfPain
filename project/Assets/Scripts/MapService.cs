using UnityEngine;
using System.Collections;

public class MapService {



     protected MapService() { }

     private static MapService _instance = null;

     public GridElement[,] _elementMap;
     public MapGeneration _mapInfo;

     public static MapService instance
     {
         get {
             return _instance == null ? _instance = new MapService() : _instance;
     }
     }

     public void setMap(GridElement[,] map, MapGeneration mapInfo)
    {
        this._elementMap = map;
        this._mapInfo = mapInfo;
    }

    public void bloodElementsAtWorldPosition(float x, float y)
    {
        int xPos = (int)(x / _mapInfo.getMapScale());
        int yPos = (int)(y / _mapInfo.getMapScale());
        int spray = _mapInfo.getBloodSpray();

        int bloodStartX = Mathf.Max(0, xPos - spray);
        int bloodStartY = Mathf.Max(0, yPos - spray);
        int bloodEndX = Mathf.Min(_elementMap.GetLength(0), xPos + spray);
        int bloodEndY = Mathf.Min(_elementMap.GetLength(1), yPos + spray);

        for(int xVar = bloodStartX; xVar < bloodEndX; xVar ++)
            for(int yVar = bloodStartY; yVar < bloodEndY; yVar ++)
            {
                int deltaX = Mathf.Abs(xVar - xPos);
                int deltaY = Mathf.Abs(yVar - yPos);
                if(deltaX + deltaY <= spray)
                {
                    GridElement element = _elementMap[xVar, yVar];
                    if(element!= null)
                       element.fillBlood();
                }
            }
    }
    public void setMapElement(GridElement element, int x,int y)
    {
        if(_elementMap != null)
        {
            _elementMap[x, y] = element;
        }
    }
}
