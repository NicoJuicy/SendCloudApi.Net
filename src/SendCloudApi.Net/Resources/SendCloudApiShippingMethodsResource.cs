﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SendCloudApi.Net.Models;

namespace SendCloudApi.Net.Resources
{
    public class SendCloudApiShippingMethodsResource : SendCloudApiAbstractResource
    {
        public SendCloudApiShippingMethodsResource(SendCloudApi client) : base(client)
        {
            Resource = "shipping_methods";
            ListResource = "shipping_methods";
            SingleResource = "shipping_method";
            CreateRequest = false;
            UpdateRequest = false;
        }

        public async Task<ShippingMethod[]> Get(string senderAddress = null, int? servicePointId = null, bool? isReturn = false)
        {
            var parameters = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(senderAddress))
                parameters.Add("sender_address", senderAddress);
            if (servicePointId.HasValue)
                parameters.Add("service_point_id", servicePointId.ToString());
            if (isReturn.HasValue)
                parameters.Add("is_return", isReturn.ToString());
            return await Get<ShippingMethod[]>(parameters: parameters);
        }

        public async Task<ShippingMethod> Get(int shippingMethodId)
        {
            return await Get<ShippingMethod>(shippingMethodId);
        }
    }
}
