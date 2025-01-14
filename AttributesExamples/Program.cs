﻿#define LOG_INFO
using System;
using System.Reflection;
using LoggingComponent;   //用于日志记录和验证功能的
using ValidationComponent;
using AttributesExamples.Models;
using System.Text.Json;

//[assembly: AssemblyVersion("2.0.1")]

[assembly: AssemblyDescription("My Assembly Description")]

namespace AttributesExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            Department dept = new Department();

            string empId = null;
            string firstName = null;
            string postCode = null;
            string deptShortName = null;


            Type employeeType = typeof(Employee);
            Type departmentType = typeof(Department);

            if (GetInput(employeeType, "Please enter the employee's id", "Id", out empId)) 
            {
                emp.Id = Int32.Parse(empId);
            }
            if (GetInput(employeeType, "Please enter the employee's first name", "FirstName", out firstName))
            {
                emp.FirstName = firstName;
            }
            if (GetInput(employeeType, "Please enter the employee's post code", "PostCode", out postCode))
            {
                emp.PostCode = postCode;
            }
            if (GetInput(departmentType, "Please enter the employee's department code", "DeptShortName", out deptShortName))
            {
                dept.DeptShortName = deptShortName;
            }
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Thank you! Employee with first name, {emp.FirstName}, and Id, {emp.Id}, has been entered successfully!!");
            Console.ResetColor();
           
            Console.ReadKey();

            var employeeJSON = JsonSerializer.Serialize<Employee>(emp);

            Console.WriteLine(employeeJSON);

            Console.ReadKey();


        }
//输入类型  并判断输入的有效性
        // 输入的类型 t  提示输入的字符串    和 正在输入字段的属性和名字   作为输出苍蝇 用于存储用户的存储的单元
        private static bool GetInput(Type t, string promptText, string fieldName, out string fieldValue) 
        {
            fieldValue = "";
            string enteredValue = "";
            string errorMessage = null;
            do
            {
                Console.WriteLine(promptText);
                //提示要输入的字段
                
                enteredValue = Console.ReadLine();
                 //输入的字段
                if (!Validation.PropertyValueIsValid(t, enteredValue, fieldName, out errorMessage))
                    //验证用户输入的值是否有效。如果验证失败，则显示错误消息，并继续提示用户输入。  没有就是对
                {
                    fieldValue = null;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(errorMessage);
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else 
                {
                    fieldValue = enteredValue;  //用于存储值的变量
                    break;
                }


            }
            while (true);

            return true;
        }

        private static void LoggingTest()
        {
            Logging.LogToScreen("This code is testing logging functionality");

        }
        private static void OutputGlobalAttributeInformation()
        {
            Assembly thisAssem = typeof(Program).Assembly;

            AssemblyName thisAssemName = thisAssem.GetName();

            Version thisAssemVersion = thisAssemName.Version;

            object[] attributes = thisAssem.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);

            var thisAssemDescriptionAttribute = attributes[0] as AssemblyDescriptionAttribute;

            Console.WriteLine($"Assembly Name: {thisAssemName}");
            Console.WriteLine($"Assembly Version: {thisAssemVersion}");

            if (thisAssemDescriptionAttribute != null)
                Console.WriteLine($"Assembly Description: {thisAssemDescriptionAttribute.Description}");

        }
    }
}
