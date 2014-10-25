using UnityEngine;
using System.Collections;

public class Shadow : MonoBehaviour {

    float maxHeight = 1.03f;
    float startY = 0.6f;
    float maxDelta = 5;
    [SerializeField]
    GameObject _parent;

    void Start()
    {
     
    }
    void Update()
    {
        float delta = _parent.transform.position.y - maxHeight;
        this.transform.position = new Vector3(transform.position.x, Mathf.Min(startY+delta, startY), transform.position.z);
        if (delta > 0)
        {
            float scale = 2 - delta/ (maxDelta);
        
            transform.localScale = new Vector3(scale, transform.localScale.y, scale);
                     
        }
    }
}
