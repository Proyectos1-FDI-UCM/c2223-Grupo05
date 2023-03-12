using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDamage : MonoBehaviour
{
    [SerializeField] private float _timeOfDamage; //tiempo que se muestra el enemigo en rojo para saber que se ha hehco daño

    public IEnumerator ModSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;

        yield return new WaitForSeconds(_timeOfDamage);

        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;

    }

}
