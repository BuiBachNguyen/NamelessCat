using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Telepoints : MonoBehaviour
{
    protected Animator anim;
    protected GameObject player;
    private float rangeToTeleport = 6.5f;

    public abstract void TeleHandle();
    public void CheckPlayerPosition()
    {
        if (player == null) return;
        if (Vector3.Distance(this.transform.position, player.transform.position) <= rangeToTeleport)
        {
            anim.SetBool("isChoosing", true);
        }
        else
        {
            anim.SetBool("isChoosing", false);
        }
    }


}
