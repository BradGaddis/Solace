using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [TextArea]
    [SerializeField]
    private string test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Looking through the documentation, I found a few things that I just want to try out

    [ContextMenu("Do Something")]
    void DoSomething()
    {
        Debug.Log(test);
    }
}
