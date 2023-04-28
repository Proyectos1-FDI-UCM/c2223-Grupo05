using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBoss : MonoBehaviour
{
    private Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        _slider  = GetComponent<Slider>();
    }

    public void ChangeLifeMax(float _maxLife)
    {
        _slider.maxValue = _maxLife;
    }
    public void ChangeCurrentLife(float _currentLife)
    {
        _slider.value= _currentLife;
    }
    public void InitialLife(float _initialLife)
    {
        ChangeLifeMax(_initialLife);
        ChangeCurrentLife(_initialLife);
    }
}
