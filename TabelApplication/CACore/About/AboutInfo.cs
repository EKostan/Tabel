using System.ComponentModel;

namespace CACore.About
{
    public class AboutInfo
    {
        /// <summary>
        /// ������ ���������
        /// </summary>
        [DisplayName("������ ���������")]
        [Category("������")]
        public string Version { get; set; }

        /// <summary>
        /// ���� ���������
        /// </summary>
        [DisplayName("���� ���������")]
        [Category("������")]
        public string Build { get; set; }


        

        /// <summary>
        /// ��� ������������
        /// </summary>
        [DisplayName("��� ������������")]
        [Category("�������")]
        public string UserName { get; set; }


    }}