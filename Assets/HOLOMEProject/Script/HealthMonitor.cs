using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UniRx;

/// <summary>
/// �I�u�W�F�N�g�̏�Ԃ��Ď�����B
/// ����̎��ԑсi��F�������ԁj�ɑ΂��鏈�����s���B
/// </summary>
public class HealthMonitor : MonoBehaviour
{
    /// <summary>
    /// ��������(������)�̃g���K�[
    /// </summary>
    IDisposable p_MinuteTimeTrigger;

    // Start is called before the first frame update
    void Start()
    {
        // 1�����Ƀg���K�[�����s����
        p_MinuteTimeTrigger = UniRx.Observable
            .Timer(TimeSpan.FromSeconds(60.0f - DateTime.Now.Second), TimeSpan.FromMinutes(1.0f))
            .SubscribeOnMainThread()
            .Subscribe(x =>
            {
                ChangeOverTimeCondition(DateTime.Now);
            })
            .AddTo(this);
    }

    /// <summary>
    /// ���Ԍo�߂ɂ��R���f�B�V�����ω����Ǘ�����
    /// </summary>
    private void ChangeOverTimeCondition(DateTime a_DateTime)
    {
        Debug.Log("ChangeOverTimeCondition : " + a_DateTime.ToString());
        CheckSleepTime(a_DateTime);
    }

    /// <summary>
    /// �����������`�F�b�N����
    /// </summary>
    private void CheckSleepTime(DateTime a_DataTime)
    {
        int fromHour = 22;
        int limitHour = 6;
        TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
        TimeSpan startTime = new TimeSpan(fromHour, 0, 0);
        TimeSpan endTime = new TimeSpan(limitHour, 0, 0);

        // ���������͈͓̔����ǂ����𔻒肷��B
        if ((startTime <= timeOfDay) && (timeOfDay <= endTime))
        {
            // �͈͓��̏ꍇ�́A���������̏������s���B
        }
    }
}
