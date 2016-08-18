using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Principal;

namespace Core.UserSecurity
{
    /// <summary>
    /// Установка контекста процесса от имени другого пользователя домена
    /// </summary>
    public class ImpersonationContext : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpszUsername"></param>
        /// <param name="lpszDomain"></param>
        /// <param name="lpszPassword"></param>
        /// <param name="dwLogonType"></param>
        /// <param name="dwLogonProvider"></param>
        /// <param name="phToken"></param>
        /// <returns></returns>
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(
            String lpszUsername,
            String lpszDomain,
            String lpszPassword,
            LogonType dwLogonType,
            LogonProvider dwLogonProvider,
            out SafeTokenHandle phToken);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int DuplicateToken(SafeTokenHandle hToken,
            int impersonationLevel,
            out SafeTokenHandle hNewToken);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool RevertToSelf();

        //[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        //public static extern int DuplicateToken(IntPtr hToken,
        //    int impersonationLevel,
        //    ref IntPtr hNewToken);
        //[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        //public static extern bool CloseHandle(IntPtr handle);
       
        ~ImpersonationContext()
        {
            Dispose(false);
        }

        private WindowsImpersonationContext _impersonationContext;
        private WindowsIdentity _tempWindowsIdentity;
        private bool _disposed;

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public bool ImpersonateValidUser(String userName, String domain, String password)
        {
            //AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            if (!RevertToSelf()) 
                return false;
            SafeTokenHandle token;
            if (LogonUser(userName, domain, password, LogonType.LOGON32_LOGON_NEW_CREDENTIALS,
                LogonProvider.LOGON32_PROVIDER_WINNT50, out token))
            {
                using (token)
                {
                    SafeTokenHandle tokenDuplicate;
                    if (DuplicateToken(token, 2, out tokenDuplicate) == 0) 
                        return false;
                    using (tokenDuplicate)
                    {
                        _tempWindowsIdentity = new WindowsIdentity(tokenDuplicate.DangerousGetHandle());
                        _impersonationContext = _tempWindowsIdentity.Impersonate();

                        if (_impersonationContext != null)
                            return true;
                    }
                }
            }
            else
            {
                var ret = Marshal.GetLastWin32Error();
                Console.WriteLine("LogonUser failed with error code : {0}", ret);
                throw new Win32Exception(ret);
            }
            return false;
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [DebuggerNonUserCode]
        public void UndoImpersonation()
        {
            _impersonationContext.Undo();
            WriteOutIdentityName();
        }

        private static void WriteOutIdentityName()
        {
#if DEBUG
            var windowsIdentity = WindowsIdentity.GetCurrent();
            if (windowsIdentity != null)
                Console.WriteLine("After closing the context: " + windowsIdentity.Name);
#endif
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

       

        protected void Dispose(bool disposing)
        {
            lock (this)
            {
                if (_disposed)
                    return;
                try
                {
                    if (disposing)
                    {
                        if (_tempWindowsIdentity != null)
                            _tempWindowsIdentity.Dispose();
                        if (_impersonationContext != null)
                        {
                            _impersonationContext.Undo();
                            _impersonationContext.Dispose();
                        }
                    }
                   
                }
                catch (Exception e)
                {
                    throw new ObjectDisposedException(
                        "ImpersonationContext throw an exception on dispose", e);
                }
                finally
                {
                    _tempWindowsIdentity = null;
                    _impersonationContext = null;
                    _disposed = true;
                }
            }
        }
    }
}