using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCat : MonoBehaviour
{
    public List<MoveItem> moveInfo = new List<MoveItem>();
    public int moveIndex = 0 ;
    public Transform TargetTrans = null;
    public int TargetSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        if(moveInfo.Count>0)
        {
            TargetTrans = moveInfo[0].transform;
            TargetSpeed = moveInfo[0].moveSpeed;
        }
    }
    void Move()
    {
        var direction = TargetTrans.position - transform.position;//目标方向
        transform.Translate(direction.normalized * Time.deltaTime * 0.5f *TargetSpeed, Space.World);//向目标方向移动，normalized归一实现匀速移动

        //angle 0-90度正向，90-180度北向
        var angle = Vector3.Angle(transform.forward, direction);//获取夹角
                                                                //或者可以通过点乘获取夹角
                                                                //var deg = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(transform.forward.normalized, direction.normalized));
                                                                //由于y轴是朝上的，根据叉乘的y值判断目标在左方还是右方，小于0左方，大于0右方
        var cross = Vector3.Cross(transform.forward, direction);

        var turn = cross.y >= 0 ? 1f : -1f;
        transform.Rotate(transform.up, angle * Time.deltaTime * 5f * turn, Space.World);

    }
    bool isNearst(Vector3 a,Vector3 b)
    {
        if(Mathf.Abs(a.x-b.x)<0.1 && Mathf.Abs(a.y - b.y) < 0.1 && Mathf.Abs(a.z - b.z) < 0.1 )
        {
            return true;
        }

            return false;
    }
    // Update is called once per frame
    void Update()
    {
        if (moveInfo.Count > moveIndex)
        {
            if (isNearst (moveInfo[moveIndex].routeTrans.position, gameObject.transform.position))
            {
                moveIndex++;
                if (moveInfo.Count > moveIndex)
                {
                    TargetTrans = moveInfo[moveIndex].transform;
                    TargetSpeed = moveInfo[moveIndex].moveSpeed;
                }
            }
            else
            {
                Move();
            }
        }
    }
}
