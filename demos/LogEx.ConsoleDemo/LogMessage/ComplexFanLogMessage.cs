using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogEx.ConsoleDemo.LogMessage
{
    /// <summary>
    /// 这个类暂时用来包括全部可能用到的字段，这样没有对日志进行分类，可能造成时间久了之后的日志数据不够优化的问题，但是在前期从某种角度简化我们的编程
    /// </summary>
    class ComplexFanLogMessage : CommonLogMessage
    {
        /// <summary>
        /// 类名（老范要求,这个地方内置的有一个Logger字段是记录类的，这里重复定义一个是为了和方法名成对出现，另外也作为一种扩展）
        /// </summary>
        public string fan_ClassName { get; set; }
        /// <summary>
        /// 方法名（老范要求）
        /// </summary>
        public string fan_FunctionInCode { get; set; }

        /// <summary>
        /// 产生一个ComplexFanLogMessage类型的日志消息实例
        /// </summary>
        /// <param name="entitySchemeName">数据表名</param>
        /// <param name="entityID">数据记录id</param>
        /// <param name="stringForOldEntity">旧数据（推荐使用json格式存储整条记录）</param>
        /// <param name="stringForNewEntity">新数据（推荐使用json格式存储整条记录）</param>
        /// <param name="description">描述</param>
        /// <param name="className">类名（老范要求,这个地方内置的有一个Logger字段是记录类的，这里重复定义一个是为了和方法名成对出现，另外也作为一种扩展）</param>
        /// <param name="functionInCode">方法名（老范要求）</param>
        /// <param name="userid">操作人（老范要求）</param>
        /// <param name="deviceInfo">设备（老范要求）</param>
        public ComplexFanLogMessage(string entitySchemeName, string entityID, string stringForOldEntity, string stringForNewEntity, string description, string className, string functionInCode, string userid, string deviceInfo) : base(entitySchemeName, entityID, stringForOldEntity, stringForNewEntity, description, deviceInfo, userid)
        {
            this.EntitySchemeName = entitySchemeName;
            this.EntityID = entityID;
            this.StringForOldEntity = stringForOldEntity;
            this.StringForNewEntity = stringForNewEntity;
            this.Description = description;
            this.fan_ClassName = className;
            this.fan_FunctionInCode = functionInCode;
            this.UserID = userid;
            this.DeviceInfo = deviceInfo;
        }
    }
}
