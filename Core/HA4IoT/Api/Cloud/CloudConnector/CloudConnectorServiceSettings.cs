﻿namespace HA4IoT.Api.Cloud.CloudConnector
{
    public class CloudConnectorServiceSettings
    {
        public string ServerAddress { get; set; } = "https://ha4iot-cloudapi.azurewebsites.net"; // TODO: remove

        public string ControllerId { get; set; }

        public string ApiKey { get; set; }

        public bool IsEnabled { get; set; }
    }
}
