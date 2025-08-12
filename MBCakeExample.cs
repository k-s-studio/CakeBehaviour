using System;
using UnityEngine;
using Assets.KsCode.CakeBehaviour;

[ExecuteAlways]
public class MBCakeExample : MonoBehaviour {
    //static event Action MYaCTION;
    // static private readonly MBCake cake = MBCake.New.
    //     Awake(() => {
    //         Debug.Log("Awake1!!!!");
    //         MYaCTION += () => Debug.Log("aciton!!");
    //         return true;
    //     }).
    //     OnValidate(() => {
    //         Debug.Log("OnValidate1!!!!");
    //     }).
    //     OnEnable(() => {
    //         MYaCTION?.Invoke();
    //     });
    // static MBCakeExample() {
    //     cake += MBSlice.New.
    //         Awake(() => {
    //             Debug.Log("Awake2!!!!");
    //         }).
    //         OnValidate(() => {
    //             Debug.Log("OnValidate2!!!!");
    //         });
    // }

    // private readonly MBCake cake2 = new MBSlice() {
    //     awake = new(() => { }),
    //     onValidate = new(() => { }),
    //     onEnable = new(() => { }),
    //     start = new(() => { }),
    //     onDisable = new(() => { }),
    //     onDestroy = new(() => { }),
    // };
    // void Awake() => cake.awake.Execute();
    // void OnValidate() => cake.onValidate.Execute();
    // void OnEnable() => cake.onEnable.Execute();
    // void Start() => cake.start.Execute();
    // void OnDisable() => cake.onDisable.Execute();
    // void OnDestroy() => cake.onDestroy.Execute();
}