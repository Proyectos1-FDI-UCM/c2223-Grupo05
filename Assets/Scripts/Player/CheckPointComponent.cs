using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CheckPointComponent : MonoBehaviour
{
    private Light2D _light;
  
    [SerializeField] private float _intensityMax;
    

    private GameObject _particleSys;
    
    private void Start()
    {
        _particleSys = GetComponentInChildren<ParticleSystem>().gameObject ;
        _particleSys.SetActive(false);
        
        
        _light = GetComponentInChildren<Light2D>();
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((bool)collision.gameObject.GetComponent<InputComponent>())
        {
            GameManager.Instance.Checkpoint();
            //stablish new light settings
            _light.intensity = _intensityMax;
            

            //Activate particles
            _particleSys.SetActive(true);

        }
    }
}
