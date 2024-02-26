using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

using ValidationComponent.CustomAttributes;

namespace AttributesExamples.Models
{
    public class Employee
    {
        [Required]  // 这个是与通用模型中必须使用的一项注释
        public int Id { get; set; }
        
        [Required] 
        //意思是该属性长度不能超过16并给出了错误信息的模版
        [StringLength(15,"Field, {0}, cannot exceed {1} characters in length and cannot be less than {2} characters in length",2)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(15, "Field, {0}, cannot exceed {1} characters in length and cannot be less than {2} characters in length", 2)]
        [JsonIgnore]
        public string LastName { get; set; }

        [Required]
        [StringLength(15, "Field, {0}, cannot exceed {1} characters in length and cannot be less than {2} characters in length", 2)]
        [RegularExpression(@"\s*\(?0\d{4}\)?\s*\d{6}\s*)|(\s*\(?0\d{3}\)?\s*\d{3}\s*\d{4}\s*")]
        //用于验证字符串符合给正则表达式 区号为4位，电话号为6位
        [JsonIgnore]
        public string PhoneNumber { get; set; }
        
        [Required]
        [StringLength(15, "Field, {0}, cannot exceed {1} characters in length and cannot be less than {2} characters in length", 2)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
      //用于验证电子邮件地址格式的正则表达式
        [JsonIgnore]
        public string EmailAddress { get; set; }
       
        [Required]
        [StringLength(15, "Field, {0}, cannot exceed {1} characters in length and cannot be less than {2} characters in length", 2)]
        [RegularExpression(@"^ ?(([BEGLMNSWbeglmnsw][0-9][0-9]?)|(([A-PR-UWYZa-pr-uwyz][A-HK-Ya-hk-y][0-9][0-9]?)|(([ENWenw][0-9][A-HJKSTUWa-hjkstuw])|([ENWenw][A-HK-Ya-hk-y][0-9][ABEHMNPRVWXYabehmnprvwxy])))) ?[0-9][ABD-HJLNP-UW-Zabd-hjlnp-uw-z]{2}$")]
        [JsonIgnore] //它指示序列化器在将对象转换为 JSON 字符串时忽略标记了该注解的属性。
        public string PostCode { get; set; }
    }
}
