using UnityEngine;
using Assets.KsCode.CakeBehaviour;

namespace Assets.KsCode.CakeBehaviour {
    // This namespace is intended for cake-related behaviors in the game.
    public class CakeBehaviour : MonoBehaviour {
        readonly MBCake cake = MBCake.New;
        void Awake() => cake.awake.Execute();
        void OnValidate() => cake.onValidate.Execute();
        void OnEnable() => cake.onEnable.Execute();
        void Start() => cake.start.Execute();
        void OnDisable() => cake.onDisable.Execute();
        void OnDestroy() => cake.onDestroy.Execute();
    }
}
