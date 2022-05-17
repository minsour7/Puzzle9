using Google.Protobuf.Protocol;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerShootReady : PlayerShootReady
{

   // Player Player;

    float currentDeltaTime = 0.0f;
    bool bMousePress = false;
    public MyPlayerShootReady(PlayerStateManager state_manager) : base(state_manager)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        //Player = GetPlayer();
        ((MyPlayer)Player).Next.GetComponent<Next>().SetVisible(true);
        ((MyPlayer)Player).Next.GetComponent<Next>().UpdateNext();

        //currentDeltaTime = Time.deltaTime;
    }


    protected override void Init()
    {
        base.Init();

        bMousePress = false;
    }

    protected override void Shoot(float scale = 1.0f)
    {
        Bubble.transform.position = ShootBody.transform.position;
        float fAngle = CMath.GetAngle(ShootBody.transform.position, Target.transform.position);
        float RadianAngle = fAngle * Mathf.Deg2Rad;
        Vector2 vel = (new Vector2(Mathf.Cos(RadianAngle), Mathf.Sin(RadianAngle))).normalized * (Defines.G_SHOOT_FORCE * scale);
        RbBubble.velocity = vel;

        C_Shoot packet = new C_Shoot()
        {
            RadianAngle = RadianAngle
        };
        AppManager.Instance.NetworkManager.Send(packet);

        //Debug.Log("Shoot f : " + fAngle + " R : " + fAngle * Mathf.Deg2Rad);
    }

    bool HitChecker(out Vector3 HitPoint)
    {
        HitPoint = new Vector3();


        Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Ray2D ray = new Ray2D(wp, Vector2.zero);

        RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);

        foreach(RaycastHit2D hit in hits)
        {
            if (hit.collider.name.Equals("GameArea"))
            {
                HitPoint = hit.point;
                return true;
            }
        }

        //if(hit.collider != null)
        //{
        //    if (hit.collider.name.Equals("GameArea"))
        //    {
        //        HitPoint = hit.point;
        //        return true;
        //    }
        //}

        



        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        //RaycastHit[] Hits = Physics.RaycastAll(ray, Mathf.Infinity);
        //for (int i = 0; i < Hits.Length; i++)
        //{
        //    if (Hits[i].collider.name.Equals("GameArea"))
        //    {
        //        HitPoint = Hits[i].point;
        //        Debug.Log("In Aera");
        //        return true;
        //    }
        //}
        return false;
    }
   

    public override void OnUpdate()
    {
        base.OnUpdate();


        if (Input.GetMouseButton(0))
        {

            Vector3 curPosition;
            if (HitChecker(out curPosition))
            {
                bMousePress = true;
            }
            else
            {
                //Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                return;
            }

            bMousePress = true;


            curPosition.z = 0.0f;

            Pick pick = Player.Pick.GetComponent<Pick>();
            pick.RePlaceLimitPosition(ref curPosition);
            Target.transform.position = curPosition;
            //Target.transform.localPosition = curPosition;

            //bMousePress = true;

            //Vector3 wPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //wPos.z = 0;
            //Target.transform.position = wPos;

            //float dis = Util.Distance(Target.transform.position, ShootBody.transform.position);
            //float angle = CMath.GetAngle(Target.transform.position, ShootBody.transform.position);

            currentDeltaTime += Time.deltaTime;

            if (currentDeltaTime >= (1.0f/4.0f) )
            {

                //Debug.Log($"currentDeltaTime : {currentDeltaTime}");

                currentDeltaTime = 0;

                C_Move cmove = new C_Move()
                {
                    PosX = Target.transform.localPosition.x,
                    PosY = Target.transform.localPosition.y
                };

                AppManager.Instance.NetworkManager.Send(cmove);

            }

            

            //Time.deltaTime
            //Debug.Log(" Dis : " + dis + " Angle : " + angle);
        }
        else
        {
            if (bMousePress)
            {
                GetPlayer().SetPlayerState(PlayerStateManager.E_PLAYER_STATE.RUN);
//                GameManager.Instance.GetGameStateManager().SetGameState(GameStateManager.E_GAME_STATE.RUN);
                Shoot(
                    GetPlayer().LocalScale
                    );
            }

            bMousePress = false;
        }
    }
}
