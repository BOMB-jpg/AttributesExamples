using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationComponent.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter
    | AttributeTargets.Property, AllowMultiple = false)]
    //是否允许多次应用于同一个目标 在这种情况下 表示多次应用于同一个目标
    public class RegularExpressionAttribute:Attribute
    {
        public string ErrorMessage { get; set; }

        public string Pattern { get; set; }

        public RegularExpressionAttribute(string pattern)
        {
            Pattern = pattern;
            ErrorMessage = "Field, {0}, is invalid. The value provided does not match the declared regular expression pattern, {1}";
        }
        public RegularExpressionAttribute(string pattern, string errorMessage)
        //pattern 正则表达式模式 和errorMessage 将这些消息都放入方法中
        {
            Pattern = pattern;
            ErrorMessage = errorMessage;
        }
    }
}
