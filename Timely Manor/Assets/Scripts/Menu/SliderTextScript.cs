using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderTextScript : MonoBehaviour
{
    [SerializeField]
    Slider _slider;

    [SerializeField]
    TMP_InputField _inputField;

    // Start is called before the first frame update
    void Start()
    {
        // Everytime the slider change, set the text
        _slider.onValueChanged.AddListener((v) =>
        {
            _inputField.text = v.ToString("0.00");
        });
    }

    // Update is called once per frame
    void Update()
    {
        _inputField.onValueChanged.AddListener((v) =>
        {
            var valueFloat = float.Parse(v);
            if(valueFloat > 1)
            {
                // If the value set is above limit, reset the valuse to previous one.
                valueFloat = _slider.value;
                _inputField.text = _slider.value.ToString();
            }
            else 
            { 
                _slider.value = valueFloat;
            }
        });
    }
}
