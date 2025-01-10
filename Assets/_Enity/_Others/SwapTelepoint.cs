using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapTelepoint : Telepoints
{
    GameObject temp;
    [SerializeField] TeleportManager teleportManager;
    void Start()
    {
        temp = GameObject.FindWithTag("Temp");
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        CheckPlayerPosition();
    }

    public override void TeleHandle()
    {
        if (teleportManager.isInner == true) return;
        teleportManager.DisablePlayer();
        temp.transform.position = this.transform.position;
        this.transform.position = player.transform.position;
        player.transform.position = temp.transform.position;
        teleportManager.EnablePlayer();
        return;
    }
}
