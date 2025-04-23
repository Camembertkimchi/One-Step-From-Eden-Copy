using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//스킬 범위 지정
public enum AttackRangeType
{
    Single,
    FixedPattern,
    Targeting
}
//타일 상태
public enum TileState
{
    None,
    Fire,
    Broken,
    Glassed
}

//public interface ICharacterState
//{
//    string Name { get; }
//    float 
//}