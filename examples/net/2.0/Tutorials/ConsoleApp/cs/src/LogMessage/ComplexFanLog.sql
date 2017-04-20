create table log_common_fan(
	id int identity(1,1) primary key,--逻辑主键
	log_date Date,--自动记录的日志的时间
	thread nvarchar(45),
	log_level nvarchar(45),--自动记录日志的分级
	logger nvarchar(100),--记录动作现场自动记录的类完全限定名
	message nvarchar(1000),--采取扩展日志方式的时候自动记录消息类型
	exception nvarchar(2000),--自动记录的异常信息
	entity_scheme_name nvarchar(45),--数据表名
	entity_id nvarchar(100),--数据记录id
	string_for_old_entity nvarchar(4000),--旧数据（推荐使用json格式存储整条记录）
	string_for_new_entity nvarchar(4000),--新数据（推荐使用json格式存储整条记录）
	description nvarchar(500),--描述
	fan_class_name nvarchar(45),--类名（老范要求,这个地方内置的有一个Logger字段是记录类的，这里重复定义一个是为了和方法名成对出现，另外也作为一种扩展）
	fan_function_in_code nvarchar(45),--方法名（老范要求）
	device_info nvarchar(45),--设备信息
	userid nvarchar(45)--用户id
)

INSERT INTO log_common_fan ([log_date],[thread],[log_level],[logger],[message],[exception],[entity_scheme_name],
[entity_id],[string_for_old_entity],[string_for_new_entity],[description],[fan_class_name],
[fan_function_in_code],[device_info],[userid]) 
VALUES (@log_date, @thread, @log_level, @logger, @message,@exception,@entity_scheme_name,@entity_id,
@string_for_old_entity,@string_for_new_entity,@description,@fan_class_name,@fan_function_in_code,@device_info,@userid)