using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scrolling : MonoBehaviour
{
    [SerializeField] private RawImage _img;
    public float _x = 0.01f;
    public float _y = 0f;
    void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img.uvRect.size);
    }
}
