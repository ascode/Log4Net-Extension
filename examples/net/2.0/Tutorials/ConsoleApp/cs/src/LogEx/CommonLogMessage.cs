using System;
using System.Collections.Generic;
using System.Text;
using log4net.Core;

namespace ConsoleApp.LogEx
{
    class CommonLogMessage
    {
        /// <summary>
        /// 数据表名
        /// </summary>
        public string EntitySchemeName { get; set; }
        /// <summary>
        /// 数据记录id
        /// </summary>
        public string EntityID { get; set; }
        /// <summary>
        /// 旧数据（推荐使用json格式存储整条记录）
        /// </summary>
        public string StringForOldEntity { get; set; }
        /// <summary>
        /// 新数据（推荐使用json格式存储整条记录）
        /// </summary>
        public string StringForNewEntity { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 终端设备
        /// </summary>
        public string DeviceInfo { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// 产生一个CommonLogMessage类型的日志消息实例
        /// </summary>
        /// <param name="entitySchemeName">数据表名</param>
        /// <param name="entityID">数据记录id</param>
        /// <param name="stringForOldEntity">旧数据（推荐使用json格式存储整条记录）</param>
        /// <param name="stringForNewEntity">新数据（推荐使用json格式存储整条记录）</param>
        /// <param name="description">描述</param>
        /// <param name="deviceInfo">终端设备</param>
        /// <param name="userid">用户id</param>
        public CommonLogMessage(string entitySchemeName,string entityID, string stringForOldEntity,string stringForNewEntity,string description,string deviceInfo, string userid) {
            this.EntitySchemeName = entitySchemeName;
            this.EntityID = entityID;
            this.StringForOldEntity = stringForOldEntity;
            this.StringForNewEntity = stringForNewEntity;
            this.Description = description;
            this.DeviceInfo = deviceInfo;
            this.UserID = userid;
        }
    }
}
