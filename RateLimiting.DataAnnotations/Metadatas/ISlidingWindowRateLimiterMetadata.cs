﻿using System.Threading.RateLimiting;

namespace RateLimiting.DataAnnotations.Metadatas
{
    /// <summary>
    /// 与滑动窗口限流器相关的元数据接口。
    /// </summary>
    public interface ISlidingWindowRateLimiterMetadata : IRateLimiterMetadata
    {
        RateLimitPartition<UnitPartitionKey> IRateLimiterMetadata.GetPartition(UnitPartitionKey key)
        {
            return RateLimitPartition.GetSlidingWindowLimiter(key, GetLimiterOptions);
        }


        /// <summary>
        /// 根据指定的单位获取滑动窗口限流器的选项。
        /// </summary>
        /// <param name="key">单元分区键。</param>
        /// <returns>滑动窗口限流器的选项。</returns>
        SlidingWindowRateLimiterOptions GetLimiterOptions(UnitPartitionKey key);
    }
}
