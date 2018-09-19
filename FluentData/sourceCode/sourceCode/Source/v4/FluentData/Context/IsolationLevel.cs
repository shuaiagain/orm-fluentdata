namespace FluentData
{
    /// <summary>
    /// 事务隔离级别
    /// </summary>
	public enum IsolationLevel
	{
        /// <summary>
        /// 正在使用与指定隔离级别不同的隔离级别，但是无法确定该级别
        /// </summary>
		Unspecified = -1,
        
        /// <summary>
        /// 无法改写隔离级别更高的事务中的挂起的更改
        /// </summary>
		Chaos = 16,
        
        /// <summary>
        /// 可以进行脏读，意思是说，不发布共享锁，也不接受独占锁
        /// </summary>
		ReadUncommitted = 256,
        
        /// <summary>
        /// 在正在读取数据时保持共享锁，以避免脏读，但是在事务结束之前可以更改数据，从而导致不可重复的读取或幻像数据
        /// </summary>
		ReadCommitted = 4096,

        /// <summary>
        /// 在查询中使用的所有数据上放置锁，以防止其他用户更新这些数据。防止不可重复的读取，但是仍可以有幻像行。
        /// </summary>
		RepeatableRead = 65536,

        /// <summary>
        /// 在 System.Data.DataSet 上放置范围锁，以防止在事务完成之前由其他用户更新行或向数据集中插入行。
        /// </summary>
		Serializable = 1048576,

        /// <summary>
        /// 通过在一个应用程序正在修改数据时存储另一个应用程序可以读取的相同数据版本来减少阻止。表示您无法从一个事务中看到在其他事务中进行的更改，即便重新查询也是如此。
        /// </summary>
		Snapshot = 16777216,
	}
}
