using UnityEngine;
using Assets.KsCode.CakeBehaviour;

namespace Assets.KsCode.CakeBehaviour {
    // This namespace is intended for cake-related behaviors in the game.
    public abstract class CakeBehaviour : MonoBehaviour {
        protected readonly MBCake cake = MBCake.New;
        protected MBSlice AddSlice {
            set => cake.AddSlice(value);
        }
        protected event SliceDelegate Cake {
            add => cake.AddSlice(value.Invoke());
            remove { }
        }
        protected abstract void Init();
        protected virtual void Awake() {
            Init();
            cake.awake.Execute();
        }
        protected virtual void OnValidate() => cake.onValidate.Execute();
        protected virtual void OnEnable() => cake.onEnable.Execute();
        protected virtual void Start() => cake.start.Execute();
        protected virtual void OnDisable() => cake.onDisable.Execute();
        protected virtual void OnDestroy() => cake.onDestroy.Execute();
    }
    public delegate MBSlice SliceDelegate();
}
