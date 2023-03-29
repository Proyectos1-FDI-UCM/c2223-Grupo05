using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorComponent : MonoBehaviour
{
    [Header("INDEX")]
    [SerializeField]
    private int _myIndex;
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<InputComponent>() && Input.GetKeyDown(KeyCode.E))
        {
            CambiarNivel(_myIndex);
        }
    }
    public void CambiarNivel(int _index)
    {
        SceneManager.LoadScene(_index);
        GameManager.Instance.Featherslvl2();
    }
}
