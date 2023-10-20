using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public class Event : IEvent
    {
        public Event(string message)
        {
            this.Message = message;
            this.TimeStamp = DateTime.Now;
        }
            
        public string Message { get; }

        public DateTime TimeStamp { get; }

        public override string ToString()
        {
            return $"[{this.TimeStamp:dd/MM/yyyy/HH:MM}] {this.Message}";
        }
    }
}
