using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRayLayerTest : MonoBehaviour
{
    public LayerMask currentLayer;
    public LayerMask targetLayer;

    public GameObject targetObj;

    bool isActive=false;

    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isActive)
            {
                isActive=false;
                SetChildrenLayer(targetObj.transform,targetLayer);
            }
            else
            {
                isActive=true;
                SetChildrenLayer(targetObj.transform,currentLayer);
            }
        }
    }
    void SetChildrenLayer(Transform target,LayerMask targetLayer)
    {
        var childrens=target.GetComponentsInChildren<Transform>();
        foreach(var childs in childrens)
        {
            childs.gameObject.layer=(int)Mathf.Log(targetLayer.value,2);
        }
    }
}
