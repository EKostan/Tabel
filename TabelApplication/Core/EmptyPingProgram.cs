using System;

namespace Core
{
    /// <summary>
    /// ����������� ������ �����
    /// </summary>
    public class EmptyPingProgram : IPingProgram
    {
        /// <summary>
        /// �������� ping ���������
        /// </summary>
        /// <param name="address">��������� �����</param>
        /// <param name="timeout">������� ���� �������</param>
        /// <param name="timeoutAction">������� ���������� ��� ��������</param>
        /// <returns>������� �� ����� �� ���������� ����</returns>
        public bool PingSync(string address, TimeSpan timeout, Action timeoutAction)
        {
            return true;
        }
        /// <summary>
        /// �������� ping ����������
        /// </summary>
        /// <param name="address">��������� �����</param>
        /// <param name="timeout">������� ���� �������</param>
        /// <param name="timeoutAction">������� ���������� ��� ��������</param>
        /// <param name="resultAction">������� ���������� ��� �������� ���������� Ping �������.
        /// ����, �������� resultAction ��������� � true, ������
        /// �� ����� ���������� ���� ��������� ������</param>
        public void PingAsync(string address, TimeSpan timeout, Action timeoutAction, Action<bool> resultAction)
        {
            resultAction(false);
        }
        /// <summary>
        /// �������� ping ���������
        /// </summary>
        /// <param name="address">��������� �����</param>
        /// <param name="timeout">������� ���� �������</param>
        /// <param name="timeoutAction">������� ���������� ��� ��������</param>
        /// <returns>������� �� ����� �� ���������� ����</returns>
        public bool PingSync(Uri address, TimeSpan timeout, Action timeoutAction)
        {
            return true;
        }
        /// <summary>
        /// �������� ping ����������
        /// </summary>
        /// <param name="address">��������� �����</param>
        /// <param name="timeout">������� ���� �������</param>
        /// <param name="timeoutAction">������� ���������� ��� ��������</param>
        /// <param name="resultAction">������� ���������� ��� �������� ���������� Ping �������.
        /// ����, �������� resultAction ��������� � true, ������
        /// �� ����� ���������� ���� ��������� ������</param>
        public void PingAsync(Uri address, TimeSpan timeout, Action timeoutAction, Action<bool> resultAction)
        {
            resultAction(false);
        }
    }
}