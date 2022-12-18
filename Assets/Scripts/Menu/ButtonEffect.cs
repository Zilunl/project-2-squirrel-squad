using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEffect : MonoBehaviour
{
    [Header("Resize")]
    [SerializeField] Vector2 resizeRate = new Vector2(1.2f, 1.2f);
    [SerializeField] private Vector2 initialSize;

    // Start is called before the first frame update
    void Start()
    {
        initialSize = transform.localScale;
    }

    public virtual void SetSelection(bool state)
    {
        if (state)
        {
            transform.localScale = new Vector3(initialSize.x * resizeRate.x, initialSize.y * resizeRate.y, 1);
        }
        else
        {
            transform.localScale = new Vector3(initialSize.x, initialSize.y, 1);
        }
    }
}
