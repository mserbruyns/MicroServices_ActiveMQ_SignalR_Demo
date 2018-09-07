﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amqp;
using Amqp.Framing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Pencil42.PakjesDienst.Db;
using Pencil42.PakjesDienst.Db.Amqp;
using RMQ = RabbitMQ.Client;

namespace Pencil42.PakjesDienst.Api
{
    public class QueueSender
    {
        private readonly PakjesQueueSettings _settings;
        private readonly ILogger<QueueSender> _logger;

        public QueueSender(IOptions<PakjesQueueSettings> settings,
            ILogger<QueueSender> logger)
        {
            _settings = settings.Value;
            _logger = logger;
        }

        public async Task SendMessage(PakjeMessage pakjeMessage)
        {
            Address address = new Address(_settings.Address);
            Connection connection = await Connection.Factory.CreateAsync(address);
            Session session = new Session(connection);

            Message message = new Message() { BodySection = new AmqpValue<PakjeMessage>(pakjeMessage), Header = new Header() { Durable = false } };
            message.Header = new Header() { Durable = true };

            SenderLink sender = new SenderLink(session, "sender-link", _settings.QueueName);

            await sender.SendAsync(message);


            await sender.CloseAsync();
            await session.CloseAsync();
            await connection.CloseAsync();
        }
    }
}
