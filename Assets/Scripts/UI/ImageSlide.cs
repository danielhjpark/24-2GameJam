using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSlide : MonoBehaviour
{
    [SerializeField] public Slider slider;

    private void Update()
    {
        if (slider.value <= 0)
            return;
        slider.value -= Time.deltaTime;
    }
}
