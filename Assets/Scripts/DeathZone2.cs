using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone2 : MonoBehaviour
{
    public MainManager2 Manager;

    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        Manager.GameOver();
    }
}
