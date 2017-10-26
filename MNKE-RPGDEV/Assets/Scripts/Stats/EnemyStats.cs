using UnityEngine;

[CreateAssetMenu (menuName = "RPG/Characters/Enemy")]
public class EnemyStats : ScriptableObject
{
    public string EnemyName;
    public int MaxHealth;
    public int maxSpaceToMoveBeforeRotate;
    public float detectionDistance;
    [Range(0.6f, 3.0f)]
    public float moveWaitTime;
    public LayerMask raycastLayerMask;
    public float moveSpeed;
    public Color PatrolColor;
    public Color MoveToColor;
    public Color AttackColor;
    public int Level;
    public GameObject Prefab;
}
