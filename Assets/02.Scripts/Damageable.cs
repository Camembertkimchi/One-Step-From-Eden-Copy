using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Damageable : MonoBehaviour
{
    [SerializeField]ScriptableStatus status;
    [SerializeField]int barrier;
    
    [SerializeField]int frost;
    [SerializeField]int poison;
    [SerializeField]float fragilePercentage = 1.5f;
    [Space]
    [Header("UI")]
    [SerializeField] RectTransform statusPanel;
    [SerializeField] TextMeshPro characterHP;
    [SerializeField] TextMeshPro characterBarrier;
    [SerializeField] TextMeshPro posionCount;
    [SerializeField] Slider posionSlider;
    [SerializeField, Tooltip("�ϴ� ���� �̹���")] Image frostCount;
    [SerializeField, Tooltip("�ϴ� ���� ����")] TextMeshPro frostCountInt;//
    [SerializeField, Tooltip("ĳ���� ���� �ߴ� ����")] Image[] frostCounts;

    public int Fragile
    {
        get;  set;
    }
    public float FragilePercentage
    {
        get
        {
            return fragilePercentage;
        }
        set
        {
            fragilePercentage += value;
        }
    }
    /// <summary>
    /// ������� �����ϸ�, int ��, ���������, ��࿡ ������ �޴������� �˻� ����
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="trueDamage"></param>
    /// <param name="effectbyFragile"></param>
    public void ApplyDamage(int damage, bool trueDamage, bool effectbyFragile)
    {
        if(effectbyFragile == true)
        {
            float x = damage;
            float y = x * 1.5f;
            damage = (int)y;
        }
        if(barrier > 0)
        {
            int originalDamage = damage;
            damage -= barrier;
            barrier -= originalDamage;
        }
        if(damage < 0 && !trueDamage)
        {
            damage -= status.Armor;
            
        }
        
        if (damage <= 0)
        {
            status.Hp -= 1;
        }
        else
        {
            status.Hp -= damage;
        }
        status.Hp -= damage;

        if (status.Hp <= 0)
        {
            //�׾��!
        }
    }
}
