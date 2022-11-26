using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrolingBG : MonoBehaviour
{
    [SerializeField] float scrollSpeed;

    [SerializeField] private Renderer bgRenderer;


    // Update is called once per frame
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0);
    }
}
