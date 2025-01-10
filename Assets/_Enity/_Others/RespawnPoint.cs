using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnPoint : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject reloadWhenDie;
    public Players_ScriptableObject PlayerData;

    void Update()
    {
        if (PlayerData.isDead)
        {
            player.SetActive(false);
            reloadWhenDie.SetActive(true);
            StartCoroutine(ReLoadScene_Coroutine());
            PlayerData.isDead = false;
            player.transform.position = this.transform.position;
            player.SetActive(true);
        }
    }
    public IEnumerator ReLoadScene_Coroutine()
    {
        int i = 0;
        while (i + 1 < 2)
        {
            i++;
            yield return new WaitForSeconds(1f);
        }
        reloadWhenDie.SetActive(false);
    }
}
