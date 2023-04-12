using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeComponent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((bool)collision.gameObject.GetComponent<InputComponent>())
        {
            SoundComponent.Instance.PlaySound(SoundComponent.Instance._pickItem);
            GameManager.Instance.AddLife();
            Destroy(gameObject);

        }
    }
}
