using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve2DTest : MonoBehaviour
{
    public GameObject Player;
    bool isAdd=true;
    Material mat;

    float fadeNum=1;
    // Start is called before the first frame update
    void Start()
    {
        mat=Player.GetComponent<SpriteRenderer>().material;
        mat.SetFloat("_Fade",fadeNum);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(isAdd)
            {
                isAdd=false;
            }
            else
            {
                isAdd=true;
            }
        }
        if(isAdd)
        {
            fadeNum+=Time.deltaTime;
            if(fadeNum<=1)
                mat.SetFloat("_Fade",fadeNum);
            else
                fadeNum=1;
        }
        else
        {
            fadeNum-=Time.deltaTime;
            if(fadeNum>=0)
                mat.SetFloat("_Fade",fadeNum);
            else
                fadeNum=0;
        }
    }
}
