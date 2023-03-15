using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CheckPointComponent : MonoBehaviour
{
    private Light2D _light;
  
    [SerializeField] private float _intensityMax;
    [SerializeField] private float _outerRatius;
    [SerializeField] private float _innerAngle;
    [SerializeField] private float _outerAngle;
    
    private void Start()
    {
        _light = GetComponentInChildren<Light2D>();
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((bool)collision.gameObject.GetComponent<InputComponent>())
        {
            GameManager.Instance.Checkpoint();
            _light.intensity = _intensityMax;
            _light.pointLightOuterRadius = _outerRatius;
            _light.pointLightInnerAngle = _innerAngle;
            _light.pointLightOuterAngle= _outerAngle;

        }
    }
}
