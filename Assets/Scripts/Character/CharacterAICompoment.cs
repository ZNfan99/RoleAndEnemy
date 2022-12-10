using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ڽ�ɫ���ϵĶ����������
/// </summary>
public class CharacterAICompoment : MonoBehaviour
{
    Animator m_Animator;
    bool m_Running = false;
    float timer = 0;
    public ICharacter m_Character;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Running)
        {
            timer += Time.deltaTime;
            if(timer >= 1.5f)
            {
                timer = 0f;
                m_Running = false;
                //Debug.Log("�������");
                Notification no = new Notification();
                no.msg = EventOrder.ATTACKFINISHED;
                no.data = new object[] { m_Character };
                MessageCenterByObserver.Instance().NotifyObserver(EventOrder.ATTACKFINISHED, no);
            }
        }
    }

    public void PlayAttackAnim(ICharacter character)
    {
        m_Character = character;
        m_Animator.SetTrigger("Attack");
        m_Running = true;
    }

    public void PlayHurtAnim()
    {
        m_Animator.SetTrigger("Hurt");
        //m_Running = true;
    }
}
