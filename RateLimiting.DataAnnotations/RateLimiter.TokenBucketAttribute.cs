﻿using RateLimiting.DataAnnotations.Metadatas;
using System;
using System.Threading.RateLimiting;

namespace RateLimiting.DataAnnotations
{
    partial class RateLimiter
    {
        /// <summary>
        /// 表示令牌桶限流器的属性。
        /// </summary>
        public class TokenBucketAttribute : RateLimiter, ITokenBucketRateLimiterMetadata
        {
            /// <summary>
            /// 获取或设置补充周期的秒数。
            /// </summary>
            public int ReplenishmentPeriodSeconds { get; set; }

            /// <summary>
            /// 获取或设置每个周期的令牌数。
            /// </summary>
            public int TokensPerPeriod { get; set; }

            /// <summary>
            /// 获取或设置是否自动补充令牌。
            /// </summary>
            public bool AutoReplenishment { get; set; } = true;

            /// <summary>
            /// 获取或设置令牌桶的令牌上限。
            /// </summary>
            public int TokenLimit { get; set; }

            /// <summary>
            /// 获取或设置队列处理顺序。
            /// </summary>
            public QueueProcessingOrder QueueProcessingOrder { get; set; } = QueueProcessingOrder.OldestFirst;

            /// <summary>
            /// 获取或设置队列限制。
            /// </summary>
            public int QueueLimit { get; set; }

            /// <inheritdoc></inheritdoc>/>
            public virtual TokenBucketRateLimiterOptions GetLimiterOptions(UnitPartitionKey key)
            {
                return new TokenBucketRateLimiterOptions
                {
                    AutoReplenishment = this.AutoReplenishment,
                    QueueLimit = this.QueueLimit,
                    QueueProcessingOrder = this.QueueProcessingOrder,
                    ReplenishmentPeriod = TimeSpan.FromSeconds(this.ReplenishmentPeriodSeconds),
                    TokenLimit = this.TokenLimit,
                    TokensPerPeriod = this.TokensPerPeriod
                };
            }
        }
    }
}