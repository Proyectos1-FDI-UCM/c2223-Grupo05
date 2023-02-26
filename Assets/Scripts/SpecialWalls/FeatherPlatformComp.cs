using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEditor.U2D.Path;
using UnityEngine;

public class FeatherPlatformComp : MonoBehaviour
{
    [SerializeField] private GameObject _featherPlatform; //pluma plataforma
    [SerializeField] private Transform _spawnPos;         //posicion de instancia (TEMPORAL)
    [SerializeField] private GameObject _featherPrefab;   //pluma que se lanza

    //INsatncia plataforma de la pluma
    public void SetFeatherToWall(Vector2 spawnPos)
    {
        //Insertar animacion si eso

        Instantiate(_featherPlatform, spawnPos, Quaternion.identity);
    }

    //Elimina plataforma 
    public void RemovePlatform()
    {
        //Llamar a metodo dentro de plataforma para que se destruya
        Instantiate(_featherPrefab, _spawnPos.position, Quaternion.identity);

        _featherPrefab.GetComponent<FeatherComponent>().ActivateReturn();
    }
    
}
