using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollisionDetection : MonoBehaviour
{
    protected Animator animator;
    protected Dictionary<string, string> animationDictionary;

    void Start()
    {
        // gameObject.name �� �I�u�W�F�N�g���擾����
        GameObject gameObject = GetGameObject();

        // �I�u�W�F�N�g����animator���擾����
        animator = gameObject.GetComponent<Animator>();

        // �Փˎ��̃A�N�V�������`���鎫��������������
        animationDictionary = GetAnimationDictionary();
    }

    protected virtual GameObject GetGameObject()
    {
        return gameObject;
    }

    protected virtual Dictionary<string, string> GetAnimationDictionary()
    {
        return new Dictionary<string, string>();
    }

    /// <summary>
    ///  �Q�[���I�u�W�F�N�g���m���ڐG�����^�C�~���O�Ŏ��s
    /// </summary>
    public void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g�̖��O���擾
        string collisionObjectName = collision.gameObject.name;
        HandleCollision(collisionObjectName);
    }

    /// <summary>
    /// �Փ˂����I�u�W�F�N�g�̖��O�����ɃA�j���[�V���������s����
    /// </summary>
    private void HandleCollision(string collisionObjectName)
    {
        if (animationDictionary.ContainsKey(collisionObjectName))
        {
            bool IsAnimation = animator.GetBool(animationDictionary[collisionObjectName]);
            animator.SetBool(animationDictionary[collisionObjectName], !IsAnimation);
        }
    }
}
