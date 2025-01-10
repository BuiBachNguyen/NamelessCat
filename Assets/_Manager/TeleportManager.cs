using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class TeleportManager : MonoBehaviour
{
    [SerializeField] List<Telepoints> telePoints = new List<Telepoints>();
    [SerializeField] GameObject player;
    [SerializeField] GameObject arrow;
    [SerializeField] float cd = 0.25f;
    [SerializeField] bool canGetOut;

    public bool isTeleporting;
    public bool isInner;
    public bool jumpClick;
    public bool specialClick;

    float rangeToTeleport = 6.5f;
    // Start is called before the first frame update
    void Start()
    {
        isTeleporting = false;
        isInner = false;
        canGetOut = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckTeleportStatus();
        ReRenderTelepoint();
        Teleport();
        ShowArrow();
    }

    public void CheckTeleportStatus()
    {
        //CD teleport
        if (cd >= 0 && isTeleporting && !canGetOut)
            cd -= Time.deltaTime;
        if (cd < 0)
        {
            canGetOut = true;
        }
    }

    public void EnablePlayer()
    {
        if (!player.activeSelf)  // Check player status
        {
            player.SetActive(true);
        }
    }

    // Hàm để disable player
    public void DisablePlayer()
    {
        if (player.activeSelf)  // Check player status
        {
            player.SetActive(false);
        }
    }


    private float nearest, secondNearest;
    private int flagN, flagSN;

    public void ReRenderTelepoint()
    {

        if (telePoints.Count <= 0) return;

        flagN = 0;
        nearest = Vector3.Distance(telePoints[flagN].transform.position, player.transform.position);
        //Find the nearest telePoint
        for (int i = 1; i < telePoints.Count; i++)
        {
            if (Vector3.Distance(telePoints[i].transform.position, player.transform.position) < nearest)
            {
                nearest = Vector3.Distance(telePoints[i].transform.position, player.transform.position);
                flagN = i;
            }
        }
        flagSN = (flagN != 0) ? 0 : 1;
        if (telePoints.Count >= 2)
        {
            secondNearest = Vector3.Distance(telePoints[flagSN].transform.position, player.transform.position);
            //Find the second nearest telePoint
            for (int i = 0; i < telePoints.Count; i++)
            {
                if (Vector3.Distance(telePoints[i].transform.position, player.transform.position) < secondNearest && i != flagN)
                {
                    secondNearest = Vector3.Distance(telePoints[i].transform.position, player.transform.position);
                    flagSN = i;
                }
            }
        }
    }

    public void Teleport()
    {
        if (telePoints.Count <= 0) return;
        //Move to selected point when get key 
        if (Input.GetKeyDown(KeyCode.Space) || specialClick)
        {
            canGetOut = false;
            specialClick = false;
            if (!isInner)
            {
                if (nearest < rangeToTeleport)
                {
                    telePoints[flagN].TeleHandle();
                }
            }
            else if(secondNearest < rangeToTeleport) 
            {
                telePoints[flagSN].TeleHandle();
            }
        }
        //Get out 
        if (canGetOut && (Input.GetKeyDown(KeyCode.UpArrow) || jumpClick) && isInner)
        {
            isTeleporting = false;
            isInner = false;
            player.transform.position += Vector3.up;
            EnablePlayer();
            cd = 0.25f;
        }
        jumpClick = false;
    }

    void ShowArrow()
    {
        if(telePoints.Count <= 0) return;
        if(nearest >= rangeToTeleport) { arrow.SetActive(false); }
        if(nearest <= rangeToTeleport)
        {
            if (!isInner)
            {
                arrow.transform.position = telePoints[flagN].transform.position + new Vector3(0,1f,0);
                arrow.SetActive(true);
            }
            else if(secondNearest <= rangeToTeleport)
            {
                arrow.transform.position = telePoints[flagSN].transform.position + new Vector3(0, 1f, 0);
                arrow.SetActive(true);
            }
        }
    }


    public void OnClickSButton()
    {
        specialClick = true;
    }
    public void OnClickJButton()
    {
        jumpClick = true;
    }
}
