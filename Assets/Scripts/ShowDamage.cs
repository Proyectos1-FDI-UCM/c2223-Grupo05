using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ShowDamage : MonoBehaviour
{
    [SerializeField] private float _timeOfDamage; //tiempo que se muestra el enemigo en rojo para saber que se ha hehco daño
                                                  //Optimo ponerlo a 0.2

    public IEnumerator ModSprite(GameObject whatever)
    {
        whatever.GetComponent<SpriteRenderer>().color = Color.red;
        Debug.Log(whatever.name);

        yield return new WaitForSeconds(_timeOfDamage);

        whatever.GetComponent<SpriteRenderer>().color = Color.white;

    }

}
