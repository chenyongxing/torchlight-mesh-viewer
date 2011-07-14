using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;

namespace Mogre.Demo.MogreForm
{
    /// <summary>Redirects all message of a type to one control</summary>
    [SecurityPermission(SecurityAction.LinkDemand)]
    public class RedirectMessageFilter : IMessageFilter
    {
        /// <summary>Send message to a window (platform invoke)</summary>
        /// <param name="hWnd">Window handle to send to</param>
        /// <param name="msg">Message</param>
        /// <param name="wParam">wParam</param>
        /// <param name="lParam">lParam</param>
        /// <returns>Zero if failure, otherwise non-zero</returns>
        [DllImport("User32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        /// <summary>Constructor</summary>
        /// <param name="message">Message to redirect</param>
        /// <param name="hWndTo">Window handle to redirect to</param>
        public RedirectMessageFilter(WindowsMessages message, IntPtr hWndTo)
        {
            _message = message;
            _hWndTo = hWndTo;
        }

        /// <summary>Message to redirect</summary>
        WindowsMessages _message;
        /// <summary>Windows to redirect to</summary>
        IntPtr _hWndTo;

        /// <summary>The message filter</summary>
        /// <param name="m">Message</param>
        /// <returns>True if handled, false if not</returns>
        /// <remarks>True will signal that the message has been handled and it will not be sent to any other control in the application.</remarks>
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == (int)_message && m.HWnd != _hWndTo)
            {
                IntPtr result = PostMessage(_hWndTo, m.Msg, m.WParam, m.LParam);
                return true;
            }

            // Not handled
            return false;
        }
    }

    /// <summary>Windows messages (WM_*, look in winuser.h)</summary>
    public enum WindowsMessages
    {
        WM_MOUSEWHEEL = 0x020A,
        WM_RBUTTONDOWN = 0x0204,
        WM_RBUTTONUP = 0x0205,
        WM_KEYDOWN = 0x0100,
        WM_KEYUP = 0x0101

    }
}
