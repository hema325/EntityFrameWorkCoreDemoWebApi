using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiEntityFramework.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[InverseProperty(nameof(Message.Sender))] we use it if we configure our relationship by convention to tell ef wich property it belongs to
        public List<Message> SendedMessages { get; set; }

        //[InverseProperty(nameof(Message.Receiver))]
        public List<Message> ReceivedMessages { get; set; }

    }
}
