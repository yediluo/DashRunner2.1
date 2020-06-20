using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{

    [SerializeField] float lastTime;
    private void Start()
    {
        Invoke("selfDestory", lastTime);

    }
    private void selfDestory()
    {
        Destroy(gameObject);
    }

}
