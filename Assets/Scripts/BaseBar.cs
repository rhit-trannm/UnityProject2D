using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Image fill;

    private float temp = 1f;
    void Start()
    {
        SetSize(1f);

    }
    public void SetSize(float size)
    {
        fill.fillAmount = size;
    }
}
