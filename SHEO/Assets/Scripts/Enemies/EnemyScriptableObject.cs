using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "Scriptable Objects/EnemyScriptableObject")]
public class EnemyScriptableObject : ScriptableObject
{
    public Sprite image;
    public string enemyName = "Name";
    public string enemyClass = "Class";
    public string enemyType = "Type";
    public string enemyPersonality = "Personality";
    public float enemyHP = 0f;
    public float enemySP = 0f;
    public float enemySPRegen = 0f;
    public float enemyLuck = 0f;
    public float enemyTechAttack = 0f;
    public float enemySoftAttack = 0f;
    public float enemyAvoid = 0f;
    public string enemyAbility = "Ability";

}
