using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsScene : MonoBehaviour
{
    void Update()
    {
        if(Input.anyKey)
        {
            FindObjectOfType<LevelLoader>().LoadNextScene();
        }
    }
}
