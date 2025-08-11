using System;
using System.Linq;

namespace Assets.KsCode.CakeBehaviour {
    public class MBCake {
        public readonly MessageLayer awake;
        public readonly MessageLayer onValidate;
        public readonly MessageLayer onEnable;
        public readonly MessageLayer start;
        public readonly MessageLayer onDisable;
        public readonly MessageLayer onDestroy;
        public MBCake() {
            awake = new();
            onValidate = new();
            onEnable = new();
            start = new();
            onDisable = new();
            onDestroy = new();
        }

        #region Initialize with [var = optional]
        // public MBCake(
        //     SliceAction Awake = null,
        //     SliceAction OnValidate = null,
        //     SliceAction OnEnable = null,
        //     SliceAction Start = null,
        //     SliceAction OnDisable = null,
        //     SliceAction OnDestroy = null) {
        //     this.awake = new(Awake);
        //     this.onValidate = new(OnValidate);
        //     this.onEnable = new(OnEnable);
        //     this.start = new(Start);
        //     this.onDisable = new(OnDisable);
        //     this.onDestroy = new(OnDestroy);
        // }
        public MBCake(MBSlice firstSlice) {
            this.awake = new(firstSlice.awake);
            this.onValidate = new(firstSlice.onValidate);
            this.onEnable = new(firstSlice.onEnable);
            this.start = new(firstSlice.start);
            this.onDisable = new(firstSlice.onDisable);
            this.onDestroy = new(firstSlice.onDestroy);
        }
        #endregion Initialize with [var = optional]
        #region Initialize with func.chain
        // public MBCake Awake(Func<bool> func) { awake.Task += func; return this; }
        // public MBCake Awake(Action func) => Awake((SliceAction)func);
        // public MBCake OnValidate(Func<bool> func) { onValidate.Task += func; return this; }
        // public MBCake OnValidate(Action func) => OnValidate((SliceAction)func);
        // public MBCake OnEnable(Func<bool> func) { onEnable.Task += func; return this; }
        // public MBCake OnEnable(Action func) => OnEnable((SliceAction)func);
        // public MBCake Start(Func<bool> func) { start.Task += func; return this; }
        // public MBCake Start(Action func) => Start((SliceAction)func);
        // public MBCake OnDisable(Func<bool> func) { onDisable.Task += func; return this; }
        // public MBCake OnDisable(Action func) => OnDisable((SliceAction)func);
        // public MBCake OnDestroy(Func<bool> func) { onDestroy.Task += func; return this; }
        // public MBCake OnDestroy(Action func) => OnDestroy((SliceAction)func);
        #endregion Initialize with func.chain
        public static MBSlice New => default; //start with a slice
        public static MBCake operator +(MBCake a, MBSlice b) {
            a.awake.Task += b.awake;
            a.onValidate.Task += b.onValidate;
            a.onEnable.Task += b.onEnable;
            a.start.Task += b.start;
            a.onDisable.Task += b.onDisable;
            a.onDestroy.Task += b.onDestroy;
            return a;
        }
        public static implicit operator MBCake(MBSlice slice) => new(slice);
    }

    public class MessageLayer {
        public event Func<bool> Task;
        public void Execute() {
            if (Task == null) return;
            foreach (Func<bool> func in Task.GetInvocationList().Cast<Func<bool>>())
                if (func.Invoke() == true) return;
        }
        public MessageLayer() { Task = default; }
        public MessageLayer(SliceAction task) => Task = task;
        public static implicit operator MessageLayer(Func<bool> func) => new(func);
        public static implicit operator MessageLayer(Action func) => new(func);
    }
    public struct MBSlice {
        public SliceAction awake;
        public SliceAction onValidate;
        public SliceAction onEnable;
        public SliceAction start;
        public SliceAction onDisable;
        public SliceAction onDestroy;
        public MBSlice Awake(Func<bool> func) { awake = func; return this; }
        public MBSlice Awake(Action func) => Awake((SliceAction)func);
        public MBSlice OnValidate(Func<bool> func) { onValidate = func; return this; }
        public MBSlice OnValidate(Action func) => OnValidate((SliceAction)func);
        public MBSlice OnEnable(Func<bool> func) { onEnable = func; return this; }
        public MBSlice OnEnable(Action func) => OnEnable((SliceAction)func);
        public MBSlice Start(Func<bool> func) { start = func; return this; }
        public MBSlice Start(Action func) => Start((SliceAction)func);
        public MBSlice OnDisable(Func<bool> func) { onDisable = func; return this; }
        public MBSlice OnDisable(Action func) => OnDisable((SliceAction)func);
        public MBSlice OnDestroy(Func<bool> func) { onDestroy = func; return this; }
        public MBSlice OnDestroy(Action func) => OnDestroy((SliceAction)func);
        public static MBSlice New => default;
        //operator(s?)
        public static MBSlice operator +(MBSlice a, MBSlice b) {
            return new MBSlice {
                awake = a.awake + b.awake,
                onValidate = a.onValidate + b.onValidate,
                onEnable = a.onEnable + b.onEnable,
                start = a.start + b.start,
                onDisable = a.onDisable + b.onDisable,
                onDestroy = a.onDestroy + b.onDestroy
            };
        }
    }
    public readonly struct SliceAction {
        private readonly Func<bool> m_Action;
        public SliceAction(Func<bool> action) => m_Action = action;
        public SliceAction(Action action) => m_Action = () => { action(); return false; };
        public static SliceAction Empty => new();

        public static SliceAction operator +(SliceAction a, SliceAction b) => new(a.m_Action + b.m_Action);
        public static implicit operator SliceAction(Func<bool> func) => new(func);
        public static implicit operator SliceAction(Action func) => new(func);
        public static implicit operator Func<bool>(SliceAction action) => action.m_Action;
    }
    public delegate Func<bool> SliceStep(Func<bool> func);
}