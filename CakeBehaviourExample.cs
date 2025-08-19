using System;
using Stopwatch = System.Diagnostics.Stopwatch;
using UnityEngine;
using Assets.KsCode.CakeBehaviour;

[ExecuteAlways]
public class CakeBehaviourExample : CakeBehaviour {
    public string elf1Name;
    public string elf2Name;
    private readonly Stopwatch stopwatch = new();
    [NonSerialized] public GameObject[] CakeElf = { null, null };
    protected override void Assemble() {
        LogBegin();
        ControlElf();
        ControlElf2();
        LogEnd();

        // Cake += (o) => MBSlice.New.
        //     Awake(() => CakeElf = new("CakeElf")).
        //     OnValidate(() => CakeElf.name = elfName).
        //     OnDestroy(() => DestroyImmediate(CakeElf));
        //宣告方法內可以引用非靜態變數
    }
    // 宣告新變數時無法引用非靜態變數
    // MBSlice ControlElfName = MBSlice.New.
    //     Awake(() => CakeElf = new("CakeElf"));
    MBSlice LogBegin() => Add.
        Awake(() => Debug.Log("Awake() from First slice.")).
        OnValidate(() => Debug.Log("OnValidate() from First slice.")).
        OnEnable(() => Debug.Log("OnEnable() from First slice.")).
        Start(() => Debug.Log("Start() from First slice.")).
        OnDisable(() => Debug.Log("OnDisable() from First slice.")).
        OnDestroy(() => Debug.Log("OnDestroy() from First slice."));
    MBSlice LogEnd() => Add.
        Awake(() => Debug.Log("Awake() from Last slice.")).
        OnValidate(() => Debug.Log("OnValidate() from Last slice.")).
        OnEnable(() => Debug.Log("OnEnable() from Last slice.")).
        Start(() => Debug.Log("Start() from Last slice.")).
        OnDisable(() => Debug.Log("OnDisable() from Last slice.")).
        OnDestroy(() => Debug.Log("OnDestroy() from Last slice."));
    MBSlice ControlElf() => Add.
        Awake(() => CakeElf[0] = new("CakeElf")).
        Start(() => Debug.Log($"Hi! My name is {CakeElf[0].name}")).
        OnValidate(() => CakeElf[0].name = elf1Name).
        OnDestroy(() => DestroyImmediate(CakeElf[0]));

    MBSlice ControlElf2() => Add.
        Awake(() => CakeElf[1] = new("CakeElf")).
        Start(() => Debug.Log($"Hi! My name is {CakeElf[1].name}")).
        OnValidate(() => CakeElf[1].name = elf2Name).
        OnDestroy(() => DestroyImmediate(CakeElf[1]));

    protected override void Awake() {
        stopwatch.Restart();
        base.Awake();
        stopwatch.Stop();
        Debug.Log($"Awake(): {stopwatch.ElapsedMilliseconds} ms");
    }
    protected override void OnValidate() {
        stopwatch.Restart();
        base.OnValidate();
        stopwatch.Stop();
        Debug.Log($"OnValidate(): {stopwatch.ElapsedMilliseconds} ms");
    }
    protected override void OnEnable() {
        stopwatch.Restart();
        base.OnEnable();
        stopwatch.Stop();
        Debug.Log($"OnEnable(): {stopwatch.ElapsedMilliseconds} ms");
    }
    protected override void Start() {
        stopwatch.Restart();
        base.Start();
        stopwatch.Stop();
        Debug.Log($"Start(): {stopwatch.ElapsedMilliseconds} ms");
    }
    protected override void OnDisable() {
        stopwatch.Restart();
        base.OnDisable();
        stopwatch.Stop();
        Debug.Log($"OnDisable(): {stopwatch.ElapsedMilliseconds} ms");
    }
    protected override void OnDestroy() {
        stopwatch.Restart();
        base.OnDestroy();
        stopwatch.Stop();
        Debug.Log($"OnDestroy(): {stopwatch.ElapsedMilliseconds} ms");
    }
}