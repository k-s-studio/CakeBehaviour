using System;
using UnityEngine;
using Assets.KsCode.CakeBehaviour;

[ExecuteAlways]
public class CakeBehaviourExample : CakeBehaviour {
    public string elfName;
    [NonSerialized] public GameObject CakeElf;
    protected override void Init() {
        // Cake += (o) => MBSlice.New.
        //     Awake(() => CakeElf = new("CakeElf")).
        //     OnValidate(() => CakeElf.name = elfName).
        //     OnDestroy(() => DestroyImmediate(CakeElf));
        //宣告方法內可以引用非靜態變數
    }
    // 宣告新變數時無法引用非靜態變數
    // MBSlice ControlElfName = MBSlice.New.
    //     Awake(() => CakeElf = new("CakeElf"));

    MBSlice ControlElf() => Slice.
        Awake(() => CakeElf = new("CakeElf")).
        Start(() => Debug.Log($"Hi! My name is {elfName}")).
        OnValidate(() => CakeElf.name = elfName).
        OnDestroy(() => DestroyImmediate(CakeElf));

    MBSlice ControlElf2() => MBSlice.New.
        Awake(() => CakeElf = new("CakeElf")).
        Start(() => Debug.Log($"Hi! My name is {elfName}")).
        OnValidate(() => CakeElf.name = elfName).
        OnDestroy(() => DestroyImmediate(CakeElf));
}