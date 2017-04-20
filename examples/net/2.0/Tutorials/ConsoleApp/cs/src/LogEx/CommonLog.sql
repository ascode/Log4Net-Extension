create table log_common (
	id int identity(1,1) primary key,--逻辑主键
	log_date Date,--自动记录的日志的时间
	thread nvarchar(45),
	log_level nvarchar(45),--自动记录日志的分级
	logger nvarchar(100),--记录动作现场自动记录的类完全限定名
	message nvarchar(1000),--采取扩展日志方式的时候自动记录消息类型
	exception nvarchar(1000),--自动记录的异常信息
	entity_scheme_name nvarchar(45),--数据表名
	entity_id nvarchar(100),--数据记录id
	string_for_old_entity nvarchar(4000),--旧数据（推荐使用json格式存储整条记录）
	string_for_new_entity nvarchar(4000),--新数据（推荐使用json格式存储整条记录）
	description nvarchar(500),--描述
	device_info nvarchar(45),--设备信息
	userid nvarchar(45)--用户id
)


INSERT INTO log_common ([log_date],[thread],[log_level],[logger],[message],[exception],[entity_scheme_name],
[entity_id],[string_for_old_entity],[string_for_new_entity],[description],[device_info],[userid]) 
VALUES (@log_date, @thread, @log_level, @logger, @message,@exception,@entity_scheme_name,@entity_id,
@string_for_old_entity,@string_for_new_entity,@description,@device_info,@userid)