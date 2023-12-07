﻿namespace OnlineShop.Core.Domain.Common
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; } = default!;
    }

    public class BaseEntity : BaseEntity<long> { }
}