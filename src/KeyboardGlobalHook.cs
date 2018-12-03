using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyKeyMappingGenerator {
    // http://qiita.com/exliko/items/3135e4413a6da067b35d

    /// <summary>
    /// Keyboard Global Hook
    /// </summary>
    public static class KeyboardGlobalHook {

        #region Declaration
        private static class NativeMethods {
            public delegate IntPtr KeyboardGlobalHookCallback(int code, uint msg, ref KBDLLHOOKSTRUCT hookData);

            // https://msdn.microsoft.com/ja-jp/library/cc430103.aspx
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern System.IntPtr SetWindowsHookEx(int idHook, KeyboardGlobalHookCallback lpfn, System.IntPtr hMod, uint dwThreadId);

            // https://msdn.microsoft.com/ja-jp/library/cc429591.aspx
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern System.IntPtr CallNextHookEx(System.IntPtr hhk, int nCode, uint msg, ref KBDLLHOOKSTRUCT hookData);

            // https://msdn.microsoft.com/ja-jp/library/cc430120.aspx
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
            public static extern bool UnhookWindowsHookEx(System.IntPtr hhk);

            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern uint keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        }

        public enum Stroke {
            KEY_DOWN,
            KEY_UP,
            SYSKEY_DOWN,
            SYSKEY_UP,
            UNKNOWN
        }

        public enum KeyFlags : uint {
            LLKHF_EXTENDED = 0x01,
            LLKHF_INJECTED = 0x10,
            LLKHF_ALTDOWN = 0x20,
            LLKHF_UP = 0x80

        }

        public struct KeyboardData {
            public Stroke Stroke;
            public Keys Key;
            public uint ScanCode;
            public uint Flags;
            public uint Time;
            public IntPtr ExtraInfo;
            public bool Extended;
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT {
            public uint vkCode;
            public uint scanCode;
            public uint flags;
            public uint time;
            public System.IntPtr dwExtraInfo;
        }

        public static KeyboardData KeyboardState;
        public delegate void HookHandler(ref KeyboardData data);
        private static IntPtr Handle;
        private static bool IsCancel;
        private static List<HookHandler> Events;
        private static event HookHandler HookEvent;
        private static event NativeMethods.KeyboardGlobalHookCallback hookCallback;
        #endregion

        #region Public Property
        public static bool IsHooking {
            get;
            private set;
        }

        public static bool IsPaused {
            get;
            private set;
        }
        #endregion

        #region Public Method
        public static void Start() {
            if (IsHooking) {
                return;
            }

            IsHooking = true;
            IsPaused = false;

            hookCallback = HookProcedure;
            System.IntPtr h = System.Runtime.InteropServices.Marshal.GetHINSTANCE(typeof(KeyboardGlobalHook).Assembly.GetModules()[0]);

            // WH_KEYBOARD_LL = 13;
            Handle = NativeMethods.SetWindowsHookEx(13, hookCallback, h, 0);

            if (Handle == System.IntPtr.Zero) {
                IsHooking = false;
                IsPaused = true;

                throw new System.ComponentModel.Win32Exception();
            }
        }

        public static void Stop() {
            if (!IsHooking) {
                return;
            }

            if (Handle != System.IntPtr.Zero) {
                IsHooking = false;
                IsPaused = true;

                ClearEvent();

                NativeMethods.UnhookWindowsHookEx(Handle);
                Handle = System.IntPtr.Zero;
                hookCallback -= HookProcedure;
            }
        }

        public static void Cancel() {
            IsCancel = true;
        }

        public static void Pause() {
            IsPaused = true;
        }

        public static void AddEvent(HookHandler hookHandler) {
            if (Events == null) {
                Events = new System.Collections.Generic.List<HookHandler>();
            }

            Events.Add(hookHandler);
            HookEvent += hookHandler;
        }

        public static void RemoveEvent(HookHandler hookHandler) {
            if (Events == null) {
                return;
            }
            HookEvent -= hookHandler;
            Events.Remove(hookHandler);
        }

        public static void ClearEvent() {
            if (Events == null) {
                return;
            }

            foreach (HookHandler e in Events) {
                HookEvent -= e;
            }

            Events.Clear();
        }
        #endregion

        #region Privater Method
        private static IntPtr HookProcedure(int nCode, uint msg, ref KBDLLHOOKSTRUCT hookData) {
            if (nCode >= 0 && HookEvent != null && !IsPaused) {
                KeyboardState.Stroke = GetStroke(msg);
                KeyboardState.Key = (System.Windows.Forms.Keys)hookData.vkCode;
                KeyboardState.ScanCode = hookData.scanCode;
                KeyboardState.Flags = hookData.flags;
                KeyboardState.Time = hookData.time;
                KeyboardState.ExtraInfo = hookData.dwExtraInfo;
                KeyboardState.Extended = (((KeyFlags)hookData.flags & KeyFlags.LLKHF_EXTENDED) == KeyFlags.LLKHF_EXTENDED);


                if (hookData.scanCode == 121) {
                    NativeMethods.keybd_event(0x79, 0, 0, (UIntPtr)0);
                    NativeMethods.keybd_event(0x79, 0, 0x101, (UIntPtr)0);
                } else {
                    HookEvent(ref KeyboardState);
                }

                if (IsCancel) {
                    IsCancel = false;

                    return (System.IntPtr)1;
                }
            }

            return NativeMethods.CallNextHookEx(Handle, nCode, msg, ref hookData);
        }

        private static Stroke GetStroke(uint msg) {
            switch (msg) {
                case 0x100:
                    return Stroke.KEY_DOWN;
                case 0x101:
                    return Stroke.KEY_UP;
                case 0x104:
                    return Stroke.SYSKEY_DOWN;
                case 0x105:
                    return Stroke.SYSKEY_UP;
                default:
                    return Stroke.UNKNOWN;
            }
        }
        #endregion
    }
}
