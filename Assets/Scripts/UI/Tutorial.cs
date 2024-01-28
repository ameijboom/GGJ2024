using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destruct());
    }


    IEnumerator destruct()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("waited");
        Destroy(gameObject);
        
    }

}
