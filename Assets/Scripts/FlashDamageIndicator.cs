using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashDamageIndicator : MonoBehaviour
{
    [SerializeField] private Material material;

    private Color defaultColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        material.color = defaultColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Flash() 
    {
        StartCoroutine(FlashDamage());

    }

    IEnumerator FlashDamage()
    {
        material.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        material.color = defaultColor;
    }
}
