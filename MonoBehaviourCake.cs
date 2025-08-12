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
        public MBSlice Add => new(this);
    }
    public class MessageLayer {
        public event Func<Arg> Task;
        public void Execute() {
            if (Task == null) return;
            foreach (Func<Arg> func in Task.GetInvocationList().Cast<Func<Arg>>())
                if (func.Invoke() == Arg.END) return;
        }
        public MessageLayer() { Task = default; }
        public MessageLayer(SliceAction task) => Task = task;
        public static implicit operator MessageLayer(Func<Arg> func) => new(func);
        public static implicit operator MessageLayer(Action func) => new(func);
        public enum Arg { END = 0, CONTI = 1 }
    }
    public struct MBSlice {
        private MBCake m_MBCake;
        public readonly MBSlice Awake(Func<MessageLayer.Arg> func) { m_MBCake.awake.Task += func; return this; }
        public readonly MBSlice Awake(Action func) => Awake((SliceAction)func);
        public readonly MBSlice OnValidate(Func<MessageLayer.Arg> func) { m_MBCake.onValidate.Task += func; return this; }
        public readonly MBSlice OnValidate(Action func) => OnValidate((SliceAction)func);
        public readonly MBSlice OnEnable(Func<MessageLayer.Arg> func) { m_MBCake.onEnable.Task += func; return this; }
        public readonly MBSlice OnEnable(Action func) => OnEnable((SliceAction)func);
        public readonly MBSlice Start(Func<MessageLayer.Arg> func) { m_MBCake.start.Task += func; return this; }
        public readonly MBSlice Start(Action func) => Start((SliceAction)func);
        public readonly MBSlice OnDisable(Func<MessageLayer.Arg> func) { m_MBCake.onDisable.Task += func; return this; }
        public readonly MBSlice OnDisable(Action func) => OnDisable((SliceAction)func);
        public readonly MBSlice OnDestroy(Func<MessageLayer.Arg> func) { m_MBCake.onDestroy.Task += func; return this; }
        public readonly MBSlice OnDestroy(Action func) => OnDestroy((SliceAction)func);
        public MBSlice(MBCake ofCake) => m_MBCake = ofCake;
    }
    public readonly struct SliceAction {
        private readonly Func<MessageLayer.Arg> m_Action;
        public SliceAction(Func<MessageLayer.Arg> action) => m_Action = action;
        public SliceAction(Action action) => m_Action = () => { action(); return MessageLayer.Arg.CONTI; };

        public static SliceAction operator +(SliceAction a, SliceAction b) => new(a.m_Action + b.m_Action);
        public static implicit operator SliceAction(Func<MessageLayer.Arg> func) => new(func);
        public static implicit operator SliceAction(Action func) => new(func);
        public static implicit operator Func<MessageLayer.Arg>(SliceAction action) => action.m_Action;
    }
}