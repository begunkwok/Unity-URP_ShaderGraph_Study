using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRayController : MonoBehaviour
{
    public LayerMask defaultLayer;
    public LayerMask xRayLayer;
    private bool XRayActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(XRayActive)
            {
                XRayActive=!XRayActive;
                int layerNum=(int)Mathf.Log(defaultLayer.value,2);
                gameObject.layer=layerNum;
                if(transform.childCount>0)
                {
                    SetChildrenLayer(transform,layerNum);
                }
            }
            else
            {
                XRayActive=!XRayActive;
                int layerNum=(int)Mathf.Log(xRayLayer.value,2);
                gameObject.layer=layerNum;
                if(transform.childCount>0)
                    SetChildrenLayer(transform,layerNum);
            }
        }
    }

    public void SetChildrenLayer(Transform root,int layer)
    {
        var children=root.GetComponentsInChildren<Transform>(includeInactive:true);
        foreach(var child in children)
        {
            child.gameObject.layer=layer;
        }
    }
}
