# Log4Net-Extension  
## 查看示例代码  
打开解决方案：examples\net\2.0\cs-examples.sln可以看到更多的内容。  

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
如果你无法上网，可以手动加入相关组件依赖。本解决方案中demos\LogEx.ConsoleDemo是手动加入LogEx的例子。  
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
