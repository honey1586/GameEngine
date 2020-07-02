using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Zombie : MonoBehaviour
{
    [SerializeField]
    private GameObject go_zombie;

    [SerializeField] private int hp;
    [SerializeField] private float walkSpeed;

    private Vector3 direction;

    // 상태변수
    private bool isAction;
    private bool isWalking;
    [SerializeField] private float walkTime;
    [SerializeField] private float waitTime;
    private float currentTime;

    //필요한 컴포넌트
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private BoxCollider boxCol;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = waitTime;
        isAction = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotation();
        ElapseTime();
    }
    private void Move()
    {
        if (isWalking)
            rigid.MovePosition(transform.position + (transform.forward * walkSpeed * Time.deltaTime));
    }
    private void Rotation()
    {
        if(isWalking)
        {
            Vector3 _rotation = Vector3.Lerp(transform.eulerAngles, direction, 0.01f);
            rigid.MoveRotation(Quaternion.Euler(_rotation));
        }
    }


    private void ElapseTime()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
            ReSet();

    }

    private void ReSet()
    {
        isWalking = false;
        isAction = true;
        anim.SetBool("Walking", isWalking);
        direction.Set(0f, Random.Range(0f, 360f), 0f);
        RandomAction();
    }

    private void RandomAction()
    {
        int _random = Random.Range(0, 2);

        if (_random == 0)
            Wait();
        else if (_random == 1)
            TryWalk();
    }

    private void Wait()
    {
        currentTime = waitTime;

    }
    private void TryWalk()
    {
        isWalking = true;
        anim.SetBool("Walking", isWalking);
        currentTime = walkTime;
  
    }

    public void Damage(int _damage)
    {
        if(hp > 0)
            hp -= _damage;

        if (hp <= 0)
        {
            anim.SetTrigger("Dead");
            Dead();
        }
    }

    private void Dead()
    {
        
        Destroy(go_zombie);
        Debug.Log("좀비 죽었음.");
    }
}
