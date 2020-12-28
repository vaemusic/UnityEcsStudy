using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game,Input]
public class IdComp : IComponent
{
    //便于后边敌人增加目标，不直接引用玩家的entity,而是id
    [PrimaryEntityIndex]
    public int Value;
}
