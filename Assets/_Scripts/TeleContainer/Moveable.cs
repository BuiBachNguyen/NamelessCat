using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : Telepoints
{
    [SerializeField] TeleportManager teleportManager;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        CheckPlayerPosition();
    }

    public override void TeleHandle()
    {
        teleportManager.isInner = true;
        teleportManager.isTeleporting = true;
        teleportManager.DisablePlayer();
        player.transform.position = this.transform.position + new Vector3(0, 0, -1);
        return;
    }
}
