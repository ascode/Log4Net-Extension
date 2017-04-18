using System;
using System.Collections.Generic;
using System.Text;
using log4net.Layout;
using log4net.Layout.Pattern;
using System.Reflection;
using System.Collections;


namespace ConsoleApp.LogEx
{
    public class CommonLayout : PatternLayout
    {
        public CommonLayout()
        {
            this.AddConverter("property", typeof(ReflectionPatternConverter));
        }

    }

    public class ReflectionPatternConverter : PatternLayoutConverter
    {
        protected override void Convert(System.IO.TextWriter writer,log4net.Core.LoggingEvent loggingEvent)
        {
            if (Option != null)
            {
                // 写入指定键的值
                WriteObject(writer,loggingEvent.Repository,LookupProperty(Option,loggingEvent));
            }

            else
            {
                // 写入所有关键值对
                WriteDictionary(writer,loggingEvent.Repository,loggingEvent.GetProperties());
            }

        }

        /// <summary>
        /// 通过反射获取传入的日志对象的某个属性的值
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        private object LookupProperty(string property,log4net.Core.LoggingEvent loggingEvent)
        {
            object propertyValue = string.Empty;
            PropertyInfo propertyInfo = loggingEvent.MessageObject.GetType().GetProperty(property);

            if (propertyInfo != null)
            {
                propertyValue = propertyInfo.GetValue(loggingEvent.MessageObject, null);
            }
            return propertyValue;
        }
    }
}