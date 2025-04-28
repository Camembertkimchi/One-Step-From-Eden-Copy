using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Damageable : MonoBehaviour
{
    [SerializeField]ScriptableStatus status;
    [SerializeField]int barrier;
    IEnumerator poisonCor;
    [SerializeField]int frost;
    [SerializeField]int poison;
    [SerializeField]float poisonTime = 4f;
    [SerializeField]float fragilePercentage = 1.5f;
    [Space]
    [Header("UI")]
    [SerializeField] RectTransform statusPanel;
    [SerializeField] TextMeshPro characterHP;
    [SerializeField] TextMeshPro characterBarrier;
    [SerializeField] TextMeshPro posionCount;
    [SerializeField] Slider posionSlider;
    [SerializeField, Tooltip("하단 빙결 이미지")] Image frostCount;
    [SerializeField, Tooltip("하단 빙결 숫자")] TextMeshPro frostCountInt;//
    [SerializeField, Tooltip("캐릭터 위에 뜨는 빙결")] Image[] frostCounts;
    [SerializeField] bool alive = true;
    [SerializeField] bool inBoss = false;

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
   public void ApplyPoison(int amount)
    {
        poisonCor = PosionCor(amount);
        StartCoroutine(poisonCor);

    }
    /// <summary>
    /// 대미지를 적용하며, int 값, 고정대미지, 취약에 영향을 받는지, 배리어 무시까지 검사 가능
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="trueDamage"></param>
    /// <param name="effectbyFragile"></param>
    public void ApplyDamage(int damage, bool trueDamage, bool effectbyFragile, bool ignoreBarrier)
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
            if (inBoss)
            {
                //보스에서 어쩌구
            }
            alive = false;

        }
    }

    IEnumerator PosionCor(int amount)
    {
        poison += amount;
        while(poison >= 10)
        {
            yield return new WaitForSeconds(poisonTime);
            ApplyDamage(poison, true, false, true);
            poison /= 2;

        }
    }


}
