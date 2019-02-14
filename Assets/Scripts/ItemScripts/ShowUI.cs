using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{
    [SerializeField] private GameObject customSprite;
    private GameObject objClone;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objClone = Instantiate(customSprite, other.transform.position + Vector3.up * 2, Quaternion.identity);
        }
    }
    void OnTriggerExit(Collider other)
    {
        Destroy(objClone);
        Destroy(gameObject);
    }
}