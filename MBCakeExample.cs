using System;
using UnityEngine;
using Assets.KsCode.CakeBehaviour;

[ExecuteAlways]
public class MBCakeExample : MonoBehaviour {
    static private readonly MBCake cake = new();

    // void Awake() => cake.awake.Execute();
    // void OnValidate() => cake.onValidate.Execute();
    // void OnEnable() => cake.onEnable.Execute();
    // void Start() => cake.start.Execute();
    // void OnDisable() => cake.onDisable.Execute();
    // void OnDestroy() => cake.onDestroy.Execute();
}