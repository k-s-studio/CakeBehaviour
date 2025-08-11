using System;
using UnityEngine;
using Assets.KsCode.CakeBehaviour;

[ExecuteAlways]
public class CakeBehaviourExample : CakeBehaviour {
    public string elfName;
    [NonSerialized] public GameObject CakeElf;
    protected override void Init() {
        Cake += () => new MBSlice();
    }
    // MBSlice ControlElfName = new MBSlice().
    // Awake(
    //    () => { CakeElf = new("CakeElf"); }
    // ).
    // Start(
    //     //this.MyFunc()
    // );

    bool MyFunc() {
        bool flagA, flagB;
        void A(bool flag) => flagA = flag;
        void B(bool flag) => flagB = flag;
        A(true);
        B(false);
        return flagA && flagB;
    }
}