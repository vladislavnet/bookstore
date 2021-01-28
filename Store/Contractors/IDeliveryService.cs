﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Contractors
{
    public interface IDeliveryService
    {
        string UniqueCode { get; }
        string Title { get; }
        Form CreateFort(Order order);
        Form MoveNext(int orderId, int step, IReadOnlyDictionary<string, string> dict);
        OrderDelivery GetDelivery(Form form);
    }
}
