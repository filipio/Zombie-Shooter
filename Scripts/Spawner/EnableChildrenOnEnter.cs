using UnityEngine;

public class EnableChildrenOnEnter : MonoBehaviour
{
    private void Awake()
    {
        
        ToggleChildren(false);
    }

    private void ToggleChildren(bool state)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(state);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ToggleChildren(true);
    }

    private void OnValidate()
    {
        Collider collider = GetComponent<Collider>();
        if(collider == null)
        {
            collider = gameObject.AddComponent<SphereCollider>();
            ((SphereCollider)collider).radius = 15f;
        }
        collider.isTrigger = true;
    }
}
