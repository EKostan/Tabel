using System;

namespace Core
{
    /// <summary>
    /// ����������������� ������ ��� �������� ���������� � ��������
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseEventArgs<T> : EventArgs
    {
        /// <summary>
        /// ��������
        /// </summary>
        public T Value;

        /// <summary>
        /// ����������� ���������� ���������������� ��������� value.
        /// </summary>
        /// <param name="value">��������</param>
        public BaseEventArgs(T value)
        {
            Value = value;
        }
    }
}