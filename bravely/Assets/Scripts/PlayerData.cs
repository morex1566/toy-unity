using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Object/PlayerData", order = int.MaxValue)]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private string playerName;
    public string PlayerName { get { return playerName; } set { playerName = value; } }


    [SerializeField]
    private int hp;
    public int Hp { get { return hp; } set { hp = value; } }
    [SerializeField]
    private int sp;
    public int Sp { get { return sp; } set { sp = value; } }
}
