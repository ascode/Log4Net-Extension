# Log4Net-Extension更名为LogEx    
## 查看示例代码  
打开解决方案：examples\net\2.0\cs-examples.sln可以看到更多的内容。    
如果你无法上网，可以手动加入相关组件依赖。本解决方案中demos\LogEx.ConsoleDemo是手动加入LogEx和依赖的例子。  
运行这个例子，您只需要在sql server数据库中执行ComplexFanLogMessage.cs和ComplexFanLog.sql创建两个表，然后按照您的数据库配置配置好type="log4net.Appender.AdoNetAppender"的appender节下面的connectionString节，就可以运行了，运行程序之后，您可以在数据库表log_common和log_common_fan中分别看到程序中记录的日志信息。  

## 组件和版本  
* .net 4.0  
* log4net 2.0.8
* LogEx 1.0.0.0

## 文件包含  
使用LogEx，你所需要的文件可以全部在dist中找到：    
log4net.dll  、LogEx.dll  、App.config  、CommonLog.sql  
ComplexFanLogMessage.cs和ComplexFanLog.sql    

## 使用LogEx  
### 使用NuGet自动管理组件依赖  
推荐使用Nuget自动管理组件依赖。如果您使用NuGet管理组件依赖，那么您可以获得更好的版本管理体验。  
略。。  
### 手动加入LogEx以及组件依赖   
如果你无法上网，可以手动加入相关组件依赖。本解决方案中demos\LogEx.ConsoleDemo是手动加入LogEx和依赖的例子。  
1. 在项目中引用log4net.dll  、LogEx.dll
2. 在项目的配置文件中加入log4net配置节，并做好相关配置，参照App.config，这时候您已经可以开始使用LogEx记录日志
3. 如果您需要扩展需要记录的字段，那么可以加入ComplexFanLogMessage.cs，或者按照ComplexFanLogMessage.cs的方式建立自己的LogMessage。
4. 如果您使用sql server作为日志记录的存储，那么您可以执行CommonLog.sql或者ComplexFanLog.sql创建数据库表用来记录日志。
### 记录日志的代码  
记录日志的代码分为两种：  
1. log4net内置支持的日志记录方式： 
例如：log.Info("Application [ConsoleApp] Start");   
2. LogEx扩展的日志记录方式：  
例如：log.Info(new CommonLogMessage("1entitySchemeName", "2entityID", "3stringForOldEntity", "4stringForNewEntity", "5description", "8deviceinfo", "9userid"));  

### 分级日志  
LogEx日志分级就是log4net的日志分级，目前为：  
Debug、Error、Fatal、Info、Warn5个等级，请根据语义使用。使用方法为：log.Debug(...)、log.Error(...)、log.Fatal(...)、log.Info(...)、log.Warn(...)   

### 扩展  
这里扩展是指当您需要在日志中记录更多的字段的时候，可以在已经定义的字段上面进行扩展。  
涉及两个文件：LogMessage和.config。  
#### LogMessage  
在LogEx.ConsoleDemo项目中ComplexFanLogMessage.cs文件就是一个扩展的LogMessage的例子：   
1. 继承自：CommonLogMessage  
2. 借助CommonLogMessage的构造函数构造ComplexFanLogMessage实例。  
#### .config  
这里说的.config就是配置文件  
```
....
<commandText value="INSERT INTO log_common_fan ([log_date],[thread],[log_level],[logger],[message],[exception],[entity_scheme_name],[entity_id],[string_for_old_entity],[string_for_new_entity],[description],[fan_class_name],[fan_function_in_code],[device_info],[userid]) VALUES (@log_date, @thread, @log_level, @logger, @message,@exception,@entity_scheme_name,@entity_id,@string_for_old_entity,@string_for_new_entity,@description,@fan_class_name,@fan_function_in_code,@device_info,@userid)"/>
....
<parameter>
        <parameterName value="@entity_scheme_name"/>
        <dbType value="String"/>
        <size value="45"/>
        <layout type="LogEx.CommonLayout,LogEx">
          <conversionPattern value="%property{EntitySchemeName}"/>
        </layout>
      </parameter>
....
```
如以上代码，这里扩展需要关注如上两个部分：commandText、parameter。  
commandText就是配置记录日志的sql语句，采用参数的方式，参数在parameter定义。  
“@entity_scheme_name”对应参数名   
“dbType”配置数据类型  
“size”配置数据长度   
“%property{EntitySchemeName}”中的“EntitySchemeName”对应LogMessage类中的成员变量名  
“LogEx.CommonLayout,LogEx”就是LogEx提供的Layout，这里保持不变。  

### 配置  
以上文档中已经提及一部分配置，这里再就相关配置进行说明。  
 ```
 <appender name="LogFileAppender" type="log4net.Appender.FileAppender">
 ...
<appender name="ADONetAppender_SqlServer_CommonLog" type="log4net.Appender.AdoNetAppender">
...
 root中的<level value="ALL"/>  
 root中的<appender-ref ref="ADONetAppender_SqlServer_CommonLog"/>  
 ```
 如上appender定义日志的输出目标。type="log4net.Appender.FileAppender"指定输出目标为文件；type="log4net.Appender.AdoNetAppender"指定输出目标可以是sql server数据库。  
root中的appender-ref ref中指定的字符就是appender指定的名字，在这里指定之后才可使用目标配置并输出日志记录。  

### 项目中的使用要求  
现在根据项目要求，需要开启日志记录到sql server数据库和记录到本地的log日志文件。  