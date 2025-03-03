//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public CreateGameObjectCmdComp createGameObjectCmdComp { get { return (CreateGameObjectCmdComp)GetComponent(GameComponentsLookup.CreateGameObjectCmdComp); } }
    public bool hasCreateGameObjectCmdComp { get { return HasComponent(GameComponentsLookup.CreateGameObjectCmdComp); } }

    public void AddCreateGameObjectCmdComp(string newPath) {
        var index = GameComponentsLookup.CreateGameObjectCmdComp;
        var component = (CreateGameObjectCmdComp)CreateComponent(index, typeof(CreateGameObjectCmdComp));
        component.path = newPath;
        AddComponent(index, component);
    }

    public void ReplaceCreateGameObjectCmdComp(string newPath) {
        var index = GameComponentsLookup.CreateGameObjectCmdComp;
        var component = (CreateGameObjectCmdComp)CreateComponent(index, typeof(CreateGameObjectCmdComp));
        component.path = newPath;
        ReplaceComponent(index, component);
    }

    public void RemoveCreateGameObjectCmdComp() {
        RemoveComponent(GameComponentsLookup.CreateGameObjectCmdComp);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCreateGameObjectCmdComp;

    public static Entitas.IMatcher<GameEntity> CreateGameObjectCmdComp {
        get {
            if (_matcherCreateGameObjectCmdComp == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CreateGameObjectCmdComp);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCreateGameObjectCmdComp = matcher;
            }

            return _matcherCreateGameObjectCmdComp;
        }
    }
}
