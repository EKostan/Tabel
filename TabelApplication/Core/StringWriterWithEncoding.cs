using System;
using System.IO;
using System.Text;

namespace Core
{
    /// <summary>
    /// Наследник StringWriter, который имеет возможность устанавливать кодировку.
    /// </summary>
    public class StringWriterWithEncoding : StringWriter
    {
        private readonly Encoding _encoding;

        /// <summary>
        /// 
        /// </summary>
        public StringWriterWithEncoding()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formatProvider"></param>
        public StringWriterWithEncoding(IFormatProvider formatProvider)
            : base(formatProvider)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sb"></param>
        public StringWriterWithEncoding(StringBuilder sb)
            : base(sb)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="formatProvider"></param>
        public StringWriterWithEncoding(StringBuilder sb, IFormatProvider formatProvider)
            : base(sb, formatProvider)
        {
        }

        /// <summary>
        /// Расширяет базовый конструктор кодировкой encoding
        /// </summary>
        /// <param name="encoding">Кодировка строки</param>
        public StringWriterWithEncoding(Encoding encoding)
        {
            _encoding = encoding;
        }

        /// <summary>
        /// Расширяет базовый конструктор кодировкой encoding
        /// </summary>
        /// <param name="formatProvider"></param>
        /// <param name="encoding">Кодировка строки</param>
        public StringWriterWithEncoding(IFormatProvider formatProvider, Encoding encoding)
            : base(formatProvider)
        {
            _encoding = encoding;
        }

        /// <summary>
        /// Расширяет базовый конструктор кодировкой encoding
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="encoding">Кодировка строки</param>
        public StringWriterWithEncoding(StringBuilder sb, Encoding encoding)
            : base(sb)
        {
            _encoding = encoding;
        }

        /// <summary>
        /// Расширяет базовый конструктор кодировкой encoding
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="formatProvider"></param>
        /// <param name="encoding">Кодировка строки</param>
        public StringWriterWithEncoding(StringBuilder sb, IFormatProvider formatProvider, Encoding encoding)
            : base(sb, formatProvider)
        {
            _encoding = encoding;
        }

        /// <summary>
        /// Возвращает установленную кодировку
        /// </summary>
        public override Encoding Encoding
        {
            get { return (null == _encoding) ? base.Encoding : _encoding; }
        }
    }
}
